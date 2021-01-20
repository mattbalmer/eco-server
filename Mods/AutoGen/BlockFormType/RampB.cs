// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class RampBFormType : FormType
    {
        public override string Name => "RampB";
        public override LocString DisplayName => Localizer.DoStr("RampB");
        public override LocString DisplayDescription => Localizer.DoStr("RampB");
        public override Type GroupType => typeof(RampsFormGroup);
        public override int SortOrder => 34;
        public override int MinTier => 1;
    }
}
