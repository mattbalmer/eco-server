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
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.EcopediaRoot;

    [Serialized]
    [LocDisplayName("Raw Meat")]
    [Weight(100)]
    [Ecopedia("Food", "Meat", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RawMeatItem : FoodItem
    {
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Raw Meat"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Fresh raw meat from the hunt. It should probably be cooked before being consumed."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 8, Protein = 4, Vitamins = 0};
        public override float Calories                          { get { return 250; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}
