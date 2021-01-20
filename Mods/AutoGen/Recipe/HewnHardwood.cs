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
    [RequiresSkill(typeof(LoggingSkill), 1)] 
    public partial class HewnHardwoodRecipe :
        RecipeFamily
    {
        public HewnHardwoodRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "HewnHardwood",
                    Localizer.DoStr("Hewn Hardwood"),
                    new IngredientElement[]
                    {
               new IngredientElement("Hardwood", 2, typeof(LoggingSkill)),    
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<HardwoodHewnLogItem>(1),  
    
                    })
            };
            this.ExperienceOnCraft = 0.5f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(LoggingSkill), typeof(HewnHardwoodRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(HewnHardwoodRecipe), this.UILink(), 0.15f, typeof(LoggingSkill));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Hewn Hardwood"), typeof(HewnHardwoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
