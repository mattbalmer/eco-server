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
    using Eco.Gameplay.Modules;
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

    [RequiresSkill(typeof(LoggingSkill), 7)]      
    public partial class LoggingBasicUpgradeRecipe :
        RecipeFamily
    {
        public LoggingBasicUpgradeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "LoggingBasicUpgrade",
                    Localizer.DoStr("Logging Basic Upgrade"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(BasicUpgradeLvl4Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<LoggingBasicUpgradeItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(5000, typeof(LoggingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(LoggingBasicUpgradeRecipe), 10, typeof(LoggingSkill));     
            this.Initialize(Localizer.DoStr("Logging Basic Upgrade"), typeof(LoggingBasicUpgradeRecipe));

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Logging Basic Upgrade")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    public partial class LoggingBasicUpgradeItem :
        EfficiencyModule 
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Basic Upgrade that greatly increases efficiency when crafting Logging recipes."); } }

        public LoggingBasicUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.5f + 0.05f, 
            typeof(LoggingSkill),   
            0.5f          
        ) { }
    }
}
