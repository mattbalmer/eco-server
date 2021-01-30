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
    [LocDisplayName("Boiled Grains")]
    [Weight(100)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BoiledGrainsItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Boiled Grains");
        public override LocString DisplayDescription    => Localizer.DoStr("A dish of plain boiled grains that can be topped with fruit to make a nice tasting porridge.");
        
        public override float Calories                  => 350;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 9, Fat = 0, Protein = 2, Vitamins = 1};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 0)]
    public partial class BoiledGrainsRecipe : RecipeFamily
    {
        public BoiledGrainsRecipe()
        {
            var product = new Recipe(
                "BoiledGrains",
                Localizer.DoStr("Boiled Grains"),
                new IngredientElement[]
                {
                    new IngredientElement("Grain", 1, true),   
                },
                new CraftingElement<BoiledGrainsItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BoiledGrainsRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Boiled Grains"), typeof(BoiledGrainsRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
