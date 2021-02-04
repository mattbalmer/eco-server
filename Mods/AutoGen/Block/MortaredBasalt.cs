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
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    public partial class MortaredBasaltBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(MortaredBasaltItem); } }  
    }

    [Serialized]
    [LocDisplayName("Mortared Basalt")]
    [MaxStackSize(15)]                           
    [Weight(10000)]      
    [Category("Hidden")]    
    public partial class MortaredBasaltItem :
    BlockItem<MortaredBasaltBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Mortared Basalt"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Used to create tough but rudimentary buildings."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(MortaredBasaltStacked1Block),
        typeof(MortaredBasaltStacked2Block),
            typeof(MortaredBasaltStacked3Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class MortaredBasaltStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class MortaredBasaltStacked2Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class MortaredBasaltStacked3Block : PickupableBlock { } //Only a wall if it's all 4 MortaredBasalt
}
