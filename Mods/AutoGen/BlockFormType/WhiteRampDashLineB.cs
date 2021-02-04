// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    [NextRamp(typeof(WhiteRampDashLineCFormType), 0)]    
    public partial class WhiteRampDashLineBFormType : FormType
    {
        public override string Name => "WhiteRampDashLineB";
        public override LocString DisplayName => Localizer.DoStr("Asphalt White Ramp Dash LineB");
        public override LocString DisplayDescription => Localizer.DoStr("Asphalt White Ramp Dash LineB");
        public override Type GroupType => typeof(RampsFormGroup);
        public override int SortOrder => 69;
        public override int MinTier => 1;
    }
}
