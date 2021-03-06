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
    [LocDisplayName("Transglutaminase")]
    [Weight(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class TransglutaminaseItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Any enzyme that can be used to bond proteins together.");
        
        public override float Calories                  => 10;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
    }

    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 1)]
    public partial class TransglutaminaseRecipe : RecipeFamily
    {
        public TransglutaminaseRecipe()
        {
            var product = new Recipe(
                "Transglutaminase",
                Localizer.DoStr("Transglutaminase"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(ScrapMeatItem), 30, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),   
                },
                new CraftingElement<TransglutaminaseItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(TransglutaminaseRecipe), 8, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingFocusedSpeedTalent), typeof(CuttingEdgeCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Transglutaminase"), typeof(TransglutaminaseRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }
}
