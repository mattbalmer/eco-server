// Copyright (c) Strange Loop Games. All rights reserved.
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
    [RequiresSkill(typeof(MasonrySkill), 1)] 
    public partial class BakedMortarRecipe :
        RecipeFamily
    {
        public BakedMortarRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "BakedMortar",
                    Localizer.DoStr("Baked Mortar"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(WoodPulpItem), 5, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<MortarItem>(1),  
    
                    })
            };
            this.ExperienceOnCraft = 0.5f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MasonrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(BakedMortarRecipe), 0.1f, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Baked Mortar"), typeof(BakedMortarRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
