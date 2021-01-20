// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    public partial class DirtRampRecipe :
        RecipeFamily
    {
        public DirtRampRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "DirtRamp",
                    Localizer.DoStr("Dirt Ramp"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(DirtItem), 6),   
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<DirtRampItem>(),  
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(20); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dirt Ramp"), typeof(DirtRampRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Constructed]
    [Road(1f)]                                           
    public partial class DirtRampBlock :
        Block            
    {
    }

}
