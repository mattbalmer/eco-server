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
    [RequiresSkill(typeof(CampfireCookingSkill), 0)] 
    public partial class CampfireTroutRecipe :
        RecipeFamily
    {
        public CampfireTroutRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CampfireTrout",
                    Localizer.DoStr("Campfire Trout"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(TroutItem), 1, true),  
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<CharredFishItem>(2),  
    
                    })
            };
            this.ExperienceOnCraft = 0.5f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(CampfireCookingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampfireTroutRecipe), 1.2f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Campfire Trout"), typeof(CampfireTroutRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
