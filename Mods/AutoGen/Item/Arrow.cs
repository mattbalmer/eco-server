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
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    public partial class ArrowRecipe :
        RecipeFamily
    {
        public ArrowRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Arrow",
                    Localizer.DoStr("Arrow"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 1),   
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<ArrowItem>(4),  
                    }
                )
            };



            this.LaborInCalories = CreateLaborInCaloriesValue(30); 
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Arrow"), typeof(ArrowRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Arrow")]
    [Weight(10)]      
    [Fuel(500)][Tag("Fuel")]          
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Burnable Fuel", 1)]                                 
    public partial class ArrowItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Use with the bow to hunt for food (or amaze your friends by shooting apples off of their heads)."); } }
    }
}
