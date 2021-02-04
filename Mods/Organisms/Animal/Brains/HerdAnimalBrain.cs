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

    public class HerdAnimalBrain : Brain
    {
        public override Behavior<Animal> RootBehavior(Animal animal) => HerdAnimalTreeRoot;
        public static readonly Behavior<Animal> HerdAnimalTreeRoot;

        static HerdAnimalBrain()
        {
            HerdAnimalTreeRoot =
                BT.Selector("Herd Brain",
                    LandAnimalBrain.LyingDownTree,
                    PerceptionBehaviors.Alert,
                    MovementBehaviors.Flee,
                    GroupBehaviors.SleepNearLeader,
                    LandAnimalBrain.FindAndEatPlants,
                    GroupBehaviors.StayNearLeader(20f),
                    MovementBehaviors.TryReturnHome,
                    RelaxBehaviors.Relax,
                    MovementBehaviors.Wander);
        }
    }
}
