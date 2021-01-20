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
    [LocDisplayName("Leavened Dough")]
    [Weight(800)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class LeavenedDoughItem : FoodItem
    {
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Leavened dough with added yeast that rises when baked."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 13, Protein = 18, Vitamins = 5};
        public override float Calories                          { get { return 10; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(AdvancedBakingSkill), 1)]    
    public partial class LeavenedDoughRecipe :
        RecipeFamily
    {
        public LeavenedDoughRecipe()
        {
            var product = new Recipe(
                "LeavenedDough",
                Localizer.DoStr("Leavened Dough"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(FlourItem), 4, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)), 
            new IngredientElement(typeof(YeastItem), 1, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),   
                },
                    new CraftingElement<LeavenedDoughItem>(1)  
                
            );
            this.Initialize(Localizer.DoStr("Leavened Dough"), typeof(LeavenedDoughRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedBakingSkill), typeof(LeavenedDoughRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(LeavenedDoughRecipe), this.UILink(), 0.4f, typeof(AdvancedBakingSkill), typeof(AdvancedBakingFocusedSpeedTalent), typeof(AdvancedBakingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Leavened Dough"), typeof(LeavenedDoughRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
