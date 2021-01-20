// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
#nullable enable
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Plants;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.World;

    [Tag("Harvester")]
    [Category("Hidden")]
    [Mower]
    public abstract partial class MacheteItem : ToolItem
    {
        static readonly LocString ClearString = Localizer.DoStr("Clear");

        public override ClientPredictedBlockAction LeftAction => ClientPredictedBlockAction.DestroyBlock;
        public override LocString LeftActionDescription => ClearString;

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock && context.Block!.Is<Clearable>())
                return (InteractResult)AtomicActions.DestroyPlantNow(this.CreateMultiblockContext(context), notify: false);

            if (context.Target is WorldObject) return this.BasicToolOnWorldObjectCheck(context);

            return base.OnActLeft(context);
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<Clearable>(block);
        }
    }
}
