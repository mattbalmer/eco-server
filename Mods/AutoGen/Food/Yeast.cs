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
    [LocDisplayName("Yeast")]
    [Weight(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class YeastItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Yeast");
        public override LocString DisplayDescription    => Localizer.DoStr("A fungus that acts as an amazing leavening agent.");
        
        public override float Calories                  => 60;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 0, Protein = 8, Vitamins = 7};
    }

    [RequiresSkill(typeof(MillingSkill), 4)]
    public partial class YeastRecipe : RecipeFamily
    {
        public YeastRecipe()
        {
            var product = new Recipe(
                "Yeast",
                Localizer.DoStr("Yeast"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(SugarItem), 2, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),   
                },
                new CraftingElement<YeastItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(YeastRecipe), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Yeast"), typeof(YeastRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
