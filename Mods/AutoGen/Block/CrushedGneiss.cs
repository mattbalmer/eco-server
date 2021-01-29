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
    [Solid, Wall, Diggable]
    public partial class CrushedGneissBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(CrushedGneissItem); } }  
    }

    [Serialized]
    [LocDisplayName("Crushed Gneiss")]
    [MaxStackSize(20)]                                       
    [Weight(28000)]      
    [StartsDiscovered]                                      
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("CrushedRock", 1)]
    [Tag("Excavatable", 1)]                         
    [RequiresTool(typeof(ShovelItem))] 
    public partial class CrushedGneissItem :
    BlockItem<CrushedGneissBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Gneiss"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Gneiss rocks that have been crushed into a fine gravel."); } }

        public override bool CanStickToWalls { get { return false; } }  
    }

}
