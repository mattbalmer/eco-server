// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class WhiteRampDashLineDFormType : FormType
    {
        public override string Name => "WhiteRampDashLineD";
        public override LocString DisplayName => Localizer.DoStr("Asphalt White Ramp Dash LineD");
        public override LocString DisplayDescription => Localizer.DoStr("Asphalt White Ramp Dash LineD");
        public override Type GroupType => typeof(RampsFormGroup);
        public override int SortOrder => 71;
        public override int MinTier => 1;
    }
}
