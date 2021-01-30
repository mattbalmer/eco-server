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
    [IsForm(typeof(FloorFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WallFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FullWallFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteFullWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FlatRoofFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(CubeFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(ColumnFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WindowFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FenceFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(ChimneyFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteChimneyBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(DoubleWindowFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderPeakSetFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(PeakSetFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGranitePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofCubeFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarGraniteItem); } }
    }



    [RotatedVariants(typeof(AshlarGraniteRampABlock), typeof(AshlarGraniteRampA90Block), typeof(AshlarGraniteRampA180Block), typeof(AshlarGraniteRampA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampAFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRampABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampA270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteRampBBlock), typeof(AshlarGraniteRampB90Block), typeof(AshlarGraniteRampB180Block), typeof(AshlarGraniteRampB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampBFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRampBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampB270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteRampCBlock), typeof(AshlarGraniteRampC90Block), typeof(AshlarGraniteRampC180Block), typeof(AshlarGraniteRampC270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampCFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRampCBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampC90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampC180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampC270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteRampDBlock), typeof(AshlarGraniteRampD90Block), typeof(AshlarGraniteRampD180Block), typeof(AshlarGraniteRampD270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampDFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRampDBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampD90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampD180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRampD270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteLadderBlock), typeof(AshlarGraniteLadder90Block), typeof(AshlarGraniteLadder180Block), typeof(AshlarGraniteLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(LadderFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteLadder270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteStairsBlock), typeof(AshlarGraniteStairs90Block), typeof(AshlarGraniteStairs180Block), typeof(AshlarGraniteStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderStairsBlock), typeof(AshlarGraniteUnderStairs90Block), typeof(AshlarGraniteUnderStairs180Block), typeof(AshlarGraniteUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderStairsFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteFloatStairsBlock), typeof(AshlarGraniteFloatStairs90Block), typeof(AshlarGraniteFloatStairs180Block), typeof(AshlarGraniteFloatStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteFloatStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteBraceBlock), typeof(AshlarGraniteBrace90Block), typeof(AshlarGraniteBrace180Block), typeof(AshlarGraniteBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderBraceBlock), typeof(AshlarGraniteUnderBrace90Block), typeof(AshlarGraniteUnderBrace180Block), typeof(AshlarGraniteUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteSideBraceBlock), typeof(AshlarGraniteSideBrace90Block), typeof(AshlarGraniteSideBrace180Block), typeof(AshlarGraniteSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(SideBraceFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteSideBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteSideBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteSideBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteSideBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteBasicSlopeSideBlock), typeof(AshlarGraniteBasicSlopeSide90Block), typeof(AshlarGraniteBasicSlopeSide180Block), typeof(AshlarGraniteBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeSideFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteBasicSlopeCornerBlock), typeof(AshlarGraniteBasicSlopeCorner90Block), typeof(AshlarGraniteBasicSlopeCorner180Block), typeof(AshlarGraniteBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteBasicSlopeTurnBlock), typeof(AshlarGraniteBasicSlopeTurn90Block), typeof(AshlarGraniteBasicSlopeTurn180Block), typeof(AshlarGraniteBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteBasicSlopePointBlock), typeof(AshlarGraniteBasicSlopePoint90Block), typeof(AshlarGraniteBasicSlopePoint180Block), typeof(AshlarGraniteBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopePointFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteFloatStairsCornerBlock), typeof(AshlarGraniteFloatStairsCorner90Block), typeof(AshlarGraniteFloatStairsCorner180Block), typeof(AshlarGraniteFloatStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsCornerFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteFloatStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteFloatStairsTurnBlock), typeof(AshlarGraniteFloatStairsTurn90Block), typeof(AshlarGraniteFloatStairsTurn180Block), typeof(AshlarGraniteFloatStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsTurnFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteFloatStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteFloatStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteStairsCornerBlock), typeof(AshlarGraniteStairsCorner90Block), typeof(AshlarGraniteStairsCorner180Block), typeof(AshlarGraniteStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsCornerFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteStairsTurnBlock), typeof(AshlarGraniteStairsTurn90Block), typeof(AshlarGraniteStairsTurn180Block), typeof(AshlarGraniteStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsTurnFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderBraceCornerBlock), typeof(AshlarGraniteUnderBraceCorner90Block), typeof(AshlarGraniteUnderBraceCorner180Block), typeof(AshlarGraniteUnderBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceCornerFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderBraceCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBraceCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBraceCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBraceCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteBraceCornerBlock), typeof(AshlarGraniteBraceCorner90Block), typeof(AshlarGraniteBraceCorner180Block), typeof(AshlarGraniteBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceCornerFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteBraceCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBraceCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBraceCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBraceCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderSlopeSideBlock), typeof(AshlarGraniteUnderSlopeSide90Block), typeof(AshlarGraniteUnderSlopeSide180Block), typeof(AshlarGraniteUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeSideFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderSlopeCornerBlock), typeof(AshlarGraniteUnderSlopeCorner90Block), typeof(AshlarGraniteUnderSlopeCorner180Block), typeof(AshlarGraniteUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderSlopeTurnBlock), typeof(AshlarGraniteUnderSlopeTurn90Block), typeof(AshlarGraniteUnderSlopeTurn180Block), typeof(AshlarGraniteUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderSlopePeakBlock), typeof(AshlarGraniteUnderSlopePeak90Block), typeof(AshlarGraniteUnderSlopePeak180Block), typeof(AshlarGraniteUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopePeakFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteRoofSideBlock), typeof(AshlarGraniteRoofSide90Block), typeof(AshlarGraniteRoofSide180Block), typeof(AshlarGraniteRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofSideFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteRoofTurnBlock), typeof(AshlarGraniteRoofTurn90Block), typeof(AshlarGraniteRoofTurn180Block), typeof(AshlarGraniteRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofTurnFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteRoofCornerBlock), typeof(AshlarGraniteRoofCorner90Block), typeof(AshlarGraniteRoofCorner180Block), typeof(AshlarGraniteRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofCornerFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteRoofPeakBlock), typeof(AshlarGraniteRoofPeak90Block), typeof(AshlarGraniteRoofPeak180Block), typeof(AshlarGraniteRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofPeakFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderInnerPeakBlock), typeof(AshlarGraniteUnderInnerPeak90Block), typeof(AshlarGraniteUnderInnerPeak180Block), typeof(AshlarGraniteUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderInnerPeakFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteBraceTurnBlock), typeof(AshlarGraniteBraceTurn90Block), typeof(AshlarGraniteBraceTurn180Block), typeof(AshlarGraniteBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceTurnFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteBraceTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBraceTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBraceTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteBraceTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteUnderBraceTurnBlock), typeof(AshlarGraniteUnderBraceTurn90Block), typeof(AshlarGraniteUnderBraceTurn180Block), typeof(AshlarGraniteUnderBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceTurnFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteUnderBraceTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBraceTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBraceTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteUnderBraceTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteHalfSlopeABlock), typeof(AshlarGraniteHalfSlopeA90Block), typeof(AshlarGraniteHalfSlopeA180Block), typeof(AshlarGraniteHalfSlopeA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(HalfSlopeAFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteHalfSlopeABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteHalfSlopeA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteHalfSlopeA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteHalfSlopeA270Block : Block
    { }


    [RotatedVariants(typeof(AshlarGraniteHalfSlopeBBlock), typeof(AshlarGraniteHalfSlopeB90Block), typeof(AshlarGraniteHalfSlopeB180Block), typeof(AshlarGraniteHalfSlopeB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(HalfSlopeBFormType), typeof(AshlarGraniteItem))]
    public partial class AshlarGraniteHalfSlopeBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteHalfSlopeB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteHalfSlopeB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarGraniteHalfSlopeB270Block : Block
    { }

}
