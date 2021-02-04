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
    [IsForm(typeof(FloorFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredStoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(WallFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredStoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(CubeFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredStoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredStoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(ColumnFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredStoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(WindowGrillesFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneWindowGrillesBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredStoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredStoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofCubeFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(MortaredStoneItem); } }
    }



    [RotatedVariants(typeof(MortaredStoneStairsBlock), typeof(MortaredStoneStairs90Block), typeof(MortaredStoneStairs180Block), typeof(MortaredStoneStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(StairsFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneStairs270Block : Block
    { }


    [RotatedVariants(typeof(MortaredStoneRoofSideBlock), typeof(MortaredStoneRoofSide90Block), typeof(MortaredStoneRoofSide180Block), typeof(MortaredStoneRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofSideFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(MortaredStoneRoofTurnBlock), typeof(MortaredStoneRoofTurn90Block), typeof(MortaredStoneRoofTurn180Block), typeof(MortaredStoneRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofTurnFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(MortaredStoneRoofCornerBlock), typeof(MortaredStoneRoofCorner90Block), typeof(MortaredStoneRoofCorner180Block), typeof(MortaredStoneRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofCornerFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(MortaredStoneRoofPeakBlock), typeof(MortaredStoneRoofPeak90Block), typeof(MortaredStoneRoofPeak180Block), typeof(MortaredStoneRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    [IsForm(typeof(RoofPeakFormType), typeof(MortaredStoneItem))]
    public partial class MortaredStoneRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(1)] 
    public partial class MortaredStoneRoofPeak270Block : Block
    { }

}
