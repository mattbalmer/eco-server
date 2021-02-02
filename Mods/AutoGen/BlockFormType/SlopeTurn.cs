// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    public partial class SlopeTurnFormType : FormType
    {
        public override string Name => "SlopeTurn";
        public override LocString DisplayName => Localizer.DoStr("Slope Turn");
        public override LocString DisplayDescription => Localizer.DoStr("Slope Turn");
        public override Type GroupType => typeof(SlopesFormGroup);
        public override int SortOrder => 19;
        public override int MinTier => 1;
    }
}
