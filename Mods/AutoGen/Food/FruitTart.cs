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
    [LocDisplayName("Fruit Tart")]
    [Weight(400)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FruitTartItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A sweet pastry that is great for breakfast or anytime you need a quick boost in energy.");
        
        public override float Calories                  => 800;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 14, Fat = 9, Protein = 5, Vitamins = 20};
    }

    [RequiresSkill(typeof(AdvancedBakingSkill), 1)]
    public partial class FruitTartRecipe : RecipeFamily
    {
        public FruitTartRecipe()
        {
            var product = new Recipe(
                "FruitTart",
                Localizer.DoStr("Fruit Tart"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(PastryDoughItem), 1, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),   
                    new IngredientElement("Fruit", 4, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),   
                },
                new CraftingElement<FruitTartItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedBakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FruitTartRecipe), 2, typeof(AdvancedBakingSkill), typeof(AdvancedBakingFocusedSpeedTalent), typeof(AdvancedBakingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Fruit Tart"), typeof(FruitTartRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
