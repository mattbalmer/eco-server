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
    [BlockTier(4)] 
    [IsForm(typeof(FloorFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WallFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FullWallFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleFullWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FlatRoofFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(CubeFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(ColumnFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WindowFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FenceFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(ChimneyFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleChimneyBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(DoubleWindowFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderPeakSetFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(PeakSetFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShalePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofCubeFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }
    }



    [RotatedVariants(typeof(AshlarShaleRampABlock), typeof(AshlarShaleRampA90Block), typeof(AshlarShaleRampA180Block), typeof(AshlarShaleRampA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampAFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRampABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampA270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleRampBBlock), typeof(AshlarShaleRampB90Block), typeof(AshlarShaleRampB180Block), typeof(AshlarShaleRampB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampBFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRampBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampB270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleRampCBlock), typeof(AshlarShaleRampC90Block), typeof(AshlarShaleRampC180Block), typeof(AshlarShaleRampC270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampCFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRampCBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampC90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampC180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampC270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleRampDBlock), typeof(AshlarShaleRampD90Block), typeof(AshlarShaleRampD180Block), typeof(AshlarShaleRampD270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampDFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRampDBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampD90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampD180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRampD270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleLadderBlock), typeof(AshlarShaleLadder90Block), typeof(AshlarShaleLadder180Block), typeof(AshlarShaleLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(LadderFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleLadder270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleStairsBlock), typeof(AshlarShaleStairs90Block), typeof(AshlarShaleStairs180Block), typeof(AshlarShaleStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderStairsBlock), typeof(AshlarShaleUnderStairs90Block), typeof(AshlarShaleUnderStairs180Block), typeof(AshlarShaleUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderStairsFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleFloatStairsBlock), typeof(AshlarShaleFloatStairs90Block), typeof(AshlarShaleFloatStairs180Block), typeof(AshlarShaleFloatStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleFloatStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleBraceBlock), typeof(AshlarShaleBrace90Block), typeof(AshlarShaleBrace180Block), typeof(AshlarShaleBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderBraceBlock), typeof(AshlarShaleUnderBrace90Block), typeof(AshlarShaleUnderBrace180Block), typeof(AshlarShaleUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleSideBraceBlock), typeof(AshlarShaleSideBrace90Block), typeof(AshlarShaleSideBrace180Block), typeof(AshlarShaleSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(SideBraceFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleSideBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleSideBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleSideBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleSideBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleBasicSlopeSideBlock), typeof(AshlarShaleBasicSlopeSide90Block), typeof(AshlarShaleBasicSlopeSide180Block), typeof(AshlarShaleBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeSideFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleBasicSlopeCornerBlock), typeof(AshlarShaleBasicSlopeCorner90Block), typeof(AshlarShaleBasicSlopeCorner180Block), typeof(AshlarShaleBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleBasicSlopeTurnBlock), typeof(AshlarShaleBasicSlopeTurn90Block), typeof(AshlarShaleBasicSlopeTurn180Block), typeof(AshlarShaleBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleBasicSlopePointBlock), typeof(AshlarShaleBasicSlopePoint90Block), typeof(AshlarShaleBasicSlopePoint180Block), typeof(AshlarShaleBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopePointFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleFloatStairsCornerBlock), typeof(AshlarShaleFloatStairsCorner90Block), typeof(AshlarShaleFloatStairsCorner180Block), typeof(AshlarShaleFloatStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsCornerFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleFloatStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleFloatStairsTurnBlock), typeof(AshlarShaleFloatStairsTurn90Block), typeof(AshlarShaleFloatStairsTurn180Block), typeof(AshlarShaleFloatStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsTurnFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleFloatStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleFloatStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleStairsCornerBlock), typeof(AshlarShaleStairsCorner90Block), typeof(AshlarShaleStairsCorner180Block), typeof(AshlarShaleStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsCornerFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleStairsTurnBlock), typeof(AshlarShaleStairsTurn90Block), typeof(AshlarShaleStairsTurn180Block), typeof(AshlarShaleStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsTurnFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderBraceCornerBlock), typeof(AshlarShaleUnderBraceCorner90Block), typeof(AshlarShaleUnderBraceCorner180Block), typeof(AshlarShaleUnderBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceCornerFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderBraceCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBraceCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBraceCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBraceCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleBraceCornerBlock), typeof(AshlarShaleBraceCorner90Block), typeof(AshlarShaleBraceCorner180Block), typeof(AshlarShaleBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceCornerFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleBraceCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBraceCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBraceCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBraceCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderSlopeSideBlock), typeof(AshlarShaleUnderSlopeSide90Block), typeof(AshlarShaleUnderSlopeSide180Block), typeof(AshlarShaleUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeSideFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderSlopeCornerBlock), typeof(AshlarShaleUnderSlopeCorner90Block), typeof(AshlarShaleUnderSlopeCorner180Block), typeof(AshlarShaleUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderSlopeTurnBlock), typeof(AshlarShaleUnderSlopeTurn90Block), typeof(AshlarShaleUnderSlopeTurn180Block), typeof(AshlarShaleUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderSlopePeakBlock), typeof(AshlarShaleUnderSlopePeak90Block), typeof(AshlarShaleUnderSlopePeak180Block), typeof(AshlarShaleUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopePeakFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleRoofSideBlock), typeof(AshlarShaleRoofSide90Block), typeof(AshlarShaleRoofSide180Block), typeof(AshlarShaleRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofSideFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleRoofTurnBlock), typeof(AshlarShaleRoofTurn90Block), typeof(AshlarShaleRoofTurn180Block), typeof(AshlarShaleRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofTurnFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleRoofCornerBlock), typeof(AshlarShaleRoofCorner90Block), typeof(AshlarShaleRoofCorner180Block), typeof(AshlarShaleRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofCornerFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleRoofPeakBlock), typeof(AshlarShaleRoofPeak90Block), typeof(AshlarShaleRoofPeak180Block), typeof(AshlarShaleRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofPeakFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderInnerPeakBlock), typeof(AshlarShaleUnderInnerPeak90Block), typeof(AshlarShaleUnderInnerPeak180Block), typeof(AshlarShaleUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderInnerPeakFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleBraceTurnBlock), typeof(AshlarShaleBraceTurn90Block), typeof(AshlarShaleBraceTurn180Block), typeof(AshlarShaleBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceTurnFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleBraceTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBraceTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBraceTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleBraceTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleUnderBraceTurnBlock), typeof(AshlarShaleUnderBraceTurn90Block), typeof(AshlarShaleUnderBraceTurn180Block), typeof(AshlarShaleUnderBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceTurnFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleUnderBraceTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBraceTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBraceTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleUnderBraceTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleHalfSlopeABlock), typeof(AshlarShaleHalfSlopeA90Block), typeof(AshlarShaleHalfSlopeA180Block), typeof(AshlarShaleHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(HalfSlopeAFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(AshlarShaleHalfSlopeBBlock), typeof(AshlarShaleHalfSlopeB90Block), typeof(AshlarShaleHalfSlopeB180Block), typeof(AshlarShaleHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(HalfSlopeBFormType), typeof(AshlarShaleItem))]
    public partial class AshlarShaleHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarShaleHalfSlopeB270Block : Block
    { }

}
