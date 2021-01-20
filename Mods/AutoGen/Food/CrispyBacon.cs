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
    [LocDisplayName("Crispy Bacon")]
    [Weight(400)]
    [Ecopedia("Food", "Meat", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CrispyBaconItem : FoodItem
    {
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Crispy Bacon"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Give me all the bacon and eggs you have."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 26, Protein = 18, Vitamins = 0};
        public override float Calories                          { get { return 800; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CookingSkill), 3)]    
    public partial class CrispyBaconRecipe :
        RecipeFamily
    {
        public CrispyBaconRecipe()
        {
            var product = new Recipe(
                "CrispyBacon",
                Localizer.DoStr("Crispy Bacon"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(RawBaconItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),   
                },
                    new CraftingElement<CrispyBaconItem>(1),  
                    new CraftingElement<TallowItem>(4f)  
                
            );
            this.Initialize(Localizer.DoStr("Crispy Bacon"), typeof(CrispyBaconRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill), typeof(CrispyBaconRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrispyBaconRecipe), this.UILink(), 4, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Crispy Bacon"), typeof(CrispyBaconRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}
