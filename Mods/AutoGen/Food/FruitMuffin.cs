// Copyright (c) Strange Loop Games. All rights reserved.
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
    [LocDisplayName("Fruit Muffin")]
    [Weight(200)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FruitMuffinItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A soft, slightly sweet bread studded with juicy fruits.");
        
        public override float Calories                  => 800;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 10, Fat = 4, Protein = 5, Vitamins = 16};
    }

    [RequiresSkill(typeof(BakingSkill), 1)]
    public partial class FruitMuffinRecipe : RecipeFamily
    {
        public FruitMuffinRecipe()
        {
            var product = new Recipe(
                "FruitMuffin",
                Localizer.DoStr("Fruit Muffin"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(FlourItem), 4, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),   
                    new IngredientElement("Fruit", 4, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),   
                },
                new CraftingElement<FruitMuffinItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(BakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FruitMuffinRecipe), 2, typeof(BakingSkill), typeof(BakingFocusedSpeedTalent), typeof(BakingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Fruit Muffin"), typeof(FruitMuffinRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
