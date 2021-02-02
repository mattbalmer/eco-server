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
    [LocDisplayName("Flatbread")]
    [Weight(200)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FlatbreadItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Without any leavening the flatbread isn't very puffy. But it's still tasty.");
        
        public override float Calories                  => 500;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 17, Fat = 3, Protein = 8, Vitamins = 2};
    }

    [RequiresSkill(typeof(BakingSkill), 1)]
    public partial class FlatbreadRecipe : RecipeFamily
    {
        public FlatbreadRecipe()
        {
            var product = new Recipe(
                "Flatbread",
                Localizer.DoStr("Flatbread"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(FlourItem), 4, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),   
                },
                new CraftingElement<FlatbreadItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(BakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FlatbreadRecipe), 2, typeof(BakingSkill), typeof(BakingFocusedSpeedTalent), typeof(BakingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Flatbread"), typeof(FlatbreadRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
