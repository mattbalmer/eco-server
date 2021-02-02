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

    [RequiresSkill(typeof(CompositesSkill), 6)]      
    public partial class ModernUpgradeLvl4Recipe :
        RecipeFamily
    {
        public ModernUpgradeLvl4Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ModernUpgradeLvl4",
                    Localizer.DoStr("Modern Upgrade 4"),
                    new IngredientElement[]
                    {
              new IngredientElement("CompositeLumber", 12, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),   
               new IngredientElement(typeof(ModernUpgradeLvl3Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<ModernUpgradeLvl4Item>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(2000, typeof(CompositesSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernUpgradeLvl4Recipe), 14, typeof(CompositesSkill), typeof(CompositesFocusedSpeedTalent), typeof(CompositesParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Modern Upgrade 4"), typeof(ModernUpgradeLvl4Recipe));

            CraftingComponent.AddRecipe(typeof(AdvancedCarpentryTableObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Modern Upgrade 4")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Modern Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    [Tag("ModernUpgrade", 1)]                                 
    public partial class ModernUpgradeLvl4Item :
        EfficiencyModule 
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Modern Upgrade 4"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Modern Upgrade with great efficiency increase."); } }

        public ModernUpgradeLvl4Item() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.55f          
        ) { }
    }
}
