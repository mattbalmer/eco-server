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

    [RequiresSkill(typeof(FarmingSkill), 7)]      
    public partial class FarmingUpgradeRecipe :
        RecipeFamily
    {
        public FarmingUpgradeRecipe()
        {
            this.Initialize(Localizer.DoStr("Farming Basic Upgrade"), typeof(FarmingUpgradeRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "FarmingUpgrade",
                    Localizer.DoStr("Farming Basic Upgrade"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(BasicUpgradeLvl4Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<FarmingUpgradeItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(5000, typeof(FarmingSkill), typeof(FarmingUpgradeRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(FarmingUpgradeRecipe), this.UILink(), 10, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Farming Basic Upgrade"), typeof(FarmingUpgradeRecipe));

            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Farming Basic Upgrade")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    public partial class FarmingUpgradeItem :
        EfficiencyModule 
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Basic Upgrade that greatly increases efficiency when crafting Farming recipes."); } }

        public FarmingUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.5f + 0.05f, 
            typeof(FarmingSkill),   
            0.5f          
        ) { }
    }
}
