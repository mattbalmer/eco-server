﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;

    public partial class SelfImprovementSkill
    {
        public override void OnReset(User user) { this.OnLevelChanged(user); }
        public override void OnLevelUp(User user) { this.OnLevelChanged(user); }

        private void OnLevelChanged(User user)
        {
            user.Stomach.ChangedMaxCalories();
            user.ChangedCarryWeight();
        }
    }
}
