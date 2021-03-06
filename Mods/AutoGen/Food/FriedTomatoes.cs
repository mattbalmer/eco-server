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
    [LocDisplayName("Fried Tomatoes")]
    [Weight(200)]
    [Tag("FriedVegetable", 1)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FriedTomatoesItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Secret's in the sauce.");
        
        public override float Calories                  => 700;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 11, Fat = 8, Protein = 3, Vitamins = 2};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]
    public partial class FriedTomatoesRecipe : RecipeFamily
    {
        public FriedTomatoesRecipe()
        {
            var product = new Recipe(
                "FriedTomatoes",
                Localizer.DoStr("Fried Tomatoes"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(TomatoItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                    new IngredientElement("Fat", 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                new CraftingElement<FriedTomatoesItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FriedTomatoesRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Fried Tomatoes"), typeof(FriedTomatoesRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
