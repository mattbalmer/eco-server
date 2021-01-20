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
    [BlockTier(4)] 
    [IsForm(typeof(FloorFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneFloorBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WallFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FullWallFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneFullWallBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FlatRoofFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneFlatRoofBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(CubeFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(ColumnFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneColumnBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(WindowFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FenceFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneFenceBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(ChimneyFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneChimneyBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(DoubleWindowFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneDoubleWindowBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderPeakSetFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(PeakSetFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestonePeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofPeakSetFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRoofPeakSetBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }


    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofCubeFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRoofCubeBlock :
        Block, IRepresentsItem
    {
        public Type RepresentedItemType { get { return typeof(AshlarLimestoneItem); } }
    }



    [RotatedVariants(typeof(AshlarLimestoneRampABlock), typeof(AshlarLimestoneRampA90Block), typeof(AshlarLimestoneRampA180Block), typeof(AshlarLimestoneRampA270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampAFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRampABlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampA90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampA180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampA270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneRampBBlock), typeof(AshlarLimestoneRampB90Block), typeof(AshlarLimestoneRampB180Block), typeof(AshlarLimestoneRampB270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampBFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRampBBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampB90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampB180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampB270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneRampCBlock), typeof(AshlarLimestoneRampC90Block), typeof(AshlarLimestoneRampC180Block), typeof(AshlarLimestoneRampC270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampCFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRampCBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampC90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampC180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampC270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneRampDBlock), typeof(AshlarLimestoneRampD90Block), typeof(AshlarLimestoneRampD180Block), typeof(AshlarLimestoneRampD270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RampDFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRampDBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampD90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampD180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRampD270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneLadderBlock), typeof(AshlarLimestoneLadder90Block), typeof(AshlarLimestoneLadder180Block), typeof(AshlarLimestoneLadder270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(LadderFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneLadderBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneLadder90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneLadder180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneLadder270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneStairsBlock), typeof(AshlarLimestoneStairs90Block), typeof(AshlarLimestoneStairs180Block), typeof(AshlarLimestoneStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderStairsBlock), typeof(AshlarLimestoneUnderStairs90Block), typeof(AshlarLimestoneUnderStairs180Block), typeof(AshlarLimestoneUnderStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderStairsFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneFloatStairsBlock), typeof(AshlarLimestoneFloatStairs90Block), typeof(AshlarLimestoneFloatStairs180Block), typeof(AshlarLimestoneFloatStairs270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneFloatStairsBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairs90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairs180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairs270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneBraceBlock), typeof(AshlarLimestoneBrace90Block), typeof(AshlarLimestoneBrace180Block), typeof(AshlarLimestoneBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderBraceBlock), typeof(AshlarLimestoneUnderBrace90Block), typeof(AshlarLimestoneUnderBrace180Block), typeof(AshlarLimestoneUnderBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneSideBraceBlock), typeof(AshlarLimestoneSideBrace90Block), typeof(AshlarLimestoneSideBrace180Block), typeof(AshlarLimestoneSideBrace270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(SideBraceFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneSideBraceBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneSideBrace90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneSideBrace180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneSideBrace270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneBasicSlopeSideBlock), typeof(AshlarLimestoneBasicSlopeSide90Block), typeof(AshlarLimestoneBasicSlopeSide180Block), typeof(AshlarLimestoneBasicSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeSideFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneBasicSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneBasicSlopeCornerBlock), typeof(AshlarLimestoneBasicSlopeCorner90Block), typeof(AshlarLimestoneBasicSlopeCorner180Block), typeof(AshlarLimestoneBasicSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeCornerFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneBasicSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneBasicSlopeTurnBlock), typeof(AshlarLimestoneBasicSlopeTurn90Block), typeof(AshlarLimestoneBasicSlopeTurn180Block), typeof(AshlarLimestoneBasicSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopeTurnFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneBasicSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneBasicSlopePointBlock), typeof(AshlarLimestoneBasicSlopePoint90Block), typeof(AshlarLimestoneBasicSlopePoint180Block), typeof(AshlarLimestoneBasicSlopePoint270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BasicSlopePointFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneBasicSlopePointBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopePoint90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopePoint180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBasicSlopePoint270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneFloatStairsCornerBlock), typeof(AshlarLimestoneFloatStairsCorner90Block), typeof(AshlarLimestoneFloatStairsCorner180Block), typeof(AshlarLimestoneFloatStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsCornerFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneFloatStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneFloatStairsTurnBlock), typeof(AshlarLimestoneFloatStairsTurn90Block), typeof(AshlarLimestoneFloatStairsTurn180Block), typeof(AshlarLimestoneFloatStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(FloatStairsTurnFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneFloatStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneFloatStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneStairsCornerBlock), typeof(AshlarLimestoneStairsCorner90Block), typeof(AshlarLimestoneStairsCorner180Block), typeof(AshlarLimestoneStairsCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsCornerFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneStairsCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairsCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairsCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairsCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneStairsTurnBlock), typeof(AshlarLimestoneStairsTurn90Block), typeof(AshlarLimestoneStairsTurn180Block), typeof(AshlarLimestoneStairsTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(StairsTurnFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneStairsTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairsTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairsTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneStairsTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderBraceCornerBlock), typeof(AshlarLimestoneUnderBraceCorner90Block), typeof(AshlarLimestoneUnderBraceCorner180Block), typeof(AshlarLimestoneUnderBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceCornerFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderBraceCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBraceCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBraceCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBraceCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneBraceCornerBlock), typeof(AshlarLimestoneBraceCorner90Block), typeof(AshlarLimestoneBraceCorner180Block), typeof(AshlarLimestoneBraceCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceCornerFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneBraceCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBraceCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBraceCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBraceCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderSlopeSideBlock), typeof(AshlarLimestoneUnderSlopeSide90Block), typeof(AshlarLimestoneUnderSlopeSide180Block), typeof(AshlarLimestoneUnderSlopeSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeSideFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderSlopeSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderSlopeCornerBlock), typeof(AshlarLimestoneUnderSlopeCorner90Block), typeof(AshlarLimestoneUnderSlopeCorner180Block), typeof(AshlarLimestoneUnderSlopeCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeCornerFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderSlopeCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderSlopeTurnBlock), typeof(AshlarLimestoneUnderSlopeTurn90Block), typeof(AshlarLimestoneUnderSlopeTurn180Block), typeof(AshlarLimestoneUnderSlopeTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopeTurnFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderSlopeTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopeTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderSlopePeakBlock), typeof(AshlarLimestoneUnderSlopePeak90Block), typeof(AshlarLimestoneUnderSlopePeak180Block), typeof(AshlarLimestoneUnderSlopePeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderSlopePeakFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderSlopePeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopePeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopePeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderSlopePeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneRoofSideBlock), typeof(AshlarLimestoneRoofSide90Block), typeof(AshlarLimestoneRoofSide180Block), typeof(AshlarLimestoneRoofSide270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofSideFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRoofSideBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofSide90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofSide180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofSide270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneRoofTurnBlock), typeof(AshlarLimestoneRoofTurn90Block), typeof(AshlarLimestoneRoofTurn180Block), typeof(AshlarLimestoneRoofTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofTurnFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRoofTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneRoofCornerBlock), typeof(AshlarLimestoneRoofCorner90Block), typeof(AshlarLimestoneRoofCorner180Block), typeof(AshlarLimestoneRoofCorner270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofCornerFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRoofCornerBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofCorner90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofCorner180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofCorner270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneRoofPeakBlock), typeof(AshlarLimestoneRoofPeak90Block), typeof(AshlarLimestoneRoofPeak180Block), typeof(AshlarLimestoneRoofPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(RoofPeakFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneRoofPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneRoofPeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderInnerPeakBlock), typeof(AshlarLimestoneUnderInnerPeak90Block), typeof(AshlarLimestoneUnderInnerPeak180Block), typeof(AshlarLimestoneUnderInnerPeak270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderInnerPeakFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderInnerPeakBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderInnerPeak90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderInnerPeak180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderInnerPeak270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneBraceTurnBlock), typeof(AshlarLimestoneBraceTurn90Block), typeof(AshlarLimestoneBraceTurn180Block), typeof(AshlarLimestoneBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(BraceTurnFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneBraceTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBraceTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBraceTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneBraceTurn270Block : Block
    { }


    [RotatedVariants(typeof(AshlarLimestoneUnderBraceTurnBlock), typeof(AshlarLimestoneUnderBraceTurn90Block), typeof(AshlarLimestoneUnderBraceTurn180Block), typeof(AshlarLimestoneUnderBraceTurn270Block))]
    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    [IsForm(typeof(UnderBraceTurnFormType), typeof(AshlarLimestoneItem))]
    public partial class AshlarLimestoneUnderBraceTurnBlock : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBraceTurn90Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBraceTurn180Block : Block
    { }

    [Serialized]
    [Wall, Constructed, Solid, BuildRoomMaterialOption] 
    [BlockTier(4)] 
    public partial class AshlarLimestoneUnderBraceTurn270Block : Block
    { }

}
