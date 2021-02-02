// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Milk")]
    [Category("Hidden")]
    [Weight(10)]
    public partial class MilkItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Milk");
        public override LocString DisplayDescription    => Localizer.DoStr("Milk, although maybe not from an animal.");
        
        public override float Calories                  => 120;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 3, Fat = 7, Protein = 10, Vitamins = 0};
    }

}
