// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using Eco.Gameplay.Auth;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Mods.TechTree;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;

[Serialized]
[LocDisplayName("Blasting Charge")]
[Category("Hidden")]
public class BlastingChargeItem : ToolItem
{
    static IDynamicValue tier = new ConstantValue(0);
    static IDynamicValue caloriesBurn = new ConstantValue(1);
    private static IDynamicValue skilledRepairCost = new ConstantValue(1);

    public override ToolCategory ToolCategory { get { return ToolCategory.Unknown; } }

    public override LocString DisplayDescription { get { return Localizer.DoStr("Blasts appart rock."); } }


    public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.PickupBlock; } }
    public override LocString LeftActionDescription { get { return Localizer.DoStr("Pick Up"); } }

    public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }
    public override IDynamicValue Tier { get { return tier; } }
    public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }


    public override InteractResult OnActRight(InteractionContext context)
    {
        // if no block targeted then try place block in front of player
        if (!context.HasBlock || context.Block.Is<Solid>())
            return InteractResult.NoOp;

        //todo: make it use the hammer's calories and durability if it's selected
        Contract.Assume(context.BlockPosition != null);
        var blockPosition = context.BlockPosition.Value;
        return this.Blast(context, blockPosition);
    }

    public override InteractResult OnActLeft(InteractionContext context)
    {
        return InteractResult.NoOp;
    }

    public override bool ShouldHighlight(Type block)
    {
        return Block.Is<Solid>(block);
    }

    private InteractResult Blast(InteractionContext context, Vector3i blockPosition)
    {
        //todo: make it use the hammer's calories and durability if it's selected
        Vector3i minTop = blockPosition + new Vector3i(-2, -1, -2);
        Vector3i maxTop = blockPosition + new Vector3i(2, -1, 2);

        Vector3i minBottom = minTop + new Vector3i(0, -5, 0);
        Vector3i maxBottom = maxTop + new Vector3i(0, -5, 0);

        var pack = new GameActionPack();

        var range = new WorldRange(minBottom, maxTop);

        foreach (var blockPos in range.XYZIterInc())
        {
            var blockType = World.GetBlock(blockPos).GetType();
            if (RubbleObject.BecomesRubble(blockType))
            {
                AtomicActions.DeleteBlockNow(this.CreateMultiblockContext(context));
                RubbleObject.TrySpawnFromBlock(context.Player, blockType, blockPos, 4);
            }
        }

        return InteractResult.Success;
    }
}
