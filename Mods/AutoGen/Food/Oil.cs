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
    [LocDisplayName("Oil")]
    [Weight(100)]
    [Fuel(4000)][Tag("Fuel")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Fat", 1)]
    public partial class OilItem : FoodItem
    {
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Oil"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A plant fat extracted for use in cooking."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 15, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 120; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillingSkill), 1)]    
    public partial class OilRecipe :
        RecipeFamily
    {
        public OilRecipe()
        {
            var product = new Recipe(
                "Oil",
                Localizer.DoStr("Oil"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(CerealGermItem), 12, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),   
                },
                    new CraftingElement<OilItem>(1)  
                
            );
            this.Initialize(Localizer.DoStr("Oil"), typeof(OilRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill), typeof(OilRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe), this.UILink(), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Oil"), typeof(OilRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
