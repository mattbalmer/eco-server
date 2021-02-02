// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Items;
    using Eco.World.Blocks;
    using Eco.Shared.Serialization;
    using Eco.Shared.Localization;
    using Eco.Core.Items;

    [Serialized, Weight(18000)]
    [LocDisplayName("Tailings")]
    [MaxStackSize(10)]
    [RequiresTool(typeof(ShovelItem))]
    [Tag("Excavatable", 1)]
    [Ecopedia("Blocks", "Byproducts", true, InPageTooltip.DynamicTooltip)]
    public class TailingsItem : BlockItem<TailingsBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Tailings"); } }
        public override LocString DisplayDescription        { get { return Localizer.DoStr("Waste product from concentrating ore. When stored improperly the run-off will create pollution; killing nearby plants and seeping into the water supply. Bury deep underground to help neutralize the effect."); } }
        public override bool CanStickToWalls      { get { return false; } }
    }
}
