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

    [RequiresSkill(typeof(MiningSkill), 7)]      
    public partial class MiningAdvancedUpgradeRecipe :
        RecipeFamily
    {
        public MiningAdvancedUpgradeRecipe()
        {
            this.Initialize(Localizer.DoStr("Mining Advanced Upgrade"), typeof(MiningAdvancedUpgradeRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "MiningAdvancedUpgrade",
                    Localizer.DoStr("Mining Advanced Upgrade"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(AdvancedUpgradeLvl4Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<MiningAdvancedUpgradeItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(10000, typeof(MiningSkill), typeof(MiningAdvancedUpgradeRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(MiningAdvancedUpgradeRecipe), this.UILink(), 15, typeof(MiningSkill));     
            this.Initialize(Localizer.DoStr("Mining Advanced Upgrade"), typeof(MiningAdvancedUpgradeRecipe));

            CraftingComponent.AddRecipe(typeof(ScreeningMachineObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Mining Advanced Upgrade")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    public partial class MiningAdvancedUpgradeItem :
        EfficiencyModule 
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced Upgrade that greatly increases efficiency when crafting Mining recipes."); } }

        public MiningAdvancedUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.5f + 0.05f, 
            typeof(MiningSkill),   
            0.5f          
        ) { }
    }
}
