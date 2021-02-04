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
    [LocDisplayName("Charred Beans")]
    [Weight(100)]
    [Tag("CharredVegetable", 1)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CharredBeansItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A mushy mixture that can serve somewhat as a replacement protein in a meatless diet.");
        
        public override float Calories                  => 350;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 1, Fat = 3, Protein = 8, Vitamins = 0};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 0)]
    public partial class CharredBeansRecipe : RecipeFamily
    {
        public CharredBeansRecipe()
        {
            var product = new Recipe(
                "CharredBeans",
                Localizer.DoStr("Charred Beans"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BeansItem), 1, true),  
                },
                new CraftingElement<CharredBeansItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredBeansRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Charred Beans"), typeof(CharredBeansRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
