// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Housing;
    using Eco.Core.Items;
    using Eco.Core.Plugins.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Settlements;

    //Definitions for properties of the settlements system
    public class SettlementDefinitions : IModInit
    {
        public static void Initialize()
        {   
            //                                                      Homestead       Town        Country     Federation
            SettlementConfig.Obj.InfluenceRadii          = new[] {  15,             50,         100,        1000 };
            SettlementConfig.Obj.LandClaimsPerCitizen = new[] {  5,              10,         10,         10   };
        }
    }
}
