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
    [LocDisplayName("Elk Wellington")]
    [Weight(500)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ElkWellingtonItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A prime cut of meat surrounded by pastry.");
        
        public override float Calories                  => 1400;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 12, Fat = 22, Protein = 20, Vitamins = 8};
    }

    [RequiresSkill(typeof(AdvancedBakingSkill), 3)]
    public partial class ElkWellingtonRecipe : RecipeFamily
    {
        public ElkWellingtonRecipe()
        {
            var product = new Recipe(
                "ElkWellington",
                Localizer.DoStr("Elk Wellington"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(LeavenedDoughItem), 2, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)), 
                    new IngredientElement(typeof(PrimeCutItem), 4, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),   
                },
                new CraftingElement<ElkWellingtonItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedBakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElkWellingtonRecipe), 3, typeof(AdvancedBakingSkill), typeof(AdvancedBakingFocusedSpeedTalent), typeof(AdvancedBakingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Elk Wellington"), typeof(ElkWellingtonRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
