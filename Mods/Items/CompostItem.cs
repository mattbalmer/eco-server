// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Shared.Serialization;
    using Eco.Shared.Localization;

    [Serialized]
    [LocDisplayName("Compost")]
    [Weight(30000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(ShovelItem))]
    [Tag("Excavatable", 1)]
    [Ecopedia("Blocks", "Byproducts", true, InPageTooltip.DynamicTooltip)]
    public class CompostItem : BlockItem<CompostBlock>
    {
        public override LocString DisplayNamePlural  { get { return Localizer.DoStr("Compost"); } }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Delicious decomposed organic matter that can be used to fertilze crops. Compost is created overtime when organic material is left outdoors to decompose.\n\nThis is accomplished in Eco by dropping an organic item on the ground and overtime it will become Compost."); }  }
    }
}
