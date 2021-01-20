// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Gameplay.Aliases;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Economy.Contracts;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.UI;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;

    [Category("Tools")]
    [CarryTypesLimited]
    public partial class PropertyToolItem : ToolItem
    {
        static readonly IDynamicValue SkilledRepairCostValue               = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost                   => SkilledRepairCostValue;
        static InteractResult         ErrorAlreadyPublic                  => InteractResult.Failure(Localizer.DoStr("This plot is already public."));
        static InteractResult         ErrorNoNearby                       => InteractResult.Failure(Localizer.DoStr("There are no owned deeds nearby."));
        static InteractResult         ErrorBelongsTo(string owner)        => InteractResult.Failure(Localizer.Do($"This property belongs to {owner}."));
        public override float         InteractDistance                    => DefaultInteractDistance.Placement;
        public override float         DurabilityRate                      => 0f;        

        public override IEnumerable<InteractionDesc> GetInteractiveDescs(InteractionContext context)
        {
            Vector2i? position = this.GetPosition(context);
            User actor = context.Player.User;

            if (!position.HasValue) yield break;
            var plot = PropertyManager.GetPlot(position.Value);

            //Left
            if (plot?.Deed?.Owners?.Contains(actor) == true)
                if      (context.Modifier == InteractionModifier.Ctrl)  yield return new InteractionDesc(InteractionMethod.Left, Localizer.DoStr("Delete deed"),              InteractionModifier.Ctrl);
                else if (context.Modifier == InteractionModifier.Shift) yield return new InteractionDesc(InteractionMethod.Left, Localizer.DoStr("Move plot to nearby deed"), InteractionModifier.Shift);
                else                                                    yield return new InteractionDesc(InteractionMethod.Left, Localizer.DoStr("Unclaim land"));
            
            //Right
            if (plot?.Deed == null)
                if      (context.Modifier == InteractionModifier.Ctrl)  yield return new InteractionDesc(InteractionMethod.Right, Localizer.DoStr("Create new deed"),    InteractionModifier.Ctrl);
                else if (context.Modifier == InteractionModifier.Shift) yield return new InteractionDesc(InteractionMethod.Right, Localizer.DoStr("Add to nearby deed"), InteractionModifier.Shift);
                else                                                    yield return new InteractionDesc(InteractionMethod.Right, Localizer.DoStr("Claim land"));     
            
            //E
            else if (plot != null)                                      yield return new InteractionDesc(InteractionMethod.Interact, Localizer.DoStr("Examine claim"));
        }


        // Place to claim
        public override InteractResult OnActRight(InteractionContext context)
        {
            var position = this.GetPosition(context);

            if (!position.HasValue) return InteractResult.NoOp;

            // todo: need refactoring, it now always creates deed even if claim action failed afterwards (if claim failed then it wil cause Deed to be deleted). Both these processes causes lot of extra logic called including callbacks and db modifications.
            var actor = context.Player.User;
            var deed  = PropertyManager.GetDeed(position.Value);
            if (deed == null)
            {
                // ctrl + click
                if (context.Modifier == InteractionModifier.Ctrl) deed = PropertyManager.CreateDeed();

                // shift + click
                else if (context.Modifier == InteractionModifier.Shift)
                {
                    var nearbyDeeds = PropertyManager.NearbyDeeds(actor, position.Value, 3)?.Distinct();
                    if (nearbyDeeds != null && nearbyDeeds.Count() > 0)
                        if (nearbyDeeds.Count() == 1) deed = nearbyDeeds.First(); // There's only one deed nearby, no need for a dialog.
                        else                                                      // Proceed to the dialog method and await there for the selection result.
                        {
                            ClaimWithDialog(actor.Player, nearbyDeeds, position.Value);
                            return InteractResult.NoOp;
                        }
                    else deed = PropertyManager.CreateDeed();                     // No deeds around => create one.
                }

                // regular click
                else deed = PropertyManager.FindNearbyDeedOrCreate(actor, position.Value);
            }
            return DoClaim(deed, actor, position.Value, false);
        }

        public static InteractResult DoClaim(Deed deed, User actor, Vector2i position, bool notify = true)
        {   // Try to perform the claiming action
            Result claimResult = AtomicActions.ClaimNow(deed, actor, actor.Inventory, position, notify);
            if (!claimResult.Success && !deed.OwnedObjects.Any()) PropertyManager.TryRemoveDeed(deed);
            return (InteractResult)claimResult;
        }

        public static async void ClaimWithDialog(Player player, IEnumerable<Deed> nearbyDeeds, Vector2i position)
        {   // Get names and show the dialog
            var options    =     new List<string>(); foreach (var d in nearbyDeeds) options.Add(d.Name);
            var selection  =     await player.OptionBox(Localizer.DoStr("Select a deed for this plot"), options);
            if (selection != -1) DoClaim(nearbyDeeds.ElementAt(selection), player.User, position);  // If the dialog was not cancelled.
        }
        
        public static async void ChangeWithDialog(Player player, IEnumerable<Deed> nearbyDeeds, Vector2i position)
        {   // Get names and show the dialog
            var plot = PropertyManager.GetPlot(position);
            if (plot.Owners?.Contains(player.User) != true) return;

            var options    =     new List<string>(); foreach (var d in nearbyDeeds) options.Add(d.Name);
            var selection  =     await player.OptionBox(Localizer.DoStr("Select a deed for this plot"), options);
            if (selection != -1)
            {
                var initialDeed = plot.Deed;
                var targetDeed  = nearbyDeeds.ElementAt(selection);
                if (targetDeed != initialDeed) initialDeed.MoveOwnable(player, plot, targetDeed); 
            }
        }

        public static async void DeleteWithDialog(Player player, Deed deed)
        {
            try
            {
                if (await player?.ConfirmBox(Localizer.Do($"Do you wish to completely unclaim {deed?.MarkedUpName}?")))
                    deed?.DeleteDeed(player);
            }
            catch (Exception e)
            {
                Log.WriteException(e);
            }
        }

        // Hit to unclaim
        public override InteractResult OnActLeft(InteractionContext context)
        {
            Vector2i? position = this.GetPosition(context);
            Player player = context.Player;


            if (!position.HasValue) return InteractResult.NoOp;
            var plot = PropertyManager.GetPlot(position.Value);
            var deed = plot?.Deed;
            if (deed == null) return ErrorAlreadyPublic;

            // shift + click
            if (context.Modifier == InteractionModifier.Shift)
            {
                var nearbyDeeds = PropertyManager.NearbyDeeds(player.User, position.Value, 3)?.Distinct();
                if (nearbyDeeds != null && nearbyDeeds.Count() > 0) ChangeWithDialog(player, nearbyDeeds, position.Value);
                else return ErrorNoNearby;
                return InteractResult.NoOp;
            }

            // ctrl + click
            else if (context.Modifier == InteractionModifier.Ctrl)
            {
                DeleteWithDialog(player, deed);
                return InteractResult.NoOp; //
            }

            // regular click
            else return (InteractResult)PropertyManager.TryUnclaim(new GameActionPack(), player.User, player.User.Inventory, position.Value, autoPerform: true);  
        }


        // Interact to examine
        public override InteractResult OnActInteract(InteractionContext context)
        {
            Vector2i? position = this.GetPosition(context);

            if (!position.HasValue)
                return InteractResult.NoOp;

            Deed deed = PropertyManager.GetDeed(position.Value);

            if (deed != null)
            {
                deed.OpenAuthorizationMenuOn(context.Player);
                return InteractResult.Success;
            }

            return base.OnActLeft(context);
        }

        private Vector2i? GetPosition(InteractionContext context)
        {
            if (context.BlockPosition.HasValue)
                return context.BlockPosition.Value.XZ;
            else if (context.HitPosition.HasValue)
                return context.HitPosition.Value.XZi;
            else
                return null;
        }
        
        public override void OnSelected(Player player)
        {
            base.OnSelected(player);
            if (player != null) player.SetShowPropertyState(true);
        }
        
        public override void OnDeselected(Player player)
        {
            base.OnDeselected(player);
            if (player != null) player.SetShowPropertyState(false);
        }
    }
}
