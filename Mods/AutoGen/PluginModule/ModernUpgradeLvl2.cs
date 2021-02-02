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

    [RequiresSkill(typeof(IndustrySkill), 4)]      
    public partial class ModernUpgradeLvl2Recipe :
        RecipeFamily
    {
        public ModernUpgradeLvl2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ModernUpgradeLvl2",
                    Localizer.DoStr("Modern Upgrade 2"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(SteelPlateItem), 16, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
               new IngredientElement(typeof(SteelGearItem), 10, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),   
               new IngredientElement(typeof(ModernUpgradeLvl1Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<ModernUpgradeLvl2Item>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(IndustrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernUpgradeLvl2Recipe), 6, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Modern Upgrade 2"), typeof(ModernUpgradeLvl2Recipe));

            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Modern Upgrade 2")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Modern Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    [Tag("ModernUpgrade", 1)]                                 
    public partial class ModernUpgradeLvl2Item :
        EfficiencyModule 
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Modern Upgrade 2"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Modern Upgrade with great efficiency increase."); } }

        public ModernUpgradeLvl2Item() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.75f          
        ) { }
    }
}
