// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms.Behaviors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Shared.Math;
    using Eco.Shared.States;
    using Eco.Shared.Utils;
    using Eco.Simulation;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Simulation.RouteProbing;

    /// <summary>An enumerator gets instantiated per-animal while seeking food and deleted when the animal is satisfied. </summary>
    public class FindAndEatPlantsBehavior : BehaviorComplex<Animal>
    {
        public override IEnumerable<Behavior<Animal>> ChildrenBehaviors => new[] { this.noNearbyFoodBehavior };
        public float HungerRestoredPerEat = 10;

        Behavior<Animal> noNearbyFoodBehavior;

        //Create a version of this behavior, passing in the subbehavior we use to get nearby food.
        public FindAndEatPlantsBehavior(Behavior<Animal> noNearbyFoodBehavior) 
        {
            this.noNearbyFoodBehavior = noNearbyFoodBehavior;
        }

        protected override Result ShouldStart(Animal animal) 
        { 
            return animal.Hunger > Brain.HungerToStartEating ? Result.SucceedNTStr("hungry") 
                                                             : Result.FailNT($"hunger ({animal.Hunger.ToString("0.#")}) > threshold ({Brain.HungerToStartEating})"); 
        }

        protected override Result ShouldStop(Animal animal)  
        { 
            if (animal.Hunger < Brain.HungerToStopEating) return Result.SucceedNT($"hunger ({animal.Hunger}) < satiated ({Brain.HungerToStopEating})");
            if (animal.Alertness > Animal.FleeThreshold) return Result.SucceedNTStr("alert interrupted eating");
            return Result.FailNTStr("stil hungry");
        }

        private IEnumerable<Vector3> GetFoodSources(Animal agent)
        {
            var agentRegion = RouteRegions.GetRegion(agent.GroundPosition.WorldPosition3i);
            return EcoSim.PlantSim.PlantsWithinRange(agent.Position, 10, 
                    plant => agent.Species.Eats(plant.Species) && 
                             RouteRegions.GetRegion(plant.Position.WorldPosition3i.Down()) == agentRegion)
                    .Shuffle().Select(plant => plant.Position + Vector3.Down);
        }

        protected override IEnumerator<BTResult> DoStages(Animal agent) => 
            FindAndEatSomethingBehavior.FindAndEatSomething(agent, this.noNearbyFoodBehavior, () => this.GetFoodSources(agent), this.HungerRestoredPerEat);
    }
}
