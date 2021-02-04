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
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(FloorFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSandstoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(WallFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSandstoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(CubeFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSandstoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSandstoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(ColumnFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSandstoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(WindowGrillesFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneWindowGrillesBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSandstoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSandstoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofCubeFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredSandstoneItem); } }
    }



    [RotatedVariants(typeof(MortaredSandstoneStairsBlock), typeof(MortaredSandstoneStairs90Block), typeof(MortaredSandstoneStairs180Block), typeof(MortaredSandstoneStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(StairsFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneStairs270Block : Block
    { }


    [RotatedVariants(typeof(MortaredSandstoneRoofSideBlock), typeof(MortaredSandstoneRoofSide90Block), typeof(MortaredSandstoneRoofSide180Block), typeof(MortaredSandstoneRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofSideFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(MortaredSandstoneRoofTurnBlock), typeof(MortaredSandstoneRoofTurn90Block), typeof(MortaredSandstoneRoofTurn180Block), typeof(MortaredSandstoneRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofTurnFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(MortaredSandstoneRoofCornerBlock), typeof(MortaredSandstoneRoofCorner90Block), typeof(MortaredSandstoneRoofCorner180Block), typeof(MortaredSandstoneRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofCornerFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(MortaredSandstoneRoofPeakBlock), typeof(MortaredSandstoneRoofPeak90Block), typeof(MortaredSandstoneRoofPeak180Block), typeof(MortaredSandstoneRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofPeakFormType), typeof(MortaredSandstoneItem))]
    public partial class MortaredSandstoneRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredSandstoneRoofPeak270Block : Block
    { }

}
