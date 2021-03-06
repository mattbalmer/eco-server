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
    [LocDisplayName("Field Campfire Stew")]
    [Weight(500)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FieldCampfireStewItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A thick stew chock-full of meat and charred vegetables. A suprisingly good combination.");
        
        public override float Calories                  => 1100;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 10, Fat = 8, Protein = 6, Vitamins = 4};
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 3)]
    public partial class FieldCampfireStewRecipe : RecipeFamily
    {
        public FieldCampfireStewRecipe()
        {
            var product = new Recipe(
                "FieldCampfireStew",
                Localizer.DoStr("Field Campfire Stew"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(CornItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(TomatoItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                    new IngredientElement("Fat", 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                new CraftingElement<FieldCampfireStewItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FieldCampfireStewRecipe), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Field Campfire Stew"), typeof(FieldCampfireStewRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
