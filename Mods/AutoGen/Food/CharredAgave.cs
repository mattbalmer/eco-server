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
    [LocDisplayName("Charred Agave")]
    [Weight(100)]
    [Tag("CharredGreen", 1)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CharredAgaveItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Agave leaves that have been charred over a campfire");
        
        public override float Calories                  => 350;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 5, Fat = 3, Protein = 1, Vitamins = 3};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 0)]
    public partial class CharredAgaveRecipe : RecipeFamily
    {
        public CharredAgaveRecipe()
        {
            var product = new Recipe(
                "CharredAgave",
                Localizer.DoStr("Charred Agave"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(AgaveLeavesItem), 1, true),  
                },
                new CraftingElement<CharredAgaveItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredAgaveRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Charred Agave"), typeof(CharredAgaveRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
