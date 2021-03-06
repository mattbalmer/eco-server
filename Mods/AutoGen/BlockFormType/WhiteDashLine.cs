﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    public partial class WhiteDashLineFormType : FormType
    {
        public override string Name => "WhiteDashLine";
        public override LocString DisplayName => Localizer.DoStr("Asphalt White Dash Line");
        public override LocString DisplayDescription => Localizer.DoStr("Asphalt White Dash Line");
        public override Type GroupType => typeof(BasicFormGroup);
        public override int SortOrder => 63;
        public override int MinTier => 1;
    }
}
