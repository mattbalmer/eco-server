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

    [RequiresSkill(typeof(CarpentrySkill), 7)]      
    public partial class CarpentryAdvancedUpgradeRecipe :
        RecipeFamily
    {
        public CarpentryAdvancedUpgradeRecipe()
        {
            this.Initialize(Localizer.DoStr("Carpentry Advanced Upgrade"), typeof(CarpentryAdvancedUpgradeRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CarpentryAdvancedUpgrade",
                    Localizer.DoStr("Carpentry Advanced Upgrade"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(AdvancedUpgradeLvl4Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<CarpentryAdvancedUpgradeItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(10000, typeof(CarpentrySkill), typeof(CarpentryAdvancedUpgradeRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CarpentryAdvancedUpgradeRecipe), this.UILink(), 15, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Carpentry Advanced Upgrade"), typeof(CarpentryAdvancedUpgradeRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Carpentry Advanced Upgrade")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    public partial class CarpentryAdvancedUpgradeItem :
        EfficiencyModule 
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced Upgrade that greatly increases efficiency when crafting Carpentry recipes."); } }

        public CarpentryAdvancedUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.5f + 0.05f, 
            typeof(CarpentrySkill),   
            0.5f          
        ) { }
    }
}
