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
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(CarpentrySkill), 2)]      
    public partial class SoftwoodLumberRecipe :
        RecipeFamily
    {
        public SoftwoodLumberRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SoftwoodLumber",
                    Localizer.DoStr("Softwood Lumber"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SoftwoodHewnLogItem), 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
                    new IngredientElement(typeof(NailItem), 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<SoftwoodLumberItem>(),  
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(CarpentrySkill)); 
            this.ExperienceOnCraft = 1;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(SoftwoodLumberRecipe), 0.5f, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Softwood Lumber"), typeof(SoftwoodLumberRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(2)]                                          
    [RequiresSkill(typeof(CarpentrySkill), 2)]      
    public partial class SoftwoodLumberBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodLumberItem); } }  
    }

    [Serialized]
    [LocDisplayName("Softwood Lumber")]
    [MaxStackSize(40)]                           
    [Weight(10000)]      
    [Fuel(4000)][Tag("Fuel")]          
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Lumber", 1)]
    [Tag("Burnable Fuel", 1)]
    [Tag("Constructable", 1)]                         
    [Tier(2)]                                      
    public partial class SoftwoodLumberItem :
    BlockItem<SoftwoodLumberBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Softwood Lumber"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Can be fashioned into various usable equipment."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(SoftwoodLumberStacked1Block),
        typeof(SoftwoodLumberStacked2Block),
        typeof(SoftwoodLumberStacked3Block),
            typeof(SoftwoodLumberStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class SoftwoodLumberStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class SoftwoodLumberStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class SoftwoodLumberStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class SoftwoodLumberStacked4Block : PickupableBlock { } //Only a wall if it's all 4 SoftwoodLumber
}
