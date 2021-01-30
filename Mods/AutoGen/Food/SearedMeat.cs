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
    [LocDisplayName("Seared Meat")]
    [Weight(500)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SearedMeatItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Seared Meat");
        public override LocString DisplayDescription    => Localizer.DoStr("A cut of perfectly seared steak.");
        
        public override float Calories                  => 600;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 4, Fat = 17, Protein = 19, Vitamins = 7};
    }

    [RequiresSkill(typeof(AdvancedCookingSkill), 1)]
    public partial class SearedMeatRecipe : RecipeFamily
    {
        public SearedMeatRecipe()
        {
            var product = new Recipe(
                "SearedMeat",
                Localizer.DoStr("Seared Meat"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(PrimeCutItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(InfusedOilItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),   
                },
                new CraftingElement<SearedMeatItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SearedMeatRecipe), 3, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Seared Meat"), typeof(SearedMeatRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}
