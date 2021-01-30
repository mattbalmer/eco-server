﻿// Copyright (c) Strange Loop Games. All rights reserved.
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
    [LocDisplayName("Sweet Salad")]
    [Weight(400)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SweetSaladItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("The sweetness of the fruits happens to work well with the salad.");
        
        public override float Calories                  => 1100;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 18, Fat = 7, Protein = 9, Vitamins = 22};
    }

    [RequiresSkill(typeof(AdvancedCookingSkill), 3)]
    public partial class SweetSaladRecipe : RecipeFamily
    {
        public SweetSaladRecipe()
        {
            var product = new Recipe(
                "SweetSalad",
                Localizer.DoStr("Sweet Salad"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BasicSaladItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(FruitSaladItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(SimpleSyrupItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),   
                },
                new CraftingElement<SweetSaladItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SweetSaladRecipe), 6, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Sweet Salad"), typeof(SweetSaladRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}
