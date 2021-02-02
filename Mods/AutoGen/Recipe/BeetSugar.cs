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
    [RequiresSkill(typeof(MillingSkill), 1)] 
    public partial class BeetSugarRecipe :
        RecipeFamily
    {
        public BeetSugarRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "BeetSugar",
                    Localizer.DoStr("Beet Sugar"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(BeetItem), 6, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<SugarItem>(3),  
    
                    })
            };
            this.ExperienceOnCraft = 0.5f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(MillingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeetSugarRecipe), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Beet Sugar"), typeof(BeetSugarRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
