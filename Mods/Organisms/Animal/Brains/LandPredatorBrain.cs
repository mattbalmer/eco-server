// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using System.Linq;
    using Eco.Gameplay.AI;
    using Eco.Mods.Organisms.Behaviors;
    using Eco.Shared.States;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Shared.Networking;
    using Eco.Gameplay.Players;
    using Eco.Simulation.Time;
    using Eco.Mods.TechTree;
    using Eco.Shared.Math;
    
    public class LandPredatorBrain : LandAnimalBrain 
    {
        public static readonly Behavior<Animal> FindAndAttackEnemyTree;
        public static readonly Behavior<Animal> LandPredatorTreeRoot;
        private static readonly Type[] dangerousWorldObjectTypes = { 
            typeof(TorchStandObject), typeof(PoweredCartObject), typeof(WoodenElevatorObject), 
            typeof(IndustrialElevatorObject), typeof(BaseRampObject), typeof(AsphaltConcreteRampObject), typeof(StoneRampObject) };

        public override void SetDamaged(Animal agent, INetObject damager, out bool isRunAway)
        {
            base.SetDamaged(agent, damager, out isRunAway);
            // Defense on player's acting, attack player if he's damaging us
            if (agent.Alertness < Animal.FleeThreshold && damager is Player player)
            {
                // Run to target if it's in a reachable distance (detect range)
                // Otherwise it's too far and better to run away (while animal is running to player, he may kill us)
                if (player.Position.WrappedDistance(agent.GroundPosition) < agent.Species.DetectRange)
                {
                    // Make sure we're anger enough for attacking
                    agent.Anger = Animal.AngerLevelToAttack * 2f;
                    // Follow a new target or continue following previous
                    if (agent.Prey == null)
                    {
                        // Take a little time for reacting and then run to a target
                        agent.Prey = player;
                        agent.NextTick = WorldTime.Seconds + 0.5f;
                    }
                    isRunAway = false;
                }
            }
        }

        public override Behavior<Animal> RootBehavior(Animal animal) => LandPredatorTreeRoot;

        /// <summary> Provide predator's reaction on blocks around </summary>
        public override bool ReactOnBlock(Animal agent, Vector3 areaCenter, float areaRadius)
        {
            // You're free to add more rules for alerting predators in dangerous areas (more building rules/transport objects etc.)
            // Run from torch stand TODO run only if torch is inside a torch stand
            var worldObjectsAround = NetObjectManager.GetObjectsWithin(areaCenter, areaRadius);
            foreach (var worldObject in worldObjectsAround)
            {
                if (dangerousWorldObjectTypes.Any(objectType => objectType == worldObject.GetType()))
                {
                    agent.FleeFromImmediately(areaCenter);
                    agent.Alertness = Animal.MaxAlertness;
                    return true;
                }
            }
            
            return false;
        }

        static LandPredatorBrain()
        {
            FindAndAttackEnemyTree =
                BT.Selector("Select Attacking",
                    BT.If("Looking for an enemy", PredatorBehaviors.FindEnemy,
                        BT.Selector("Try attacking",
                            BT.If("Ready For Attack", PredatorBehaviors.CheckAttacking,
                                BT.Selector("Attack Enemy",
                                    BT.If("Try Wake Up", x => ((x.State == AnimalState.Sleeping || x.State == AnimalState.LyingDown) &&
                                                               x.Alertness < Animal.WakeUpAlertness, "sleeping/lying and alert"),
                                        Anim(AnimalState.Idle, true, x => x.Species.TimeLayToStand)),
                                    BT.If("Try Make Route", PredatorBehaviors.ChasePrey)
                                )
                            ),
                            PredatorBehaviors.TryFleeing
                    )
                ));


            LandPredatorTreeRoot =
                BT.Selector("Land Predator Brain",
                    MovementBehaviors.Flee,
                    FindAndAttackEnemyTree,
                    FindAndEatCorpse,
                    LyingDownTree,
                    MovementBehaviors.TryReturnHome,
                    RelaxBehaviors.Relax,
                    MovementBehaviors.Wander,
                    RelaxBehaviors.Idle
                );
        }
        
        public static Behavior<Animal> FindAndEatCorpse = new FindAndEatCorpseBehavior(new LandAnimalFindFoodBehavior());
    }
}
