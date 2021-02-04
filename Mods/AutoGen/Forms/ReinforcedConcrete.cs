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
    [BlockTier(3)] 
    [IsForm(typeof(FloorFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(WallFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(CubeFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(RoofFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(ColumnFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(WindowFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(RoofCubeFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(ThinColumnFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(DoubleWindowFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(UnderPeakSetFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(PeakSetFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcretePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(RoadBarrierFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteRoadBarrierBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(FlatRoofFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(FenceFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(ReinforcedConcreteItem); } }
    }



    [RotatedVariants(typeof(ReinforcedConcreteLadderBlock), typeof(ReinforcedConcreteLadder90Block), typeof(ReinforcedConcreteLadder180Block), typeof(ReinforcedConcreteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(LadderFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteLadder270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteStairsBlock), typeof(ReinforcedConcreteStairs90Block), typeof(ReinforcedConcreteStairs180Block), typeof(ReinforcedConcreteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(StairsFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairs270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteUnderStairsBlock), typeof(ReinforcedConcreteUnderStairs90Block), typeof(ReinforcedConcreteUnderStairs180Block), typeof(ReinforcedConcreteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(UnderStairsFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteBasicSlopeSideBlock), typeof(ReinforcedConcreteBasicSlopeSide90Block), typeof(ReinforcedConcreteBasicSlopeSide180Block), typeof(ReinforcedConcreteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(BasicSlopeSideFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteBasicSlopeCornerBlock), typeof(ReinforcedConcreteBasicSlopeCorner90Block), typeof(ReinforcedConcreteBasicSlopeCorner180Block), typeof(ReinforcedConcreteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteBasicSlopeTurnBlock), typeof(ReinforcedConcreteBasicSlopeTurn90Block), typeof(ReinforcedConcreteBasicSlopeTurn180Block), typeof(ReinforcedConcreteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteBasicSlopePointBlock), typeof(ReinforcedConcreteBasicSlopePoint90Block), typeof(ReinforcedConcreteBasicSlopePoint180Block), typeof(ReinforcedConcreteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(BasicSlopePointFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteStairsCornerBlock), typeof(ReinforcedConcreteStairsCorner90Block), typeof(ReinforcedConcreteStairsCorner180Block), typeof(ReinforcedConcreteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(StairsCornerFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteStairsTurnBlock), typeof(ReinforcedConcreteStairsTurn90Block), typeof(ReinforcedConcreteStairsTurn180Block), typeof(ReinforcedConcreteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(StairsTurnFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteUnderSlopeSideBlock), typeof(ReinforcedConcreteUnderSlopeSide90Block), typeof(ReinforcedConcreteUnderSlopeSide180Block), typeof(ReinforcedConcreteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(UnderSlopeSideFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteUnderSlopeCornerBlock), typeof(ReinforcedConcreteUnderSlopeCorner90Block), typeof(ReinforcedConcreteUnderSlopeCorner180Block), typeof(ReinforcedConcreteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteUnderSlopeTurnBlock), typeof(ReinforcedConcreteUnderSlopeTurn90Block), typeof(ReinforcedConcreteUnderSlopeTurn180Block), typeof(ReinforcedConcreteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteUnderSlopePeakBlock), typeof(ReinforcedConcreteUnderSlopePeak90Block), typeof(ReinforcedConcreteUnderSlopePeak180Block), typeof(ReinforcedConcreteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(UnderSlopePeakFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteRoofSideBlock), typeof(ReinforcedConcreteRoofSide90Block), typeof(ReinforcedConcreteRoofSide180Block), typeof(ReinforcedConcreteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(RoofSideFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteRoofTurnBlock), typeof(ReinforcedConcreteRoofTurn90Block), typeof(ReinforcedConcreteRoofTurn180Block), typeof(ReinforcedConcreteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(RoofTurnFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteRoofCornerBlock), typeof(ReinforcedConcreteRoofCorner90Block), typeof(ReinforcedConcreteRoofCorner180Block), typeof(ReinforcedConcreteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(RoofCornerFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteRoofPeakBlock), typeof(ReinforcedConcreteRoofPeak90Block), typeof(ReinforcedConcreteRoofPeak180Block), typeof(ReinforcedConcreteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(RoofPeakFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteUnderInnerPeakBlock), typeof(ReinforcedConcreteUnderInnerPeak90Block), typeof(ReinforcedConcreteUnderInnerPeak180Block), typeof(ReinforcedConcreteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(UnderInnerPeakFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteHalfSlopeABlock), typeof(ReinforcedConcreteHalfSlopeA90Block), typeof(ReinforcedConcreteHalfSlopeA180Block), typeof(ReinforcedConcreteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(HalfSlopeAFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(ReinforcedConcreteHalfSlopeBBlock), typeof(ReinforcedConcreteHalfSlopeB90Block), typeof(ReinforcedConcreteHalfSlopeB180Block), typeof(ReinforcedConcreteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    [IsForm(typeof(HalfSlopeBFormType), typeof(ReinforcedConcreteItem))]
    public partial class ReinforcedConcreteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(3)] 
    public partial class ReinforcedConcreteHalfSlopeB270Block : Block
    { }

}
