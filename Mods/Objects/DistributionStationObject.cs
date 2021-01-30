// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.GameActions;
    using Eco.Core.Utils;

    [RequireComponent(typeof(ItemDistributionComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(MustBeOwnedComponent))]
    [RequireComponent(typeof(NameDataTrackerComponent))]
    public partial class DistributionStationObject : StockpileObject, IGameActionAware
    {
        public Result ShouldOverrideAuth(GameAction action) { return WorldObjectUtil.ShouldOverrideAuth(this, action);  }
        public void ActionPerformed(GameAction action)      { WorldObjectUtil.ActionPerformed(this, action);     }
    }
}
