﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class ChimneyFormType : FormType
    {
        public override string Name => "Chimney";
        public override LocString DisplayName => Localizer.DoStr("Chimney");
        public override LocString DisplayDescription => Localizer.DoStr("Chimney");
        public override Type GroupType => typeof(SupportsFormGroup);
        public override int SortOrder => 24;
        public override int MinTier => 1;
    }
}
