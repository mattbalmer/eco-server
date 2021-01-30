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
    [Minable(2), Solid,Wall]
    public partial class GoldOreBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(GoldOreItem); } }  
    }

    [Serialized]
    [LocDisplayName("Gold Ore")]
    [MaxStackSize(40)]                           
    [Weight(7500)]      
    [ResourcePile]                                          
    [Ecopedia("Natural Resources", "Ore", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Ore", 1)]
    [Tag("Excavatable", 1)]                         
    public partial class GoldOreItem :
    BlockItem<GoldOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Gold Ore"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Unrefined ore with traces of gold."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(GoldOreStacked1Block),
        typeof(GoldOreStacked2Block),
        typeof(GoldOreStacked3Block),
            typeof(GoldOreStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class GoldOreStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GoldOreStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GoldOreStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class GoldOreStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GoldOre
}
