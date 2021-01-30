// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Utils;

    public partial class MiningSweepingHandsTalent
    {
        public readonly int PickUpRange = 4;

        public override void RegisterTalent(User user)
        {
            base.RegisterTalent(user);
            user.OnPickupingObject.Add(this.ApplyAction);
        }
        public override void UnRegisterTalent(User user)
        {
            base.UnRegisterTalent(user);
            user.OnPickupingObject.Remove(this.ApplyAction);
        }
        void ApplyAction(User user, INetObject target, INetObject tool, GameActionPack pack)
        {
            // only apply talent when object picked up by hands, not with tool like excavator or skid steer
            if (tool != null) return;
            if (target is RubbleObject rubble)
                this.ApplyTalent(user, rubble, pack);
        }

        private void ApplyTalent(User user, RubbleObject target, GameActionPack pack)
        {
            if (!(target is IRepresentsItem representsItem))
                return;

            var itemType = representsItem.RepresentedItemType;
            // max stack size minus currently picking item
            var numToTake = Item.GetMaxStackSize(itemType) - 1;
            if (numToTake <= 0)
                return;

            var carrying = user.Carrying;
            if (!carrying.Empty())
            {
                // ReSharper disable once PossibleNullReferenceException because Empty checked
                if (carrying.Item.Type != itemType || carrying.Quantity >= numToTake)
                    return;
                // adjust to currently carrying item count
                numToTake -= carrying.Quantity;
            }
            
            //Get the changeset already in the action pack
            var numTaken = 0;
            var player = user.Player;
            var userInventory = user.Inventory;
            var checkedPlots = new Dictionary<Vector2i, bool>(); // A dictionary to cache auth checks for objects within the same plots.

            foreach (var rubble in NetObjectManager.GetObjectsWithin(target.Position, this.PickUpRange).OfType<RubbleObject>())
            {
                var plotPosition  = rubble.Position.XZi.ToPlotPosition();
                var positionIsNew = !checkedPlots.ContainsKey(plotPosition);

                if (!positionIsNew && !checkedPlots[plotPosition]) continue; // If we already failed to pickup something on this plot position, there's no need to proceed (we'll fail auth again).
                if (rubble == target || rubble.IsBreakable) continue;
                if (!(rubble is IRepresentsItem rubbleRepresentsItem) || rubbleRepresentsItem.RepresentedItemType != itemType)
                    continue;
                
                var addedToPack = pack.PickupRubbles(player, userInventory, rubble.SingleItemAsEnumerable(), itemType, checkAuthFirst: positionIsNew, notificate: false); // Check auth before adding to the pack if the position is new.
                if (addedToPack && ++numTaken == numToTake) break;

                if (positionIsNew) checkedPlots.Add(plotPosition, addedToPack); // Add auth check for this plot to the dictionary.
            }
        }
    }
}
