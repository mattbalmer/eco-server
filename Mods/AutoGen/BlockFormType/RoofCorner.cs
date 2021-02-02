// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    public partial class RoofCornerFormType : FormType
    {
        public override string Name => "RoofCorner";
        public override LocString DisplayName => Localizer.DoStr("Roof Corner");
        public override LocString DisplayDescription => Localizer.DoStr("Roof Corner");
        public override Type GroupType => typeof(RoofsFormGroup);
        public override int SortOrder => 57;
        public override int MinTier => 1;
    }
}
