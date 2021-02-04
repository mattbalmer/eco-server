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
    [IsForm(typeof(WindowWallFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberWindowWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloorFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(CladWallFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberCladWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WallFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FullWallFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberFullWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WallTrimFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberWallTrimBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FlatRoofFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(CubeFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(ColumnFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(ThinColumnFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberThinColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WindowFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WindowGrillesFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberWindowGrillesBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(DoubleWindowFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FenceFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(SideFenceFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberSideFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderPeakSetFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(PeakSetFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofCubeFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(CompositeOakLumberItem); } }
    }



    [RotatedVariants(typeof(CompositeOakLumberRampABlock), typeof(CompositeOakLumberRampA90Block), typeof(CompositeOakLumberRampA180Block), typeof(CompositeOakLumberRampA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampAFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRampABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampA270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberRampBBlock), typeof(CompositeOakLumberRampB90Block), typeof(CompositeOakLumberRampB180Block), typeof(CompositeOakLumberRampB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampBFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRampBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampB270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberRampCBlock), typeof(CompositeOakLumberRampC90Block), typeof(CompositeOakLumberRampC180Block), typeof(CompositeOakLumberRampC270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampCFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRampCBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampC90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampC180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampC270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberRampDBlock), typeof(CompositeOakLumberRampD90Block), typeof(CompositeOakLumberRampD180Block), typeof(CompositeOakLumberRampD270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampDFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRampDBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampD90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampD180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRampD270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberLadderBlock), typeof(CompositeOakLumberLadder90Block), typeof(CompositeOakLumberLadder180Block), typeof(CompositeOakLumberLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(LadderFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberLadder270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberStairsBlock), typeof(CompositeOakLumberStairs90Block), typeof(CompositeOakLumberStairs180Block), typeof(CompositeOakLumberStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairs270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberUnderStairsBlock), typeof(CompositeOakLumberUnderStairs90Block), typeof(CompositeOakLumberUnderStairs180Block), typeof(CompositeOakLumberUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderStairsFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberFloatStairsBlock), typeof(CompositeOakLumberFloatStairs90Block), typeof(CompositeOakLumberFloatStairs180Block), typeof(CompositeOakLumberFloatStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberFloatStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairs270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberBraceBlock), typeof(CompositeOakLumberBrace90Block), typeof(CompositeOakLumberBrace180Block), typeof(CompositeOakLumberBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBrace270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberUnderBraceBlock), typeof(CompositeOakLumberUnderBrace90Block), typeof(CompositeOakLumberUnderBrace180Block), typeof(CompositeOakLumberUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberUnderBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderBrace270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberSideBraceBlock), typeof(CompositeOakLumberSideBrace90Block), typeof(CompositeOakLumberSideBrace180Block), typeof(CompositeOakLumberSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(SideBraceFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberSideBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberSideBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberSideBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberSideBrace270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberBasicSlopeSideBlock), typeof(CompositeOakLumberBasicSlopeSide90Block), typeof(CompositeOakLumberBasicSlopeSide180Block), typeof(CompositeOakLumberBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeSideFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberBasicSlopeCornerBlock), typeof(CompositeOakLumberBasicSlopeCorner90Block), typeof(CompositeOakLumberBasicSlopeCorner180Block), typeof(CompositeOakLumberBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberBasicSlopeTurnBlock), typeof(CompositeOakLumberBasicSlopeTurn90Block), typeof(CompositeOakLumberBasicSlopeTurn180Block), typeof(CompositeOakLumberBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberBasicSlopePointBlock), typeof(CompositeOakLumberBasicSlopePoint90Block), typeof(CompositeOakLumberBasicSlopePoint180Block), typeof(CompositeOakLumberBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopePointFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberFloatStairsCornerBlock), typeof(CompositeOakLumberFloatStairsCorner90Block), typeof(CompositeOakLumberFloatStairsCorner180Block), typeof(CompositeOakLumberFloatStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsCornerFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberFloatStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberFloatStairsTurnBlock), typeof(CompositeOakLumberFloatStairsTurn90Block), typeof(CompositeOakLumberFloatStairsTurn180Block), typeof(CompositeOakLumberFloatStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsTurnFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberFloatStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberFloatStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberStairsCornerBlock), typeof(CompositeOakLumberStairsCorner90Block), typeof(CompositeOakLumberStairsCorner180Block), typeof(CompositeOakLumberStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsCornerFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberStairsTurnBlock), typeof(CompositeOakLumberStairsTurn90Block), typeof(CompositeOakLumberStairsTurn180Block), typeof(CompositeOakLumberStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsTurnFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberUnderSlopeSideBlock), typeof(CompositeOakLumberUnderSlopeSide90Block), typeof(CompositeOakLumberUnderSlopeSide180Block), typeof(CompositeOakLumberUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeSideFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberUnderSlopeCornerBlock), typeof(CompositeOakLumberUnderSlopeCorner90Block), typeof(CompositeOakLumberUnderSlopeCorner180Block), typeof(CompositeOakLumberUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberUnderSlopeTurnBlock), typeof(CompositeOakLumberUnderSlopeTurn90Block), typeof(CompositeOakLumberUnderSlopeTurn180Block), typeof(CompositeOakLumberUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberUnderSlopePeakBlock), typeof(CompositeOakLumberUnderSlopePeak90Block), typeof(CompositeOakLumberUnderSlopePeak180Block), typeof(CompositeOakLumberUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopePeakFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberRoofSideBlock), typeof(CompositeOakLumberRoofSide90Block), typeof(CompositeOakLumberRoofSide180Block), typeof(CompositeOakLumberRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofSideFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberRoofTurnBlock), typeof(CompositeOakLumberRoofTurn90Block), typeof(CompositeOakLumberRoofTurn180Block), typeof(CompositeOakLumberRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofTurnFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberRoofCornerBlock), typeof(CompositeOakLumberRoofCorner90Block), typeof(CompositeOakLumberRoofCorner180Block), typeof(CompositeOakLumberRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofCornerFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberRoofPeakBlock), typeof(CompositeOakLumberRoofPeak90Block), typeof(CompositeOakLumberRoofPeak180Block), typeof(CompositeOakLumberRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofPeakFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(CompositeOakLumberUnderInnerPeakBlock), typeof(CompositeOakLumberUnderInnerPeak90Block), typeof(CompositeOakLumberUnderInnerPeak180Block), typeof(CompositeOakLumberUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderInnerPeakFormType), typeof(CompositeOakLumberItem))]
    public partial class CompositeOakLumberUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class CompositeOakLumberUnderInnerPeak270Block : Block
    { }

}
