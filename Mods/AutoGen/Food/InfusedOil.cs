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
    [LocDisplayName("Infused Oil")]
    [Weight(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class InfusedOilItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Infused Oil");
        public override LocString DisplayDescription    => Localizer.DoStr("Oil infused with flavor to enhance it.");
        
        public override float Calories                  => 120;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 12, Protein = 0, Vitamins = 3};
    }

    [RequiresSkill(typeof(AdvancedCookingSkill), 1)]
    public partial class InfusedOilRecipe : RecipeFamily
    {
        public InfusedOilRecipe()
        {
            var product = new Recipe(
                "InfusedOil",
                Localizer.DoStr("Infused Oil"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(OilItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(HuckleberryExtractItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),   
                },
                new CraftingElement<InfusedOilItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(InfusedOilRecipe), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Infused Oil"), typeof(InfusedOilRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}
