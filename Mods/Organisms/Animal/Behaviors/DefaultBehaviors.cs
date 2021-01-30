// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms.Behaviors
{
    using Eco.Shared.States;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Simulation.RouteProbing;
    using Eco.Simulation.Time;
    using Eco.Simulation.Agents.AI;
    using Eco.Simulation.Agents;

    public class DefaultBehaviors
    {
        // debug state triggered by a button in the unity inspector, paths animals back and forth between two points
        /*
        public static BTStatus DebugPath(Animal agent)
        {
            MovementBehaviors.LandMovement(()
            agent.Target.Set(agent.Target.TargetPosition, agent.Target.StartPosition, agent.Species.WanderingSpeed);
            agent.NextTick = agent.Target.TargetTime;
            return BTStatus.Success;
        }

        /*
        public static void ForgetTarget(Animal agent)
        {
            if (agent.HasMemory(Animal.FollowingTargetMemory))
            {
                agent.Stop();
                agent.RemoveMemory(Animal.GrowlTimeMemory);
                agent.RemoveMemory(Animal.FollowingTargetMemory);
            }
        }*/
        /*
        public static BTStatus RunToTarget(INetObjectPosition target, Vector3 targetDirection, Animal agent, float speed)
        {
            if (agent.ShouldFlee(agent)) return BTStatus.Failure;

            agent.NextTick = WorldTime.Seconds + 1f;
            if (agent.TryGetMemory(Animal.FollowingTargetMemory, out INetObjectPosition followingTarget))
            {
                if (followingTarget != target) return BTStatus.Failure;
                if (agent.TryGetMemory(Animal.FollowingTargetPositionMemory, out Vector3 targetPosition) &&
                    Vector3.Distance(targetPosition, followingTarget.Position) < agent.Species.FollowRange)
                {
                    if (agent.Target.LookTargetPos != followingTarget)
                    {
                        agent.Target.LookTargetPos = followingTarget;
                        return BTStatus.Running;
                    }

                    return BTStatus.RunningUnchanged;
                }
            }

            var routeProps = new RouteProperties { MaxTargetLocationHeight = agent.Species.ClimbHeight };
            var route = AIUtilities.GetRouteFacingTarget(agent.Position, target.Position + targetDirection, speed, agent.Species.HeadDistance, routeProps: routeProps);
            agent.Target.SetPath(route);
            agent.SetMemory(Animal.FollowingTargetMemory, target);
            agent.SetMemory(Animal.FollowingTargetPositionMemory, target.Position);
            agent.RemoveMemory(Animal.PathEndTime);
            agent.AnimationState = AnimalState.Wander;
            return BTStatus.Success;
        }*/
    }
}
