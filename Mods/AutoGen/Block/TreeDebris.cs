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
    [Occupied]
    public partial class TreeDebrisBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(TreeDebrisItem); } }  
    }

    [Serialized]
    [LocDisplayName("Tree Debris")]
    [MaxStackSize(10)]                                       
    [Category("Hidden")]    
    [StartsDiscovered]                                      
    [Ecopedia("Blocks", "Byproducts", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class TreeDebrisItem :
    BlockItem<TreeDebrisBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Clear cut debris that needs to be broken down to be more usable."); } }

    }

}
