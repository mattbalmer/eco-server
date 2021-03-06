﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Raw Fish")]
    [Weight(100)]
    [Ecopedia("Food", "Meat", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RawFishItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A fatty cut of raw fish.");
        
        public override float Calories                  => 200;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 3, Protein = 7, Vitamins = 0};
    }

}
