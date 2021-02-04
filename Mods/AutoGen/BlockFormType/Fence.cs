﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    public partial class FenceFormType : FormType
    {
        public override string Name => "Fence";
        public override LocString DisplayName => Localizer.DoStr("Fence");
        public override LocString DisplayDescription => Localizer.DoStr("Fence");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 12;
        public override int MinTier => 1;
    }
}
