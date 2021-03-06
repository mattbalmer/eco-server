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
    [LocDisplayName("Sugar")]
    [Weight(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SugarItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Sugar");
        public override LocString DisplayDescription    => Localizer.DoStr("Even sweet lovers don't eat sugar plain.");
        
        public override float Calories                  => 50;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 15, Fat = 0, Protein = 0, Vitamins = 0};
    }

    [RequiresSkill(typeof(MillingSkill), 1)]
    public partial class SugarRecipe : RecipeFamily
    {
        public SugarRecipe()
        {
            var product = new Recipe(
                "Sugar",
                Localizer.DoStr("Sugar"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(HuckleberriesItem), 8, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),   
                },
                new CraftingElement<SugarItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SugarRecipe), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Sugar"), typeof(SugarRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
