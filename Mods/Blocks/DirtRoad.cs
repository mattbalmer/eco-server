// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.World.Blocks;

    [LocDisplayName("Dirt Road")]
    [Serialized]
    [Solid, Diggable, Wall, BiomeBlock(null), BiomeDestructible(typeof(DesertSandBlock)), Fertile(Unset = true), Tillable(Unset = true)]
    [Road(1f)]
    [UsesRamp(typeof(DirtRampItem))]
    public class DirtRoadBlock : DirtBlock, IRepresentsItem
    {
        public Type RepresentedItemType => typeof(DirtItem);
    }

    [Serialized]
    [LocDisplayName("Dirt Road")]
    [Weight(30000)]
    [Ecopedia("Blocks", "Roads", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Category("Hidden")]
    public partial class DirtRoadItem : BlockItem<DirtRoadBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A dusty surface formed by tampering dirt with a road tool. It's servicable for any wheeled vehicle.."); } }
    }
}
