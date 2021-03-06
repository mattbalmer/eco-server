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
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(FloorFormType), typeof(HewnLogItem))]
    public partial class HewnLogFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(WallFormType), typeof(HewnLogItem))]
    public partial class HewnLogWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(CubeFormType), typeof(HewnLogItem))]
    public partial class HewnLogCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofFormType), typeof(HewnLogItem))]
    public partial class HewnLogRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(ColumnFormType), typeof(HewnLogItem))]
    public partial class HewnLogColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(WindowGrillesFormType), typeof(HewnLogItem))]
    public partial class HewnLogWindowGrillesBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(HewnLogItem))]
    public partial class HewnLogRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofCubeFormType), typeof(HewnLogItem))]
    public partial class HewnLogRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HewnLogItem); } }
    }



    [RotatedVariants(typeof(HewnLogStairsBlock), typeof(HewnLogStairs90Block), typeof(HewnLogStairs180Block), typeof(HewnLogStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(StairsFormType), typeof(HewnLogItem))]
    public partial class HewnLogStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogStairs270Block : Block
    { }


    [RotatedVariants(typeof(HewnLogLadderBlock), typeof(HewnLogLadder90Block), typeof(HewnLogLadder180Block), typeof(HewnLogLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(LadderFormType), typeof(HewnLogItem))]
    public partial class HewnLogLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogLadder270Block : Block
    { }


    [RotatedVariants(typeof(HewnLogRoofSideBlock), typeof(HewnLogRoofSide90Block), typeof(HewnLogRoofSide180Block), typeof(HewnLogRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofSideFormType), typeof(HewnLogItem))]
    public partial class HewnLogRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(HewnLogRoofTurnBlock), typeof(HewnLogRoofTurn90Block), typeof(HewnLogRoofTurn180Block), typeof(HewnLogRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofTurnFormType), typeof(HewnLogItem))]
    public partial class HewnLogRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(HewnLogRoofCornerBlock), typeof(HewnLogRoofCorner90Block), typeof(HewnLogRoofCorner180Block), typeof(HewnLogRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofCornerFormType), typeof(HewnLogItem))]
    public partial class HewnLogRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(HewnLogRoofPeakBlock), typeof(HewnLogRoofPeak90Block), typeof(HewnLogRoofPeak180Block), typeof(HewnLogRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofPeakFormType), typeof(HewnLogItem))]
    public partial class HewnLogRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HewnLogRoofPeak270Block : Block
    { }

}
