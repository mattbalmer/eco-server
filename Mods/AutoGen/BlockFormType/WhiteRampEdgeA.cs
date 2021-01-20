﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class WhiteRampEdgeAFormType : FormType
    {
        public override string Name => "WhiteRampEdgeA";
        public override LocString DisplayName => Localizer.DoStr("White Ramp Edge LineA");
        public override LocString DisplayDescription => Localizer.DoStr("White Ramp Edge LineA");
        public override Type GroupType => typeof(RampsFormGroup);
        public override int SortOrder => 76;
        public override int MinTier => 1;
    }
}
