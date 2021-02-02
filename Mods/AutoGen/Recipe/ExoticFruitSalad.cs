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
    [RequiresSkill(typeof(CookingSkill), 1)] 
    public partial class ExoticFruitSaladRecipe :
        RecipeFamily
    {
        public ExoticFruitSaladRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ExoticFruitSalad",
                    Localizer.DoStr("Exotic Fruit Salad"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(PricklyPearFruitItem), 10, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)), 
               new IngredientElement(typeof(PumpkinItem), 6, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<FruitSaladItem>(1),  
    
                    })
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(CookingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ExoticFruitSaladRecipe), 4, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Exotic Fruit Salad"), typeof(ExoticFruitSaladRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
