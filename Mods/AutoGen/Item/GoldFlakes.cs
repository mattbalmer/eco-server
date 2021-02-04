﻿// Copyright (c) Strange Loop Games. All rights reserved.
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
    [RequiresSkill(typeof(ElectronicsSkill), 1)]      
    public partial class GoldFlakesRecipe :
        RecipeFamily
    {
        public GoldFlakesRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GoldFlakes",
                    Localizer.DoStr("Gold Flakes"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(GoldBarItem), 2, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GoldFlakesItem>(4),  
                    }
                )
            };


            this.ExperienceOnCraft = 1;  

            this.LaborInCalories = CreateLaborInCaloriesValue(120, typeof(ElectronicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(GoldFlakesRecipe), 0.8f, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Gold Flakes"), typeof(GoldFlakesRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Gold Flakes")]
    [Weight(500)]      
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class GoldFlakesItem :
    Item                                    
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Gold Flakes"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A highly efficient conductor for delicate electronics."); } }
    }
}
