// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class WindowFormType : FormType
    {
        public override string Name => "Window";
        public override LocString DisplayName => Localizer.DoStr("Window");
        public override LocString DisplayDescription => Localizer.DoStr("Window");
        public override Type GroupType => typeof(ThinFormGroup);
        public override int SortOrder => 8;
        public override int MinTier => 1;
    }
}
