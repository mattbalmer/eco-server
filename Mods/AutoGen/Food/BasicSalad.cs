// Copyright (c) Strange Loop Games. All rights reserved.
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
    [LocDisplayName("Basic Salad")]
    [Weight(300)]
    [Tag("Salad", 1)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BasicSaladItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A seemingly random assortment of wild plants that form a sort of salad.");
        
        public override float Calories                  => 800;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 18, Fat = 4, Protein = 6, Vitamins = 10};
    }

}
