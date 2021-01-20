﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
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
    public partial class DiverTalent : Talent
    {
        public override bool Base { get { return true; } }
    }

    [Serialized]
    [LocDisplayName("Diver: SelfImprovement")]
    public partial class SelfImprovementDiverTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("WIP (No Function)");

        public SelfImprovementDiverTalentGroup()
        {
            Talents = new Type[]
            {
            
            typeof(SelfImprovementDiverSpeedTalent), 
            
            
            };
            this.OwningSkill = typeof(SelfImprovementSkill);
            this.Level = 3;
        }
    }

    
    [Serialized]
    public partial class SelfImprovementDiverSpeedTalent : DiverTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(SelfImprovementDiverTalentGroup); } }
        public SelfImprovementDiverSpeedTalent()
        {
            this.Value = 1.2f;
        }
    }
    
    
    
}
