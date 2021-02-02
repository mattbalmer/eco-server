// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms.Behaviors
{
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Localization;
    using System.Linq;
    using Eco.Gameplay.AI;
    using Eco.Gameplay.Players;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.States;
    using Eco.Shared.Utils;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Simulation.RouteProbing;
    using Eco.Simulation.Time;
    using Eco.World.Blocks;

    public static class MovementBehaviors
    {
        public const float FleeMinDist    = 1f;
        public const float FleeMaxDist    = 50f;
        public const float FleeMinAngle   = 0f;
        public const float FleeMaxAngle   = 90f;
        public const float GoHomeDistance = 80f;                    // 2 animal world layer cells 
        #region syntactic sugar
        public static Behavior<Animal> Wander                  = new BehaviorBasic<Animal>("Wander",                (beh, agent) => LandMovement(agent, Vector2.zero, true, AnimalState.Wander, minDirectionOffsetDegrees: FleeMinAngle, maxDirectionOffsetDegrees: FleeMaxAngle)); 
        public static Behavior<Animal> SwimWander              = new BehaviorBasic<Animal>("SwimWander",            (beh, agent) => Swim(agent, Vector2.zero, true, AnimalState.Diving, false));
        public static Behavior<Animal> SwimWanderSurface       = new BehaviorBasic<Animal>("SwimWanderSurface",     (beh, agent) => Swim(agent, Vector2.zero, true, AnimalState.SurfaceSwimming, true));
        public static Behavior<Animal> AmphibiousWander        = new BehaviorBasic<Animal>("AmphibiousWander",      (beh, agent) => AmphibiousMovement(agent, Vector2.zero, true, AnimalState.Wander));

        public static Behavior<Animal> WanderHome              = new BehaviorBasic<Animal>("WanderHome",            (beh, agent) => LandMovement(agent, agent.GetDirectionHome(), true, AnimalState.Wander, minDirectionOffsetDegrees: FleeMinAngle, maxDirectionOffsetDegrees: FleeMaxAngle)); 
        public static Behavior<Animal> SwimWanderHome          = new BehaviorBasic<Animal>("SwimWanderHome",        (beh, agent) => Swim(agent, agent.GetDirectionHome(), true, AnimalState.WanderHome, false)); 
        public static Behavior<Animal> SwimWanderHomeSurface   = new BehaviorBasic<Animal>("SwimWanderHomeSurface", (beh, agent) => Swim(agent, agent.GetDirectionHome(), true, AnimalState.WanderHome, true)); 
        public static Behavior<Animal> AmphibiousWanderHome    = new BehaviorBasic<Animal>("AmphibiousWanderHome",  (beh, agent) => AmphibiousMovement(agent, agent.GetDirectionHome(), true, AnimalState.WanderHome)); 
                                                                   
        public static Behavior<Animal> Flee                    = new BehaviorBasic<Animal>("Flee",                  (beh, agent) => agent.ShouldFlee(beh) ? LandMovement(agent, agent.GetFleeDirectionWithChanceToStopFleeing().XZ, false, AnimalState.Flee, FleeMinDist, FleeMaxDist, FleeMinAngle, FleeMaxAngle, 10) : BTResult.Failure()); 
        public static Behavior<Animal> SwimFlee                = new BehaviorBasic<Animal>("SwimFlee",              (beh, agent) => agent.ShouldFlee(beh) ? Swim(agent, agent.GetFleeDirectionWithChanceToStopFleeing().XZ, false, AnimalState.Flee, false, 30)                                                        : BTResult.Failure()); 
        public static Behavior<Animal> SwimFleeSurface         = new BehaviorBasic<Animal>("SwimFleeSurface",       (beh, agent) => agent.ShouldFlee(beh) ? Swim(agent, agent.GetFleeDirectionWithChanceToStopFleeing().XZ, false, AnimalState.Flee, true, 30)                                                         : BTResult.Failure()); 
        public static Behavior<Animal> AmphibiousFlee          = new BehaviorBasic<Animal>("AmphibiousFlee",        (beh, agent) => agent.ShouldFlee(beh) ? AmphibiousMovement(agent, agent.GetFleeDirectionWithChanceToStopFleeing().XZ, false, AnimalState.Flee)                                                     : BTResult.Failure());

        public static Behavior<Animal> MoveToWater             = new BehaviorBasic<Animal>("Move To Water",         (beh, agent) => RouteToWater(agent, true, AnimalState.Wander));
        #endregion

        public static (bool Test, string Result) ShouldReturnHome(Animal agent)
        {
            var distHome = Vector2.WrappedDistance(agent.Position.XZi, agent.WorldHomePos);
            return (distHome > GoHomeDistance, $"distance from home ({distHome}) > {GoHomeDistance}");
        }

        public static Behavior<Animal> TryReturnHome => BT.If("Try Return Home", ShouldReturnHome, WanderHome);
        
        public static BTResult MoveTo(Animal agent, Vector3 target, bool wandering)
        {
            var routeProps = new RouteProperties {MaxTargetLocationHeightDelta = agent.Species.ClimbHeight};
            var route      = AIUtil.GetRouteFacingTarget(agent.FacingDir, agent.Position, target, agent.Species.GetTraversalData(wandering), agent.Species.HeadDistance * 2, routeProps: routeProps, allowBasic: false);
            if (!route.IsValid) return BTResult.Failure("Can't build route");
            
            // Prevent setting route with 0 time length
            var timeToFinishRoute = agent.SetRoute(route, wandering ? AnimalState.Wander : AnimalState.Flee);
            if (timeToFinishRoute < float.Epsilon) return BTResult.Failure("route not set");
            return BTResult.RunningChanged("Moving to target");
        }

        public static BTResult LandMovement(Animal agent,
                                            Vector2 direction,
                                            bool wandering,
                                            AnimalState state,
                                            float minDistance               = 1f,
                                            float maxDistance               = 20f,
                                            float minDirectionOffsetDegrees = 0,
                                            float maxDirectionOffsetDegrees = 360,
                                            int tryCount                    = 10,
                                            bool isUnstuckable              = true,
                                            bool skipRouteProperties        = false)
        {
            var routeProps = skipRouteProperties ? null : new RouteProperties
            {
                MaxTargetLocationHeightDelta = agent.Species.ClimbHeight,
                MinDirectionOffsetDegrees    = minDirectionOffsetDegrees,
                MaxDirectionOffsetDegrees    = maxDirectionOffsetDegrees
            };

            var groundPos = agent.GroundPosition;
            var search = RouteProbingUtils.FindRandomGroundRoute(agent.FacingDir, groundPos, minDistance, maxDistance, agent.FacingDir.XZ.Normalized, direction, routeProps);
            if (search != null)
            {
                var smoothed          = search.LineOfSightSmoothGroundPosition(groundPos);
                var route             = new Route(agent.Species.GetTraversalData(wandering), agent.FacingDir, smoothed);
                // Apply route if its need more than 0 time to finish
                var timeToFinishRoute = agent.SetRoute(route, state);
                if (timeToFinishRoute > float.Epsilon)
                {
                    agent.RemoveMemory(Animal.TriesToUnStuckMemory);
                    return BTResult.RunningChanged($"Picked new point.");
                }
            }

            agent.RemoveMemory(Animal.ShouldFleeTillMemory);
            return isUnstuckable ? LandAnimalUnStuckOrDie(agent) : BTResult.Failure("Stuck!");
        }

        public static BTResult Swim(Animal agent, Vector2 direction, bool wandering, AnimalState state, bool surface, int tries = 10)
        {
            var targetPos = AIUtil.FindTargetSwimPosition(agent.Position, 5.0f, 20.0f, direction, 90, 360, tries, surface).XYZi;
            if (targetPos == agent.Position)
                return BTResult.Failure("target position is current position.");

            // Avoid fish swimming too close to coast line
            // TODO: Avoid building routes near coast, cache available points far away from coast
            if (!agent.Species.CanSwimNearCoast)
            {
                var waterHeight = World.World.GetWaterHeight(targetPos.XZ);
                var isNearCoast = ((WorldPosition3i) targetPos).SpiralOutXZIter(3).Any(groundPos => World.World.GetBlock((WrappedWorldPosition3i) groundPos.X_Z(waterHeight)).Is<Solid>());
                if (isNearCoast) return BTResult.Failure("target position is too close to coast line");
            }

            var targetBlock = World.World.GetBlock(targetPos);
            // If an animal can't float on water surface - move it a block below highest water block TODO: make them move on underwater ground
            // TODO: Remove after pathfinder improvements
            if (!agent.Species.FloatOnSurface && targetBlock is WaterBlock && World.World.GetBlock(targetPos + Vector3i.Up).Is<Empty>())
                targetPos += Vector3i.Down;
            //if (targetBlock.Is<Solid>()) targetPos += Vector3i.Up;
            if (targetBlock.Is<Empty>())
            {
                targetPos += Vector3i.Down;
                // Fail if target position is too shallow
                if (World.World.GetBlock(targetPos).Is<Solid>())
                    return BTResult.Failure("target position is too thin");
            }
            // Clamp current position to ground or water, if can't float on water surface - stay below water height TODO: make them move on underwater ground
            var pos       = World.World.ClampToWaterHeight(agent.Position.XYZi);
            // TODO: Remove after pathfinder improvements
            if (!agent.Species.FloatOnSurface && pos.y == World.World.GetWaterHeight(agent.Position.XZi)) pos += Vector3i.Down;
            
            var route     = Route.Basic(agent.Species.GetTraversalData(wandering), agent.FacingDir, pos + Vector3i.Down, targetPos); //For fish, we need to compensate, since route is built from positions of the ground below
            var routeTime = route.IsValid ? agent.SetRoute(route, state, null) : 0f;
            return routeTime < float.Epsilon ? BTResult.Failure("route not set") : BTResult.Success($"swimming path");
        }
        
        public static BTResult AmphibiousMovement(Animal agent, Vector2 generalDirection, bool wandering, AnimalState state, float minDistance = 2f, float maxDistance = 20f)
        {
            var startPathPos = agent.Position.WorldPosition3i;

            //Plop us into water if we're above it. 
            if (World.World.GetBlock((Vector3i)startPathPos.Down()).GetType() == typeof(WaterBlock))
                startPathPos = startPathPos.Down();

            if (!World.World.IsUnderwater(startPathPos))
                startPathPos = RouteManager.NearestWalkablePathPos(agent.Position.WorldPosition3i); //Boot us down/up to the surface if we're on land.

            if (!startPathPos.IsValid)
                return LandMovement(agent, generalDirection, wandering, state, minDistance, maxDistance);
            
            generalDirection = generalDirection == Vector2.zero ? Vector2.right.Rotate(RandomUtil.Range(0f, 360)) : generalDirection.Normalized;
            
            // Take random ground position in the given direction
            var targetGround = (agent.Position + (generalDirection * RandomUtil.Range(minDistance, maxDistance)).X_Z()).WorldPosition3i;
            // Floating animals will stick to water surface or land, non floating - land or return to swimming state
            if (World.World.IsUnderwater(targetGround) && agent.Species.FloatOnSurface)
                targetGround.y = World.World.MaxWaterHeight[targetGround];
            else
            {
                targetGround = RouteManager.NearestWalkableXYZ(targetGround, 5);
                if (!agent.Species.FloatOnSurface && !targetGround.IsValid)
                {
                    agent.Floating = false;
                    return BTResult.Failure("Can't float, continue swimming");
                }
            }

            // This is a low-effort search that includes water surface and should occasionally fail, just pick a semi-random node that was visited when it fails
            var routeProps       = new RouteProperties() {MaxTargetLocationHeightDelta = agent.Species.ClimbHeight};
            var allowWaterSearch = new AStarSearch(RouteCacheData.NeighborsIncludeWater, agent.FacingDir, startPathPos, targetGround, 30, routeProps, false);
            if (allowWaterSearch.Status != SearchStatus.PathFound)
            {
                targetGround = allowWaterSearch.GroundNodes.Last().Key;
                allowWaterSearch.GetPathToWaterPos(targetGround);
            }

            // Apply land movement only for land positions
            if (!World.World.IsUnderwater(agent.Position.WorldPosition3i))
            {
                if (allowWaterSearch.GroundPath.Count < 2)
                    return LandMovement(agent, generalDirection, wandering, state, minDistance, maxDistance, skipRouteProperties: true);
                if (allowWaterSearch.Status == SearchStatus.Unpathable && allowWaterSearch.GroundNodes.Count < RouteRegions.MinimumRegionSize)
                {
                    // Search region was unexpectedly small and agent is on land, might be trapped by player construction. 
                    // Try regular land movement so region checks can apply & the agent can get unstuck (or die)
                    return LandMovement(agent, generalDirection, wandering, state, minDistance, maxDistance);
                }
            }

            var smoothed  = allowWaterSearch.LineOfSightSmoothWaterPosition(agent.GroundPosition);
            var route     = new Route(agent.Species.GetTraversalData(wandering), agent.FacingDir, smoothed);
            if (!route.IsValid) route = Route.Basic(agent.Species.GetTraversalData(wandering), agent.FacingDir, agent.GroundPosition, route.EndPosition);
            var routeTime = agent.SetRoute(route, state, null);
            return routeTime < float.Epsilon ? BTResult.Failure("route not set") : BTResult.Success($"swimming path");
        }

        public static BTResult RouteToWater(Animal agent, bool wandering, AnimalState state)
        {
            var start = agent.Position.WorldPosition3i;

            // only works for surface start points
            if (World.World.IsUnderwater(start))            return BTResult.Failure("Already underwater."); 
            if (start.y != World.World.MaxYCache[start])    return BTResult.Failure("Not on world surface.");
            if (RouteManager.RouteToSeaMap == null)         return BTResult.Failure("Missing sea route map.");

            if (start.IsValid)
            {
                agent.ChangeState(state, 0, false);

                // get a destination a decent
                var current = start;
                for (int i = 0; i < 10; i++)
                {
                    var next = RouteManager.RouteToSeaMap[current];
                    if (next == current) break;
                    current = next;
                    if (WorldPosition3i.Distance(current, start) > 10)
                        break;
                }

                var target = ((Vector2)WorldPosition3i.GetDelta(current, start).XZ).Rotate(RandomUtil.Range(-20, 20));
                return AmphibiousMovement(agent, target, wandering, state, 10, 20);
            }

            return BTResult.Failure("Invalid start pos");
        }

        // If the animal is stuck somewhere it shouldn't be help it escape or die if its very far from walkable terrain
        public static BTResult LandAnimalUnStuckOrDie(Animal agent)
        {
            const int maxUnStuckDistance = 20;
            var nearestValid = RouteManager.NearestWalkableXYZ(agent.Position.XYZi, maxUnStuckDistance);
            if (nearestValid == agent.Position.WorldPosition3i)
            {
                agent.NextTick = WorldTime.Seconds + 10f;
                return BTResult.Failure();
            }

            if (!nearestValid.IsValid)
            {
                // cheating failed? time to die!
                agent.Kill();
                return BTResult.Success();
            }
            // ignore terrain, path directly to a valid area, but only if noone is around *shy* or if he's really trying
            if (agent.TryGetMemory(Animal.TriesToUnStuckMemory, out int tries)) tries += 1;
            agent.SetMemory(Animal.TriesToUnStuckMemory, tries);
            if (!NetObjectManager.GetObjectsWithin(agent.Position.XZ, 20).OfType<Player>().Any() || tries >= 3)
            {
                var route = AIUtil.GetRoute(agent.FacingDir, agent.Position, (Vector3) nearestValid, agent.Species.GetTraversalData(true), null, null);
                if (!route.IsValid)
                {
                    agent.NextTick = WorldTime.Seconds + 10;
                    return BTResult.Failure();
                }

                // Proceed with route with time length more than 0
                var timeToFinishRoute = agent.SetRoute(route, AnimalState.Wander);
                if (timeToFinishRoute > float.Epsilon)
                {
                    agent.RemoveMemory(Animal.TriesToUnStuckMemory);
                    return BTResult.Success();
                }
            }

            agent.NextTick = WorldTime.Seconds + 10;
            return BTResult.Failure();
        }
    }
}
