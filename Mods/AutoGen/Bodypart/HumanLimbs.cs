// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;

    [Serialized]
    [LocDisplayName("Human Limbs")]
    [Weight(0)]
    [Category("Hidden"), Tag("NotInBrowser")]
    public partial class HumanLimbsItem :
        ClothingItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Limbs"); } }
        public override string Slot                  { get { return ClothingSlot.Limbs; } } 
    }
}
