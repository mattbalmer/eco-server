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
    [RequiresSkill(typeof(LoggingSkill), 6)]      
    public partial class CharcoalRecipe :
        RecipeFamily
    {
        public CharcoalRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Charcoal",
                    Localizer.DoStr("Charcoal"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 7, typeof(LoggingSkill)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<CharcoalItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 2;  

            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(LoggingSkill), typeof(CharcoalRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharcoalRecipe), this.UILink(), 4, typeof(LoggingSkill));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Charcoal"), typeof(CharcoalRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Charcoal")]
    [Weight(1000)]      
    [Fuel(20000)][Tag("Fuel")]          
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Coal", 1)]
    [Tag("Burnable Fuel", 1)]                                 
    public partial class CharcoalItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A black residue, consisting of carbon and any remaining ash."); } }
    }
}
