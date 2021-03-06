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

    [RequiresSkill(typeof(MasonrySkill), 4)]      
    public partial class BasicUpgradeLvl2Recipe :
        RecipeFamily
    {
        public BasicUpgradeLvl2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "BasicUpgradeLvl2",
                    Localizer.DoStr("Basic Upgrade 2"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(MortarItem), 20, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),   
              new IngredientElement("MortaredStone", 20, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),   
               new IngredientElement(typeof(BasicUpgradeLvl1Item), 1, true),  
                    },
                    new CraftingElement[]
                    {
                        new CraftingElement<BasicUpgradeLvl2Item>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 4;  

            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MasonrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(BasicUpgradeLvl2Recipe), 4, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Basic Upgrade 2"), typeof(BasicUpgradeLvl2Recipe));

            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Basic Upgrade 2")]
    [Weight(1)]      
    [Ecopedia("Upgrade Modules", "Basic Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Upgrade", 1)]
    [Tag("BasicUpgrade", 1)]                                 
    public partial class BasicUpgradeLvl2Item :
        EfficiencyModule 
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Basic Upgrade 2"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Basic Upgrade that increases crafting efficiency."); } }

        public BasicUpgradeLvl2Item() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.75f          
        ) { }
    }
}
