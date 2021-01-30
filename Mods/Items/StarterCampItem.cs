// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using Eco.Core.IoC;
    using Eco.Core.Utils;
    using Eco.Gameplay.Auth;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Items;
    using Eco.Shared.Networking;
    using Eco.Shared.Voxel;
    using Eco.Gameplay.Settlements;

    [Serialized]
    [LocDisplayName("Starter Camp")]
    public class StarterCampItem : WorldObjectItem<StarterCampObject>
    {
        private static WorldRange virtualOccupancy = new WorldRange(new Vector2i(-2, -2), new Vector2i(3, 3)); // A world range that will always occupy 4 plots.
        private int bonusPapers = 0; // TryPlaceObject will claim four plots without papers. If some of the plots are already claimed, then bonus papers will be placed to the camp's inventory.
        public override LocString DisplayDescription => Localizer.DoStr("A combination of a small tent and a tiny stockpile.");

        public override void OnAreaValid(GameActionPack pack, Player player, Vector3i position, Quaternion rotation)
        {
            var deed = PropertyManager.FindConnectedDeedOrCreate(player.User, position.XZ);

            foreach (var plotPosition in PlotUtil.GetAllPropertyPos(position, virtualOccupancy))
            {
                if (!this.IsPlotAuthorized(plotPosition, player.User, out var canClaimPlot))
                    return;

                if (canClaimPlot)
                    pack.ClaimProperty(deed, player.User, player.User.Inventory, plotPosition, requirePapers: false);
            }

            if (!pack.EarlyResult)
                return;

            pack.AddPostEffect(()=>
            { 
                var camp      = WorldObjectManager.ForceAdd(typeof(CampsiteObject), player.User, position, rotation, false);
                var stockpile = WorldObjectManager.ForceAdd(typeof(TinyStockpileObject), player.User, position + rotation.RotateVector(Vector3i.Right * 3), rotation, false);
                player.User.OnWorldObjectPlaced.Invoke(camp);
                player.User.Markers.Add(camp.Position3i + Vector3i.Up, camp.UILinkContent(), false);
                var storage   = camp.GetComponent<PublicStorageComponent>();
                var changeSet = new InventoryChangeSet(storage.Inventory);
                PlayerDefaults.GetDefaultCampsiteInventory().ForEach(x => changeSet.AddItems(x.Key, x.Value, storage.Inventory));

                //If we're running a settlement system, create the homestead item now and fill it with homestead-specific claim papers.
                if (SettlementPluginConfig.Obj.SettlementSystemEnabled)
                {
                    var marker = WorldObjectManager.ForceAdd(typeof(HomesteadMarkerObject), player.User, position + rotation.RotateVector(new Vector3i(3, 0, 3)), rotation, false);
                    var markerComp = marker.GetComponent<SettlementMarkerComponent>();
                    markerComp.Settlement.Citizenship.AddSpawnedClaims(this.bonusPapers);
                    markerComp.UpdateSpawnedClaims();
                }
                else
                { 
                    //For the old system, add the papers to the tent.
                    if (this.bonusPapers > 0) changeSet.AddItems(typeof(PropertyClaimItem), this.bonusPapers);
                }
                changeSet.Apply();

            });
        }

        public override bool ShouldCreate => false;

        public override bool TryPlaceObject(Player player, Vector3i position, Quaternion rotation) => this.TryPlaceObject(player, position, rotation, out _);

        public override void TryPlaceObject(Player player, Vector3i position, Quaternion rotation, Action successCallback)
        {
            if (!this.TryPlaceObject(player, position, rotation, out var canOwn))
                return;

            if (canOwn)
            {
                successCallback();
                return;
            }

            player.Client.RPCAsync<bool>("PopupConfirmBox", player.Client, Localizer.Format("Do you want to place {0} on another player's property? The player become an owner of {0} and you can be removed from the property at any moment", this.UILink()))
                .ContinueWith(t => { if (t.Result) successCallback(); });
        }

        private bool TryPlaceObject(Player player, Vector3i position, Quaternion rotation, out bool canOwn)
        {
            this.bonusPapers = 0;
            if (!this.TryPlaceObjectOnSolidGround(player, position, rotation))
            {
                canOwn = false;
                return false;
            }

            canOwn = true;

            foreach (var pos in PlotUtil.GetAllPropertyPos(position, virtualOccupancy))
            {
                var plot = PropertyManager.GetPlot(pos);
                if (plot == null || plot.DeedId == Guid.Empty)        continue;   // Unowned plot.
                if (plot.Owners == player.User) { this.bonusPapers++; continue; } // Already claimed, increase amount of bonus papers.               

                canOwn = false;
                var result = ServiceHolder<IAuthManager>.Obj.IsAuthorized(plot.Position, player.User, AccessType.ConsumerAccess, null);
                if (!result.Success)
                {
                    player.Error(result.Message);
                    return false;
                }
            }

            return true;
        }

        private Result IsPlotAuthorized(Vector2i pos, User user, out bool canClaim)
        {
            var plot = PropertyManager.GetPlot(pos);
            if (plot == null || plot.DeedId == Guid.Empty)
            {
                canClaim = true;
                return Result.Succeeded;
            }

            canClaim = false;
            return plot.Owners == user ? Result.Succeeded : ServiceHolder<IAuthManager>.Obj.IsAuthorized(plot.Position, user, AccessType.ConsumerAccess, null);
        }

        SettlementType? SettleType {get
        { 
            if (SettlementPluginConfig.Obj.SettlementSystemEnabled) return SettlementType.Homestead; 
            else return null;
        } }

        public override void OnSelected(Player player)
        {
            base.OnSelected(player);
            player?.SetPropertyClaimingMode(virtualOccupancy, this.SettleType); // Add camp's virtual occupancy to player's property selector so it could highlight four plots at once.
        }
        
        public override void OnDeselected(Player player)
        {
            base.OnDeselected(player);
            player?.StopPropertyClaimingMode();
        }
    }

    [Serialized]
    public class StarterCampObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Starting Camp"); } }
    }
}
