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
    [LocDisplayName("Campfire Roast")]
    [Weight(500)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CampfireRoastItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("The uneven flame might be mediocre for cooking, but the open flame imparts a great flavor.");
        
        public override float Calories                  => 1000;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 12, Protein = 16, Vitamins = 0};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 2)]
    public partial class CampfireRoastRecipe : RecipeFamily
    {
        public CampfireRoastRecipe()
        {
            var product = new Recipe(
                "CampfireRoast",
                Localizer.DoStr("Campfire Roast"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(RawRoastItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                new CraftingElement<CampfireRoastItem>(1),
                new CraftingElement<TallowItem>(1f)  
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireRoastRecipe), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Campfire Roast"), typeof(CampfireRoastRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
