// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms.Behaviors
{
    using Eco.Shared.Math;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using System.Collections.Generic;
    using Eco.Core.Utils;
    using System.Linq;
    using Eco.Shared.Networking;
    
    public class FindAndEatCorpseBehavior : BehaviorComplex<Animal>
    {
        public override IEnumerable<Behavior<Animal>> ChildrenBehaviors => new[] { this.noNearbyFoodBehavior };
        public float HungerRestoredPerEat = 10;

        Behavior<Animal> noNearbyFoodBehavior;

        //Create a version of this behavior, passing in the subbehavior we use to get nearby food.
        public FindAndEatCorpseBehavior(Behavior<Animal> noNearbyFoodBehavior) 
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
            return Result.FailNTStr("still hungry");
        }

        private IEnumerable<Vector3> GetFoodSources(Animal agent)
        {
            return NetObjectManager.GetObjectsWithin(agent.Position.XZ, 10).OfType<Animal>()
                .Where(x => agent.Species.Eats(x.Species) &&
                            x != agent &&
                            x.Dead).Select(x=>x.Position);
        }
        
        protected override IEnumerator<BTResult> DoStages(Animal agent) => FindAndEatSomethingBehavior.FindAndEatSomething(agent, this.noNearbyFoodBehavior, () => this.GetFoodSources(agent), this.HungerRestoredPerEat);
    }
}
