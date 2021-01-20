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
    [Solid, Wall, Cliff, Minable(2)]
    public partial class LimestoneBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(LimestoneItem); } }  
    }

    [Serialized]
    [LocDisplayName("Limestone")]
    [MaxStackSize(20)]                           
    [Weight(15000)]      
    [ResourcePile]                                          
    [Ecopedia("Natural Resources", "Stone", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Rock", 1)]
    [Tag("Excavatable", 1)]                         
    public partial class LimestoneItem :
    BlockItem<LimestoneBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Limestone"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A hard rock useful for construction and industrial processes. Limestone is sedimentary, forming mostly from the fallen compacted remains of marine organisms."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(LimestoneStacked1Block),
        typeof(LimestoneStacked2Block),
        typeof(LimestoneStacked3Block),
            typeof(LimestoneStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class LimestoneStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class LimestoneStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class LimestoneStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class LimestoneStacked4Block : PickupableBlock { } //Only a wall if it's all 4 Limestone
}
