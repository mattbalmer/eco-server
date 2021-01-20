// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;

    public partial class AsphaltRampDFormType : FormType
    {
        public override string Name => "AsphaltRampD";
        public override LocString DisplayName => Localizer.DoStr("Asphalt RampD");
        public override LocString DisplayDescription => Localizer.DoStr("Asphalt RampD");
        public override Type GroupType => typeof(RampsFormGroup);
        public override int SortOrder => 75;
        public override int MinTier => 1;
    }
}
