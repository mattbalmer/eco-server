﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    public partial class RoadBarrierFormType : FormType
    {
        public override string Name => "RoadBarrier";
        public override LocString DisplayName => Localizer.DoStr("Road Barrier");
        public override LocString DisplayDescription => Localizer.DoStr("Road Barrier");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 81;
        public override int MinTier => 1;
    }
}
