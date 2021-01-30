// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using Eco.Mods.Organisms.Behaviors;
    using Eco.Shared.Utils;
    using Eco.Shared.States;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Gameplay.AI;
    using System.Collections.Generic;

    public class LandAnimalBrain : Brain
    {
        public override Behavior<Animal> RootBehavior(Animal animal) => LandAnimalTreeRoot;

        public static readonly Behavior<Animal> LyingDownTree;
        public static readonly Behavior<Animal> LandAnimalTreeRoot;
        public const float MinLyingIdleTime      = 10f;
        public const float MaxLyingIdleTime      = 20f;
        public const float ChanceToIdle          = 0.3f;
        static LandAnimalBrain()
        {
            LyingDownTree =
                BT.If("Lying", animal => (animal.LyingDown(), "currently lying"),
                    BT.Selector("Select Lying",
                        BT.If("Try Getup",         x => ((x.State == AnimalState.Sleeping || x.State == AnimalState.LyingDown) && x.Alertness >= Animal.WakeUpAlertness, "sleeping/lying and alert"),
                                                   Anim(AnimalState.Idle, true, x => x.Species.TimeLayToStand)),  // waking up takes time, start the transition animation then decide what to do next tick
                        BT.If("Try Flee",          x => (x.Alertness > Animal.FleeThreshold, $"{x.Alertness} alert > {Animal.FleeThreshold} flee"),
                                                   Anim(AnimalState.Flee, false, x => x.Species.TimeLayToStand)),
                        BT.If("Try Hungry",        x => (x.Hunger > HungerToStartEating, $"{x.Hunger} hunger > {HungerToStartEating}"),
                                                   Anim(AnimalState.Idle, true, x => x.Species.TimeLayToStand)),
                        RelaxBehaviors.TrySleep,
                        RelaxBehaviors.RandomWake,
                        Anim(AnimalState.LyingDown, true, _ => RandomUtil.Range(MinLyingIdleTime, MaxLyingIdleTime))));

            LandAnimalTreeRoot =
                BT.Selector("Land Animal", 
                    LyingDownTree,
                    PerceptionBehaviors.Alert,
                    MovementBehaviors.Flee,
                    FindAndEatPlants, 
                    MovementBehaviors.TryReturnHome,
                    RelaxBehaviors.Relax,
                    MovementBehaviors.Wander,
                    RelaxBehaviors.Idle);
        }

        public static Behavior<Animal> FindAndEatPlants = new FindAndEatPlantsBehavior(new LandAnimalFindFoodBehavior());
        
        //Private behavior for land animals to find food.
        protected class LandAnimalFindFoodBehavior : Behavior<Animal>
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
