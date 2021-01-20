// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.BlockFills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public class Wall3PointFill : BlockFill
    {
        public override int SortOrder => 6;
        public override string Name => "Wall3Point";
        public override LocString DisplayName => Localizer.DoStr("Wall3Point");
        public override LocString DisplayDescription => Localizer.DoStr("A wall of blocks.");
    }
}
