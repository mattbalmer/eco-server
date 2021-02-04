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
    [LocDisplayName("Bannock")]
    [Weight(100)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BannockItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A dense whole wheat unleavened bread.");
        
        public override float Calories                  => 700;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 14, Fat = 7, Protein = 3, Vitamins = 0};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]
    public partial class BannockRecipe : RecipeFamily
    {
        public BannockRecipe()
        {
            var product = new Recipe(
                "Bannock",
                Localizer.DoStr("Bannock"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(WheatItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                    new IngredientElement("Fat", 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                new CraftingElement<BannockItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BannockRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Bannock"), typeof(BannockRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
