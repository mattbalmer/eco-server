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
    [LocDisplayName("Macaroons")]
    [Weight(200)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class MacaroonsItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Macaroons");
        public override LocString DisplayDescription    => Localizer.DoStr("A small circular biscuit with a sweet huckleberry filling.");
        
        public override float Calories                  => 850;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 20, Fat = 14, Protein = 7, Vitamins = 16};
    }

    [RequiresSkill(typeof(AdvancedBakingSkill), 2)]
    public partial class MacaroonsRecipe : RecipeFamily
    {
        public MacaroonsRecipe()
        {
            var product = new Recipe(
                "Macaroons",
                Localizer.DoStr("Macaroons"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(PastryDoughItem), 2, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)), 
                    new IngredientElement(typeof(SugarItem), 5, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)), 
                    new IngredientElement(typeof(HuckleberryExtractItem), 1, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),   
                },
                new CraftingElement<MacaroonsItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedBakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MacaroonsRecipe), 3, typeof(AdvancedBakingSkill), typeof(AdvancedBakingFocusedSpeedTalent), typeof(AdvancedBakingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Macaroons"), typeof(MacaroonsRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
