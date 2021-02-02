// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    public partial class PeakSetFormType : FormType
    {
        public override string Name => "PeakSet";
        public override LocString DisplayName => Localizer.DoStr("Peak Set");
        public override LocString DisplayDescription => Localizer.DoStr("Peak Set");
        public override Type GroupType => typeof(SlopesFormGroup);
        public override int SortOrder => 47;
        public override int MinTier => 1;
    }
}
