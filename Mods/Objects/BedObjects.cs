// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Objects;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;
    using Eco.Core.Controller;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Property;
    using System.Threading.Tasks;
    using Eco.Core.Tests;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Interactions;
    using Eco.Shared.Items;
    using Eco.Core.Items;
    using Eco.Gameplay;
    using Eco.Gameplay.Utils;
    using System.Linq;
    using Eco.Gameplay.Systems.TextLinks;

    //Add Bed component to beds
    [RequireComponent(typeof(BedComponent))] public partial class WoodenFabricBedObject : WorldObject { public override LocString PickupConfirmation => this.GetComponent<BedComponent>().BedPickupConfirmation(); }
    [RequireComponent(typeof(BedComponent))] public partial class WoodenStrawBedObject : WorldObject { public override LocString PickupConfirmation => this.GetComponent<BedComponent>().BedPickupConfirmation(); }
    [RequireComponent(typeof(BedComponent))] public partial class CampsiteObject : WorldObject { public override LocString PickupConfirmation => this.GetComponent<BedComponent>().BedPickupConfirmation(); }

    //Bed component just has a button to open the sleep manager.
    [Serialized, AutogenClass, LocDisplayNameAttribute("Bed")]
    [Ecopedia(null, "Bed Component", display: InPageTooltip.CachedTooltip)]
    public class BedComponent : WorldObjectComponent, IChatCommandHandler, IInteractable
    {
        public override WorldObjectComponentClientAvailability Availability => WorldObjectComponentClientAvailability.UI;

        [RPC, Autogen, UITypeName("BigButton")]
        public void Sleep(Player player) { SleepManager.Obj.PlayerSleep(player, this.Parent); }

        public InteractResult OnActLeft(InteractionContext context) { return InteractResult.NoOp; }
        public InteractResult OnActRight(InteractionContext context) { return InteractResult.NoOp; }
        public InteractResult OnPreInteractionPass(InteractionContext context) => InteractResult.NoOp;

        public InteractResult OnActInteract(InteractionContext context)
        {
            if (context.Parameters != null && context.Parameters.ContainsKey("sleep")) 
            { 
                this.Sleep(context.Player);
                // If this bed is in a world object. Add the player to UsingUsers list.
                this.Parent?.IncrementUsing(context.Player);
                return InteractResult.Success; 
            }
            return InteractResult.NoOp;
        }

        /// <summary>Return a warning text if there's any sleeping user on this bed</summary>
        public LocString BedPickupConfirmation()
        {
            // Try to get a sleeping player on this bes
            var sleepingPlayer = this.Parent.UsingPlayers.Select(p => p.Target as Player).Where(p => SleepManager.Obj.IsPlayerAsleep(p.User)).FirstOrDefault();
            // return a confirmation text if there's a sleeping user
            return sleepingPlayer != null ? Localizer.Do($"Are you sure you want to remove {sleepingPlayer.User.UILink()}'s bed while they are sleeping in it? This is generally considered quite rude and uncouth.") : LocString.Empty;
        } 

        [ChatSubCommand("Test", "Spawn a bed and sleep in it.", ChatAuthorizationLevel.Developer)]
        public static void Bed(User user)
        {
            RoomChecker.SpawnBuilding(user, 1, new Vector3i(5, 5, 5), user.Player.Position.XYZi + Vector3i.Down - new Vector3i(2, 0, 2));
            var bed = WorldObjectDebugUtil.SpawnAndClaim<BedComponent>("WoodenFabricBedObject", user, user.Position.XYZi + Vector3i.Forward);
            Task.Delay(2000).Wait();
            bed.Sleep(user.Player);
        }

        public override void Destroy()
        {
            // Wake all the players are sleeping on this bed.
            PlayerUseTracking.ForEachPlayer(this.Parent.UsingPlayers, p => SleepManager.Obj.WakePlayerUp(p));
            base.Destroy();
        }
    }
}
