﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [LocDisplayName("Normal Hair")]
    [Category("Hidden"), Tag("NotInBrowser")]
    public partial class NormalHairItem :
        ClothingItem        
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("The hair with a completely normal amount of flare."); } }
        public override string Slot             { get { return ClothingSlot.Hair; } }             
        public override bool Starter            { get { return true ; } }                       

    }

}
