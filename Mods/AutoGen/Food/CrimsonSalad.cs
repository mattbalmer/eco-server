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
    [LocDisplayName("Crimson Salad")]
    [Weight(400)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CrimsonSaladItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Just in case you want to eat red things without eating meat.");
        
        public override float Calories                  => 1100;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 15, Fat = 12, Protein = 9, Vitamins = 20};
    }

    [RequiresSkill(typeof(AdvancedCookingSkill), 3)]
    public partial class CrimsonSaladRecipe : RecipeFamily
    {
        public CrimsonSaladRecipe()
        {
            var product = new Recipe(
                "CrimsonSalad",
                Localizer.DoStr("Crimson Salad"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BasicSaladItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(InfusedOilItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(CharredBeetItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(TomatoItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),   
                },
                new CraftingElement<CrimsonSaladItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrimsonSaladRecipe), 6, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Crimson Salad"), typeof(CrimsonSaladRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}
