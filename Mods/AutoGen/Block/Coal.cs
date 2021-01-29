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

    [Serialized]
    [Minable(1), Solid,Wall]
    public partial class CoalBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(CoalItem); } }  
    }

    [Serialized]
    [LocDisplayName("Coal")]
    [MaxStackSize(40)]                           
    [Weight(4000)]      
    [Fuel(20000)][Tag("Fuel")]          
    [ResourcePile]                                          
    [Ecopedia("Natural Resources", "Ore", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Coal", 1)]
    [Tag("Burnable Fuel", 1)]
    [Tag("Excavatable", 1)]                         
    public partial class CoalItem :
    BlockItem<CoalBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Coal"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A combustible mineral which when used as a fuel provides lots of energy but generates lots of pollution."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(CoalStacked1Block),
        typeof(CoalStacked2Block),
        typeof(CoalStacked3Block),
            typeof(CoalStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class CoalStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class CoalStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class CoalStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class CoalStacked4Block : PickupableBlock { } //Only a wall if it's all 4 Coal
}
