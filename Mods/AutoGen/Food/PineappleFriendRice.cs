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
    [LocDisplayName("Pineapple Friend Rice")]
    [Weight(150)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class PineappleFriendRiceItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A homely recipe made from a mix of cooked rice and fruit. Not only is it friendly, but it also happens to be pan fried.");
        
        public override float Calories                  => 620;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 20, Fat = 12, Protein = 12, Vitamins = 9};
    }

    [RequiresSkill(typeof(AdvancedCookingSkill), 1)]
    public partial class PineappleFriendRiceRecipe : RecipeFamily
    {
        public PineappleFriendRiceRecipe()
        {
            var product = new Recipe(
                "PineappleFriendRice",
                Localizer.DoStr("Pineapple Friend Rice"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CharredPineappleItem), 5, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(BoiledRiceItem), 5, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(ScrapMeatItem), 10, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),   
                },
                new CraftingElement<PineappleFriendRiceItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PineappleFriendRiceRecipe), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Pineapple Friend Rice"), typeof(PineappleFriendRiceRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}
