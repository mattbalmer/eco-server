// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Items;

    [Category("Hidden")]
    [Mower, Tag("Harvester")]
    public abstract partial class ScytheItem : BlockHarvestItem
    {
    }
}
