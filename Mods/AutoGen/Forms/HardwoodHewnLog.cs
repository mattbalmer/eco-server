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
    [IsForm(typeof(FloorFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(WallFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(CubeFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(ColumnFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(WindowGrillesFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogWindowGrillesBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofCubeFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(HardwoodHewnLogItem); } }
    }



    [RotatedVariants(typeof(HardwoodHewnLogStairsBlock), typeof(HardwoodHewnLogStairs90Block), typeof(HardwoodHewnLogStairs180Block), typeof(HardwoodHewnLogStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(StairsFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogStairs270Block : Block
    { }


    [RotatedVariants(typeof(HardwoodHewnLogLadderBlock), typeof(HardwoodHewnLogLadder90Block), typeof(HardwoodHewnLogLadder180Block), typeof(HardwoodHewnLogLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(LadderFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogLadder270Block : Block
    { }


    [RotatedVariants(typeof(HardwoodHewnLogRoofSideBlock), typeof(HardwoodHewnLogRoofSide90Block), typeof(HardwoodHewnLogRoofSide180Block), typeof(HardwoodHewnLogRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofSideFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(HardwoodHewnLogRoofTurnBlock), typeof(HardwoodHewnLogRoofTurn90Block), typeof(HardwoodHewnLogRoofTurn180Block), typeof(HardwoodHewnLogRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofTurnFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(HardwoodHewnLogRoofCornerBlock), typeof(HardwoodHewnLogRoofCorner90Block), typeof(HardwoodHewnLogRoofCorner180Block), typeof(HardwoodHewnLogRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofCornerFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(HardwoodHewnLogRoofPeakBlock), typeof(HardwoodHewnLogRoofPeak90Block), typeof(HardwoodHewnLogRoofPeak180Block), typeof(HardwoodHewnLogRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofPeakFormType), typeof(HardwoodHewnLogItem))]
    public partial class HardwoodHewnLogRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class HardwoodHewnLogRoofPeak270Block : Block
    { }

}
