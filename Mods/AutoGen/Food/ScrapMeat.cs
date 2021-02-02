// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Scrap Meat")]
    [Weight(10)]
    [Ecopedia("Food", "Meat", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ScrapMeatItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Scrap Meat");
        public override LocString DisplayDescription    => Localizer.DoStr("Chunks of extra meat.");
        
        public override float Calories                  => 50;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 5, Protein = 5, Vitamins = 0};
    }

    [RequiresSkill(typeof(ButcherySkill), 1)]
    public partial class ScrapMeatRecipe : RecipeFamily
    {
        public ScrapMeatRecipe()
        {
            var product = new Recipe(
                "ScrapMeat",
                Localizer.DoStr("Scrap Meat"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(RawMeatItem), 1, typeof(ButcherySkill), typeof(ButcheryLavishResourcesTalent)),   
                },
                new CraftingElement<ScrapMeatItem>(3)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ButcherySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ScrapMeatRecipe), 0.5f, typeof(ButcherySkill), typeof(ButcheryFocusedSpeedTalent), typeof(ButcheryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Scrap Meat"), typeof(ScrapMeatRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}
