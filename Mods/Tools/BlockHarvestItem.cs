// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Plants;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.World;

    // Wrapper for tools like sickle and scythe, contains same code
    public abstract partial class BlockHarvestItem : ToolItem
    {
        public override ClientPredictedBlockAction LeftAction => ClientPredictedBlockAction.Harvest;

        public override LocString LeftActionDescription => Localizer.DoStr("Reap");

        public override bool ShouldHighlight(Type block) => Block.Is<Reapable>(block);

        public override InteractResult OnActLeft(InteractionContext context)
        {
            // Try harvest.
            if (context.HasBlock && context.Block.Is<Reapable>()) return (InteractResult)AtomicActions.HarvestPlantNow(this.CreateMultiblockContext(context), context.Player?.User.Inventory);

            // Try interact with a world object.
            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            // Fallback.
            return base.OnActLeft(context);
        }
    }
}
