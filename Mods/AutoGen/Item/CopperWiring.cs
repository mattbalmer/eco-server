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
    [RequiresSkill(typeof(MechanicsSkill), 1)]      
    public partial class CopperWiringRecipe :
        RecipeFamily
    {
        public CopperWiringRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CopperWiring",
                    Localizer.DoStr("Copper Wiring"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(CopperBarItem), 4, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<CopperWiringItem>(2),  
                    }
                )
            };


            this.ExperienceOnCraft = 1;  

            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MechanicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperWiringRecipe), 0.4f, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Copper Wiring"), typeof(CopperWiringRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Copper Wiring")]
    [Weight(200)]      
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class CopperWiringItem :
    Item                                    
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Copper Wiring"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A length of copper conductive wire useful for a variety of purposes."); } }
    }
}
