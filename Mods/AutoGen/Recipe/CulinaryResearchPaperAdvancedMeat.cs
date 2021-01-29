﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(BakingSkill), 1)] 
    public partial class CulinaryResearchPaperAdvancedMeatRecipe :
        RecipeFamily
    {
        public CulinaryResearchPaperAdvancedMeatRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CulinaryResearchPaperAdvancedMeat",
                    Localizer.DoStr("Culinary Research Paper Advanced Meat"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(BakedMeatItem), 20, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)), 
               new IngredientElement(typeof( SimmeredMeatItem), 10, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<CulinaryResearchPaperAdvancedItem>(1),  
    
                    })
            };
            this.ExperienceOnCraft = 0.5f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(BakingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CulinaryResearchPaperAdvancedMeatRecipe), 1, typeof(BakingSkill), typeof(BakingFocusedSpeedTalent), typeof(BakingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Culinary Research Paper Advanced Meat"), typeof(CulinaryResearchPaperAdvancedMeatRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
