// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.Items;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

[Serialized]
[LocDisplayName("Garbage")]
[Weight(30000)]
[MaxStackSize(10)]
[RequiresTool(typeof(ShovelItem))]
[Tag("Excavatable", 1)]
[Ecopedia("Blocks", "Byproducts", true, InPageTooltip.DynamicTooltip)]
public partial class GarbageItem : BlockItem<GarbageBlock>
{
    public override LocString DisplayNamePlural { get { return Localizer.DoStr("Garbage"); } }
    public override LocString DisplayDescription { get { return Localizer.DoStr("A disgusting pile of garbage. Unpleasant to the eye and a source of ground pollution. Bury underground to help mitigate the effect."); } }
    public override bool CanStickToWalls { get { return false; } }
}
[Serialized]
[Category("Hidden")]
[MaxStackSize(1), Tag("Object")]
public partial class TrashItem : Item { }

[Serialized]
[Category("Hidden")]
[MaxStackSize(1), Tag("Object")]
public partial class CompostablesItem : Item { }
