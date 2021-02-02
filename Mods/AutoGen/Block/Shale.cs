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
    [Solid, Wall, Cliff, Minable(1)]
    public partial class ShaleBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(ShaleItem); } }  
    }

    [Serialized]
    [LocDisplayName("Shale")]
    [MaxStackSize(40)]                           
    [Weight(6000)]      
    [ResourcePile]                                          
    [Ecopedia("Natural Resources", "Stone", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Rock", 1)]
    [Tag("Excavatable", 1)]                         
    public partial class ShaleItem :
    BlockItem<ShaleBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Shale"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A soft rock, with few potential uses. Shale is a sedimentary rock formed by thin layers of compacted clay or mud."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(ShaleStacked1Block),
        typeof(ShaleStacked2Block),
        typeof(ShaleStacked3Block),
            typeof(ShaleStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class ShaleStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class ShaleStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class ShaleStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class ShaleStacked4Block : PickupableBlock { } //Only a wall if it's all 4 Shale
}
