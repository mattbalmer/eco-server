// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class WhiteLineFormType : FormType
    {
        public override string Name => "WhiteLine";
        public override LocString DisplayName => Localizer.DoStr("Asphalt White Line");
        public override LocString DisplayDescription => Localizer.DoStr("Asphalt White Line");
        public override Type GroupType => typeof(BasicFormGroup);
        public override int SortOrder => 62;
        public override int MinTier => 1;
    }
}
