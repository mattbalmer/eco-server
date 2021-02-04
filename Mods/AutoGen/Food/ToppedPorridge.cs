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
    [LocDisplayName("Topped Porridge")]
    [Weight(200)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ToppedPorridgeItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Topped Porridge");
        public override LocString DisplayDescription    => Localizer.DoStr("A thick gruel of boiled grains with a dash of fruity flavor.");
        
        public override float Calories                  => 700;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 10, Fat = 0, Protein = 4, Vitamins = 10};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]
    public partial class ToppedPorridgeRecipe : RecipeFamily
    {
        public ToppedPorridgeRecipe()
        {
            var product = new Recipe(
                "ToppedPorridge",
                Localizer.DoStr("Topped Porridge"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(BoiledGrainsItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                    new IngredientElement("Fruit", 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                new CraftingElement<ToppedPorridgeItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ToppedPorridgeRecipe), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Topped Porridge"), typeof(ToppedPorridgeRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
