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
    [LocDisplayName("Charred Cactus Fruit")]
    [Weight(100)]
    [Tag("CharredFruit", 1)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CharredCactusFruitItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Blackened cactus fruit. A favorite of early desert settlers.");
        
        public override float Calories                  => 200;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 4, Fat = 2, Protein = 0, Vitamins = 6};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 0)]
    public partial class CharredCactusFruitRecipe : RecipeFamily
    {
        public CharredCactusFruitRecipe()
        {
            var product = new Recipe(
                "CharredCactusFruit",
                Localizer.DoStr("Charred Cactus Fruit"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(GiantCactusFruitItem), 1, true),  
                },
                new CraftingElement<CharredCactusFruitItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredCactusFruitRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Charred Cactus Fruit"), typeof(CharredCactusFruitRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
