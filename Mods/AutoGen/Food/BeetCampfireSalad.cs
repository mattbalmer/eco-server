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
    [LocDisplayName("Beet Campfire Salad")]
    [Weight(200)]
    [Tag("CampfireSalad", 1)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeetCampfireSaladItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A myriad of plants that make a healthy and odd blend.");
        
        public override float Calories                  => 900;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 8, Fat = 4, Protein = 5, Vitamins = 11};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]
    public partial class BeetCampfireSaladRecipe : RecipeFamily
    {
        public BeetCampfireSaladRecipe()
        {
            var product = new Recipe(
                "BeetCampfireSalad",
                Localizer.DoStr("Beet Campfire Salad"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BeetGreensItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(BeetItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                    new IngredientElement("Fruit", 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                new CraftingElement<BeetCampfireSaladItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeetCampfireSaladRecipe), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Beet Campfire Salad"), typeof(BeetCampfireSaladRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
