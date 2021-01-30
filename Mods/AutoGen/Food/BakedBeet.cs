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
    [LocDisplayName("Baked Beet")]
    [Weight(300)]
    [Tag("BakedVegetable", 1)]
    [Tag("BakedFood", 1)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BakedBeetItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Baked beets that retain more nutrients than more simple methods of cooking.");
        
        public override float Calories                  => 700;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 8, Fat = 4, Protein = 4, Vitamins = 12};
    }

    [RequiresSkill(typeof(BakingSkill), 1)]
    public partial class BakedBeetRecipe : RecipeFamily
    {
        public BakedBeetRecipe()
        {
            var product = new Recipe(
                "BakedBeet",
                Localizer.DoStr("Baked Beet"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BeetItem), 4, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),   
                },
                new CraftingElement<BakedBeetItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(BakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BakedBeetRecipe), 2, typeof(BakingSkill), typeof(BakingFocusedSpeedTalent), typeof(BakingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Baked Beet"), typeof(BakedBeetRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
