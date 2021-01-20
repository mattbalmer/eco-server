﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.EcopediaRoot;

    [Serialized]
    [LocDisplayName("Fern Campfire Salad")]
    [Weight(200)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("CampfireSalad", 1)]
    public partial class FernCampfireSaladItem : FoodItem
    {
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A myriad of plants that make a healthy and odd blend."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 1, Protein = 5, Vitamins = 13};
        public override float Calories                          { get { return 900; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]    
    public partial class FernCampfireSaladRecipe :
        RecipeFamily
    {
        public FernCampfireSaladRecipe()
        {
            var product = new Recipe(
                "FernCampfireSalad",
                Localizer.DoStr("Fern Campfire Salad"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(FiddleheadsItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)), 
            new IngredientElement(typeof(HuckleberriesItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
            new IngredientElement("Vegetable", 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                    new CraftingElement<FernCampfireSaladItem>(1)  
                
            );
            this.Initialize(Localizer.DoStr("Fern Campfire Salad"), typeof(FernCampfireSaladRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill), typeof(FernCampfireSaladRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(FernCampfireSaladRecipe), this.UILink(), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Fern Campfire Salad"), typeof(FernCampfireSaladRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
