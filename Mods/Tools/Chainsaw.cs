// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Core.Items;
    using Eco.Shared.Localization;

    [Tag("Logging")]
    public partial class ChainsawItem : AxeItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A motorized saw used for chopping trees."); } }
    }
}
