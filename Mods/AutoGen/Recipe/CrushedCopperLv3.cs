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
    [RequiresSkill(typeof(MiningSkill), 2)] 
    public partial class CrushedCopperLv3Recipe :
        RecipeFamily
    {
        public CrushedCopperLv3Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CrushedCopperLv3",
                    Localizer.DoStr("Crushed Copper Lv3"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(CopperOreItem), 20, true),  
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<CrushedCopperOreItem>(5),  
    
                    })
            };
            this.ExperienceOnCraft = 0.5f;  
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(MiningSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrushedCopperLv3Recipe), 0.5f, typeof(MiningSkill));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Crushed Copper Lv3"), typeof(CrushedCopperLv3Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(JawCrusherObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
