// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Linq;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Items;
using Eco.Shared.Math;
using Eco.Shared.Utils;
using Eco.Shared.Serialization;
using Eco.Simulation;
using Eco.Simulation.Agents;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.DynamicValues;
using Eco.Shared.Localization;
using Eco.Gameplay.Rooms;
using Eco.Gameplay.Players;
using Eco.Shared.Networking;
using System.Threading.Tasks;
using Eco.Gameplay.Systems.Chat;
using System.Collections.Generic;
using System.Text;
using Eco.Core.Utils;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Gameplay.UI;

[Serialized]
[LocDisplayName("Dev Tool")]
[IgnoreAuth]
[BuilderCheat]
[Tier(10, false)]
[Category("Hidden")]
public class DevtoolItem : HammerItem
{
    public override LocString DisplayDescription  { get { return Localizer.DoStr("DOES CHEATER THINGS THROUGH CHEATING POWERS"); } }

    private static IDynamicValue skilledRepairCost = new ConstantValue(1);
    public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }
    private static IDynamicValue tier = new ConstantValue(4);
    public override IDynamicValue Tier { get { return tier; } }

    public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.DestroyBlock; } }
    public override LocString LeftActionDescription          { get { return Localizer.DoStr("Smite"); } }

    public override float DurabilityRate => 0.0f;

    public override InteractResult OnActLeft(InteractionContext context)
    {
        if (context.HasBlock && !context.Block.Is<Impenetrable>())
        {
            World.DeleteBlock(context.BlockPosition.Value);
            var plant = EcoSim.PlantSim.GetPlant(context.BlockPosition.Value + Vector3i.Up);
            if (plant != null)
                EcoSim.PlantSim.DestroyPlant(plant, DeathType.DivineIntervention);

            RoomData.QueueRoomTest(context.BlockPosition.Value);
            return InteractResult.Success;
        }
        else if (context.HasTarget)
        {
            if (context.Target != null)
            {
                if (context.Target is WorldObject obj)          WorldObjectManager.DestroyPermanently(obj);
                if (context.Target is PickupableBlock)          World.DeleteBlock(context.BlockPosition.Value);
                else if (context.Target is RubbleObject)        (context.Target as RubbleObject).Destroy();
                else if (context.Target is TreeEntity)          (context.Target as TreeEntity).Destroy();
                else if (context.Target is Animal)              (context.Target as Animal).Destroy();
            }
            return InteractResult.Success;
        }
        else
            return InteractResult.NoOp;
    }

    public override InteractResult OnActInteract(InteractionContext context)
    {
        if (context.HasBlock)
        {
            var item = BlockItem.CreatingItem(context.Block.GetType());
            if (item != null)
            {
                // Adds max item count with key modifier, else => 1
                var count = context.Modifier == InteractionModifier.Ctrl ? item.MaxStackSize : 1;
                context.Player.User.Inventory.ReplaceStack(context.Player, context.Player.User.Inventory.Carried.Stacks.First(), item.TypeID, count);
            }
        }
        return InteractResult.NoOp;
    }

    [Tooltip(200)]
    public TooltipSection ControllsTooltip(TooltipContext context)
    {
        var res = new StringBuilder();

        res.AppendLine(Localizer.DoStr("Can smite any block or world object."));
        res.AppendLine(Localizer.DoStr("Can be used as a hammer to place infinite amount of blocks."));
        res.AppendLine(Localizer.DoStr("Can ignore auth for different actions (storage, vehicles, blocks)."));
        res.AppendLine(Localizer.DoStr("Can copy world block to carried slot with \"E\", hold \"Ctrl\" to add whole stack."));

        return new TooltipSection(Localizer.DoStr("Special Actions"), res.ToStringLoc());
    }

    public override void OnUsed(Player player, ItemStack itemStack)
    {
        player.PopupTypePicker(Localizer.DoStr("Pick Material for DevTool"), typeof(BlockItem), material => this.SetMaterial(material, player));
    }

    private void SetMaterial(List<Type> result, Player player)
    {
        if (result.Count() == 0) return;

        //Put the first in the carry slot.
        player.User.Carrying.Modify(Item.Get(result[0]), 1);
        
        //Put the rest in the toolbar.
        int index = 1;
        foreach(var stack in player.User.Inventory.Toolbar.Stacks.Where(x=>!(x.Item is ToolItem)))
        { 
            if (index >= result.Count()) break;
            var entry = result[index++];
            stack.Modify(Activator.CreateInstance(entry) as Item, 1);
        }
        AdminCommands.CarryAll(player.User, true);

        //Select the dev tool
        player.User.Inventory.Toolbar.SelectType(player, this.GetType());
    }

    public override bool ShouldHighlight(Type block) => true;
}
