// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Shared.Serialization;
    using Eco.Shared.Localization;

    [Serialized]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(LiquidConverterComponent))]
    [Category("Hidden")]
    public partial class LiquidCrafterObject :
        WorldObject,
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Liquid Crafter"); } }
        public virtual Type RepresentedItemType { get { return typeof(LiquidCrafterItem); } }

        protected override void Initialize()
        {
            this.GetComponent<LiquidConverterComponent>().Setup(Item.Get("WaterItem").Type, Item.Get("SewageItem").Type, this.NamedOccupancyOffset("InputPort"), this.NamedOccupancyOffset("OutputPort"), 1f, 0f);
        }
    }

    [Serialized]
    [LocDisplayName("Liquid Converter")]
    [Category("Hidden")]
    public partial class LiquidCrafterItem :
        WorldObjectItem<LiquidCrafterObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Example crafting table that uses liquids."); } }
    }
}
