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
    [LocDisplayName("Flour")]
    [Weight(200)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FlourItem : FoodItem
    {
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Flour"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A fine, milled wheat product that's useful for all baking."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 15, Fat = 0, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 50; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillingSkill), 1)]    
    public partial class FlourRecipe :
        RecipeFamily
    {
        public FlourRecipe()
        {
            var product = new Recipe(
                "Flour",
                Localizer.DoStr("Flour"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(WheatItem), 2, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),   
                },
                    new CraftingElement<FlourItem>(1),  
                    new CraftingElement<CerealGermItem>(1f)  
                
            );
            this.Initialize(Localizer.DoStr("Flour"), typeof(FlourRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill), typeof(FlourRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(FlourRecipe), this.UILink(), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Flour"), typeof(FlourRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
