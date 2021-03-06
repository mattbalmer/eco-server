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
    [LocDisplayName("Charred Camas Bulb")]
    [Weight(100)]
    [Tag("CharredVegetable", 1)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CharredCamasBulbItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A fibrous and sweet treat much like a sweet potato, though slightly blackened over the heat of a campfire.");
        
        public override float Calories                  => 350;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 2, Fat = 6, Protein = 3, Vitamins = 1};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 0)]
    public partial class CharredCamasBulbRecipe : RecipeFamily
    {
        public CharredCamasBulbRecipe()
        {
            var product = new Recipe(
                "CharredCamasBulb",
                Localizer.DoStr("Charred Camas Bulb"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CamasBulbItem), 1, true),  
                },
                new CraftingElement<CharredCamasBulbItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredCamasBulbRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Charred Camas Bulb"), typeof(CharredCamasBulbRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
