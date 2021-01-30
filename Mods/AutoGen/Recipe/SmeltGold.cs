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
    [RequiresSkill(typeof(SmeltingSkill), 1)] 
    public partial class SmeltGoldRecipe :
        RecipeFamily
    {
        public SmeltGoldRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SmeltGold",
                    Localizer.DoStr("Smelt Gold"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(GoldConcentrateItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<GoldBarItem>(3),  
               new CraftingElement<SlagItem>(typeof(SmeltingSkill), 2, typeof(SmeltingLavishResourcesTalent)),     
                    })
            };
            this.ExperienceOnCraft = 2;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(SmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmeltGoldRecipe), 4, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Smelt Gold"), typeof(SmeltGoldRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
