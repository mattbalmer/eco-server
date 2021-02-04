// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.SearchAndSelect;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [LocDisplayName("Joshua Seed")]
    [Weight(50)]  
    [StartsDiscovered]
    public partial class JoshuaSeedItem : SeedItem
    {
        static JoshuaSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow a joshua tree."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Joshua"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [LocDisplayName("Joshua Seed Pack")]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class JoshuaSeedPackItem : SeedPackItem
    {
        static JoshuaSeedPackItem() { }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow a joshua tree."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Joshua"); } }
    }

}
