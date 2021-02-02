// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.Blocks;
    using Eco.Shared.Localization;
    using Eco.World.Blocks;
    [NextRamp(typeof(AsphaltRampDFormType), 0)]    
    public partial class AsphaltRampCFormType : FormType
    {
        public override string Name => "AsphaltRampC";
        public override LocString DisplayName => Localizer.DoStr("Asphalt RampC");
        public override LocString DisplayDescription => Localizer.DoStr("Asphalt RampC");
        public override Type GroupType => typeof(RampsFormGroup);
        public override int SortOrder => 74;
        public override int MinTier => 1;
    }
}
