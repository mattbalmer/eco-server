// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.ComponentModel;
    using Eco.Core.Controller;
    using Eco.Core.IoC;
    using Eco.Core.Items;
    using Eco.Core.Utils;
    using Eco.Gameplay.Auth;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Utils;
    using Eco.Gameplay.Wires;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;
    using Eco.Simulation.Time;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Aliases;
    using Eco.Shared.Items;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay;
    using Eco.Gameplay.UI;

    //This Toll object demonstrates the use of auto-generated UI for components, check out the attributes assigned to the members and compare to the UI it creates.
    //A toll object will, when triggered (either by a user paying for it or by the owner using it), send an activation to any touching objects, using wires to transmit.  
    //Use /testtolls to get an example in-game.
    [Serialized]
    [LocDisplayName("Toll")]
    [Category("Hidden")]
    public class TollItem : WorldObjectItem<TollObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Toggle on any touching wires and electronic objects.");
    }

    [Serialized]
    [RequireComponent(typeof(TollComponent))]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(MustBeOwnedComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public class TollObject : WorldObject
    {
        static TollObject()
        {
            AddOccupancyList(typeof(TollObject), new BlockOccupancy(Vector3i.Zero, typeof(SolidWorldObjectBlock)));
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            this.GetComponent<PropertyAuthComponent>().SetPublic();
        }

        public override LocString DisplayName { get { return Localizer.DoStr("Toll"); } }
    }


    [Serialized, AutogenClass, LocDisplayName("Toll")]
    [Tag("Economy"), Category("Hidden")]
    public class TollComponent : SwitchComponent, IChatCommandHandler
    {
        [Serialized] private Currency currencyHandle;
        [SyncToView, Autogen, AutoRPC] public Currency Currency                   { get { return this.currencyHandle; } set { this.currencyHandle = value; } }
        [SyncToView, Autogen, AutoRPC, Serialized] public float Toll              { get; set; }
        [SyncToView, Autogen, AutoRPC, Serialized] public float TimeBeforeTurnOff { get; set; }
        [Eco] public BankAccount TargetBankAccount { get; set; }
        [Serialized] double worldTimeToReactivate = 0f;

        public TollComponent()
        {
            this.Toll = 1f;
            this.TimeBeforeTurnOff = 10f;
            this.OnChanged.Add(this.OnStateChanged);
        }

        void OnStateChanged(bool on)
        {
            //Start the timer to turn off.
            if (on && this.TimeBeforeTurnOff != 0)
                this.worldTimeToReactivate = WorldTime.Seconds + this.TimeBeforeTurnOff;
        }

        [RPC, Autogen, OwnerHidden, GuestEditable] public void PayToll(Player player)
        {
            if (!this.Enabled)                 { player.ErrorLocStr("Toll is disabled. Check status."); return; }
            if (this.Authed(player))           { player.ErrorLocStr("Since you're authorized, toll is not required.  Triggered switch."); return; }
            if (this.Parent.Owners == null)    { player.ErrorLocStr("Object does not have an owner, cannot be used."); return; }
            if (this.On)                       { player.ErrorLocStr("Toll is already activated, wait for it to expire (owner can turn off manually)."); return; }

            if (Transfers.TryTransferWithTaxIncluded( 
                new GameActionPack(),
                TransferType.TollPayment,
                BankAccountManager.Obj.GetPersonalBankAccount(player.DisplayName),
                this.TargetBankAccount, 
                this.Currency,
                player.User,
                this.Parent.Owners?.OneUser(),
                Localizer.Format("Paid toll at {0}", this.Parent.UILink()),
                Localizer.DoStr("Direct Transfer Taxes"),
                true,
                this.Toll,
                EconomyManager.Tax.GetDirectTransferTax(this.Currency)))
                this.DoSwitch(player);
        }

        public override void OnCreate()                                          { this.Currency = CurrencyManager.GetPlayerCurrency(this.Parent.NameOfCreator); }
        public override InteractResult OnActInteract(InteractionContext context) { return InteractResult.NoOp; }
        public override InteractResult OnActLeft(InteractionContext context)     { return this.TryActivate(context.Player); }
        public override InteractResult OnActRight(InteractionContext context)    { return this.TryActivate(context.Player); }

        public override void Tick()
        {
            if (this.worldTimeToReactivate > 0f && this.On && WorldTime.Seconds > this.worldTimeToReactivate)
                this.Switch(null);
        }

        bool Authed(Player player)
        {
            IAlias @alias = player != null ? player.User : null;
            return ServiceHolder<IAuthManager>.Obj.IsAuthorized(this.Parent, alias, AccessType.FullAccess, null);
        }

        InteractResult TryActivate(Player player)
        {
            if (this.Authed(player))
            { 
                this.DoSwitch(player);
                return InteractResult.Success;
            }
            return InteractResult.Failure(Localizer.DoStr("You don't have access to directly switch this; you must pay the toll."));
        }

        [ChatSubCommand("Build", "Create a test toll object triggering some basic stuff.", ChatAuthorizationLevel.Developer)]
        public static void TollTrigger(User user)
        {
            var otherUser = TestUtils.OtherUser(user);
            var station   = WorldObjectDebugUtil.SpawnAndClaim<TollComponent>("TollObject", otherUser, user.Position.XZi);
            var door      = WorldObjectDebugUtil.SpawnAndClaim("DoorObject", otherUser, user.Position.XZi + Vector2i.Right);
        }
    }
}
