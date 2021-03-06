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
    public partial class SoftwoodHewnLogRecipe :
        Recipe
    {
        public SoftwoodHewnLogRecipe()
        {
            this.Name        = "SoftwoodHewnLog";
            this.DisplayName = Localizer.DoStr("Softwood Hewn Log");
            this.Ingredients = new List<IngredientElement>
            {
                new IngredientElement("Softwood",  2),  
            };
            this.Items = new List<CraftingElement>
            {
                new CraftingElement<SoftwoodHewnLogItem>() 
            };
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(WorkbenchObject), typeof(HewnLogRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(1)]                                          
    public partial class SoftwoodHewnLogBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(SoftwoodHewnLogItem); } }  
    }

    [Serialized]
    [LocDisplayName("Softwood Hewn Log")]
    [MaxStackSize(40)]                           
    [Weight(10000)]      
    [Fuel(4000)][Tag("Fuel")]          
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("HewnLog", 1)]
    [Tag("Burnable Fuel", 1)]
    [Tag("Constructable", 1)]                         
    [Tier(1)]                                      
    public partial class SoftwoodHewnLogItem :
    BlockItem<SoftwoodHewnLogBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A log hewn and shaped to be a building material. Hewing logs at a workbench will grant no experience."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(SoftwoodHewnLogStacked1Block),
        typeof(SoftwoodHewnLogStacked2Block),
            typeof(SoftwoodHewnLogStacked3Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class SoftwoodHewnLogStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class SoftwoodHewnLogStacked2Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class SoftwoodHewnLogStacked3Block : PickupableBlock { } //Only a wall if it's all 4 SoftwoodHewnLog
}
