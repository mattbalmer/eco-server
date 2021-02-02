// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Serialization;

    public partial class DistributionStationItem : IPersistentData
    {
        [Serialized, TooltipChildren] public object PersistentData { get; set; }
    }
}
