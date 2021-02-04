// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using Eco.Gameplay.AI;
    using Eco.Mods.Organisms.Behaviors;
    using Eco.Shared.States;
    using Eco.Shared.Utils;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;

    public class FishBrain : LandAnimalBrain
    {
        public override Behavior<Animal> RootBehavior(Animal animal) => FishTreeRoot;
        private static readonly Behavior<Animal> FishTreeRoot;
        static FishBrain()
        {
            const float ChanceToWander = 0.7f;
            FishTreeRoot =
                BT.Selector("Fish Brain",
                    BT.If("Try Swim", x => (!x.IsStunned, $"available for swimming"),
                        BT.Selector("Swimming",
                            MovementBehaviors.SwimFlee,
                            BT.If("Try Return Home", MovementBehaviors.ShouldReturnHome,
                                MovementBehaviors.SwimWanderHome),
                            BT.If("Swim Wander", x => (RandomUtil.Chance(ChanceToWander), $"{ChanceToWander.ToString("P0")} chance"),
                                MovementBehaviors.SwimWander)
                        )
                    ),
                    RelaxBehaviors.Idle
                );
        }
    }
}
