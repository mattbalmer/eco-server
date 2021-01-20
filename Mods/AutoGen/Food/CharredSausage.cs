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
    [LocDisplayName("Charred Sausage")]
    [Weight(500)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CharredSausageItem : FoodItem
    {
        public override LocString DisplayDescription            { get { return Localizer.DoStr("The uneven flame might be mediocre for cooking, but the open flame imparts a great flavor."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 14, Protein = 10, Vitamins = 0};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]    
    public partial class CharredSausageRecipe :
        RecipeFamily
    {
        public CharredSausageRecipe()
        {
            var product = new Recipe(
                "CharredSausage",
                Localizer.DoStr("Charred Sausage"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(RawSausageItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                    new CraftingElement<CharredSausageItem>(1),  
                    new CraftingElement<TallowItem>(1f)  
                
            );
            this.Initialize(Localizer.DoStr("Charred Sausage"), typeof(CharredSausageRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill), typeof(CharredSausageRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredSausageRecipe), this.UILink(), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Charred Sausage"), typeof(CharredSausageRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
