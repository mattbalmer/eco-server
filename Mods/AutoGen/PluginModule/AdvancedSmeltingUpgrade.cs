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

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 7)]      
    public partial class AdvancedSmeltingUpgradeRecipe :
        RecipeFamily
    {
        public AdvancedSmeltingUpgradeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "AdvancedSmeltingUpgrade",
                    Localizer.DoStr("Advanced Smelting Advanced Upgrade"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(AdvancedUpgradeLvl4Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<AdvancedSmeltingUpgradeItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(10000, typeof(AdvancedSmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(AdvancedSmeltingUpgradeRecipe), 15, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Advanced Smelting Advanced Upgrade"), typeof(AdvancedSmeltingUpgradeRecipe));

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Advanced Smelting Advanced Upgrade")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    public partial class AdvancedSmeltingUpgradeItem :
        EfficiencyModule 
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced Upgrade that greatly increases efficiency when crafting Advanced Smelting recipes."); } }

        public AdvancedSmeltingUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.5f + 0.05f, 
            typeof(AdvancedSmeltingSkill),   
            0.5f          
        ) { }
    }
}
