﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    [NextRamp(typeof(WhiteRampLineDFormType), 0)]    
    public partial class WhiteRampLineCFormType : FormType
    {
        public override string Name => "WhiteRampLineC";
        public override LocString DisplayName => Localizer.DoStr("Asphalt White Ramp LineC");
        public override LocString DisplayDescription => Localizer.DoStr("Asphalt White Ramp LineC");
        public override Type GroupType => typeof(RampsFormGroup);
        public override int SortOrder => 66;
        public override int MinTier => 1;
    }
}
