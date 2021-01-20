// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.SearchAndSelect;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Mods.TechTree;
    using Eco.Shared.Serialization;

    public partial class WorkbenchItem : WorldObjectItem<WorkbenchObject>, IPersistentData
    {
        [Serialized, TooltipChildren] object IPersistentData.PersistentData { get; set; }
    }
}
