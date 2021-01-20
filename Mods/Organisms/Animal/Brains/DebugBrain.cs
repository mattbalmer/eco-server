// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using Eco.Mods.Organisms.Behaviors;
    using Eco.Shared.Utils;
    using Eco.Shared.States;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Gameplay.AI;
    using System.Collections.Generic;
    using Eco.Shared.Networking;

    public class DebugBrain : Brain
    {
        public override Behavior<Animal> RootBehavior(Animal animal) => Root;
        static readonly Behavior<Animal> Root;

        static DebugBrain()
        {
            Root = BT.Selector("Debug Behavior", 
                    //BT.If("Follow ", (a => a.Position.WrappedDistance(MovementBehaviors.ShouldReturnHome, MovementBehaviors.WanderHome), ";
                    RelaxBehaviors.TryIdle);
        }

        private class FollowBehavior : Behavior<Animal>
        {
            const float StartFollowingDistance = 5;
            enum Memory { FollowTarget }

            public override BTStatus Do(Animal animal)
            {
                if (animal.TryGetMemory<INetObjectPosition>(Memory.FollowTarget.ToString(), out var target))
                {
                    //if (animal.Position.WrappedDistance(target.Position) > StartFollowingDistance)
                      //  MovementBehaviors.LandMovement(ContextBoundObject, )
                }
                throw new NotImplementedException();
            }
        }

        public static Behavior<Animal> FindAndEatPlants = new FindAndEatPlantsBehavior(new LandAnimalFindFoodBehavior());
        
        //Private behavior for land animals to find food.
        class LandAnimalFindFoodBehavior : Behavior<Animal>
        {
            public override string Name => "Land Animal Find Food";
            public override IEnumerable<Behavior<Animal>> ChildrenBehaviors => new[] { MovementBehaviors.WanderHome, MovementBehaviors.Wander };

            public override BTStatus Do(Animal agent)
            {
                // let animals wander to weird places while hungry, but if they are starving go home
                if (agent.Hunger > StarvingThreshold && MovementBehaviors.ShouldReturnHome(agent).Test) 
                { 
                    var status = MovementBehaviors.WanderHome.Do(agent);
                    return this.Status(status, agent, "Starving, returning home.");
                }
                else
                { 
                    var status = MovementBehaviors.Wander.Do(agent);
                    return this.Status(status, agent, "Wandering looking for food");
                }
            }
        }
    }
}
