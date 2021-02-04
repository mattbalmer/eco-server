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
    [LocDisplayName("Raw Roast")]
    [Weight(500)]
    [Ecopedia("Food", "Meat", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RawRoastItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A trussed roast tied and ready to be cooked.");
        
        public override float Calories                  => 600;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 5, Protein = 6, Vitamins = 0};
    }

    [RequiresSkill(typeof(ButcherySkill), 1)]
    public partial class RawRoastRecipe : RecipeFamily
    {
        public RawRoastRecipe()
        {
            var product = new Recipe(
                "RawRoast",
                Localizer.DoStr("Raw Roast"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(RawMeatItem), 2, typeof(ButcherySkill), typeof(ButcheryLavishResourcesTalent)),   
                },
                new CraftingElement<RawRoastItem>(1),
                new CraftingElement<ScrapMeatItem>(3f)  
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ButcherySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RawRoastRecipe), 0.8f, typeof(ButcherySkill), typeof(ButcheryFocusedSpeedTalent), typeof(ButcheryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Raw Roast"), typeof(RawRoastRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}
