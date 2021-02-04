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

    [RequiresSkill(typeof(AdvancedBakingSkill), 7)]      
    public partial class AdvancedBakingUpgradeRecipe :
        RecipeFamily
    {
        public AdvancedBakingUpgradeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "AdvancedBakingUpgrade",
                    Localizer.DoStr("Advanced Baking Advanced Upgrade"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(AdvancedUpgradeLvl4Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<AdvancedBakingUpgradeItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(10000, typeof(AdvancedBakingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(AdvancedBakingUpgradeRecipe), 15, typeof(AdvancedBakingSkill), typeof(AdvancedBakingFocusedSpeedTalent), typeof(AdvancedBakingParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Advanced Baking Advanced Upgrade"), typeof(AdvancedBakingUpgradeRecipe));

            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Advanced Baking Advanced Upgrade")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    public partial class AdvancedBakingUpgradeItem :
        EfficiencyModule 
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced Upgrade that greatly increases efficiency when crafting Advanced Baking recipes."); } }

        public AdvancedBakingUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.5f + 0.05f, 
            typeof(AdvancedBakingSkill),   
            0.5f          
        ) { }
    }
}
