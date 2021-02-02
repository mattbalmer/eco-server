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
    [LocDisplayName("Cornmeal")]
    [Weight(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CornmealItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Cornmeal");
        public override LocString DisplayDescription    => Localizer.DoStr("Dried and ground corn; it's like a courser flour.");
        
        public override float Calories                  => 60;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 9, Fat = 3, Protein = 3, Vitamins = 0};
    }

    [RequiresSkill(typeof(MillingSkill), 1)]
    public partial class CornmealRecipe : RecipeFamily
    {
        public CornmealRecipe()
        {
            var product = new Recipe(
                "Cornmeal",
                Localizer.DoStr("Cornmeal"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CornItem), 4, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),   
                },
                new CraftingElement<CornmealItem>(1),
                new CraftingElement<CerealGermItem>(2f)  
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CornmealRecipe), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Cornmeal"), typeof(CornmealRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
