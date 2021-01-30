// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.IoC;
    using Eco.Core.Utils;
    using Eco.Gameplay.Auth;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Plants;
    using Eco.Shared.Math;
    using Eco.Simulation;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Stats;
    using Eco.Gameplay.GameActions;
    using Eco.Core.Items;
    using Eco.Gameplay.Aliases;
    using Eco.Shared.Items;
    using System.Collections.Generic;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Players;

    [Tag("Plow")]
    [Category("Tool")]
    [Tag("Tool", 1)]
    public partial class SteamTractorPlowItem : VehicleToolItem
    {
        // Item's area of effect (current position will be alternately shifted by these values to cause a block change).
        private static Vector3i[] area = new Vector3i[] { new Vector3i(0, -1, -2), new Vector3i(1, -1, -2), new Vector3i(-1, -1, -2) };

        public override void BlockInteraction(Vector3i pos, Quaternion rot, VehicleComponent vehicle, Inventory inv = null)
        {
            if (this.enabled)                                                   // Plow only if it's on.
                AtomicActions.ChangeBlockNow(newType: typeof(TilledDirtBlock),  // Create a pack, fill it with plow actions and try to perform.
                    context: new MultiblockActionContext() {
                        Player                = vehicle.Driver,
                        ToolUsed              = this,
                        GameActionConstructor = () => new PlowField(),
                        ActionDescription     = Localizer.DoStr("plow a block"),
                        Area                  = area.MoveAndRotate(pos, rot)    // Rotate area of effect and shift it to current position (and exclude repetitions from the result).
                                                    .Where(position => World.GetBlock(position).Is<Tillable>()) // Exclude untillable blocks.
                    });
        }
    }

    [Tag("Harvester")]
    [Category("Tool")]
    [Tag("Tool", 1)]
    public partial class SteamTractorHarvesterItem : VehicleToolItem
    {
        private static Vector3i[] area = new Vector3i[] { new Vector3i(0, 0, 3), new Vector3i(1, 0, 3), new Vector3i(-1, 0, 3) };

        public override void BlockInteraction(Vector3i pos, Quaternion rot, VehicleComponent vehicle, Inventory inv = null)
        {
            if (this.enabled) 
                AtomicActions.HarvestPlantNow(  // Create a pack, fill it with harvest actions and try to perform.
                    harvestTo:    inv, 
                    reapableOnly: false,        // Harvest every plant.
                    context:      new MultiblockActionContext() {
                        Player            = vehicle.Driver,
                        ToolUsed          = this,
                        ActionDescription = Localizer.DoStr("harvest plant"),
                        Area              = area.MoveAndRotate(pos, rot) // Rotate area of effect and shift it to current position (and exclude repetitions from the result).
                    });
        }
    }


    [Tag("Planter")]
    [Category("Tool")]
    [Tag("Tool", 1)]
    public partial class SteamTractorSowerItem : VehicleToolItem
    {
        private static Vector3i[] area = new Vector3i[] { new Vector3i(0, 0, 3), new Vector3i(1, 0, 3), new Vector3i(-1, 0, 3) };

        // TODO: create atomic actions covering the case and utilize them.
        public override void BlockInteraction(Vector3i pos, Quaternion rot, VehicleComponent vehicle, Inventory inv = null)
        {
            if (inv == null)
                return;

            if (!this.enabled)
                return;

            foreach (var offset in area)
            {
                var stack = inv.GroupedStacks.Where(x => x.Item is SeedItem).FirstOrDefault();
                if (stack == null)
                    return;
                SeedItem seed = stack.Item as SeedItem;
                var targetPos = (rot.RotateVector(offset) + pos).XYZi;
                Result authResult = ServiceHolder<IAuthManager>.Obj.IsAuthorized(targetPos, vehicle.Driver.User, AccessType.ConsumerAccess, null);
                if (authResult.Success)
                {
                    if (World.GetBlock(targetPos + Vector3i.Down).Is<Tilled>() && World.GetBlock(targetPos).Is<Empty>())
                    {
                        var pack = new GameActionPack();
                        pack.AddGameAction(new PlantSeeds()
                        {
                            Species = seed.Species.GetType(),
                            ActionLocation = targetPos,
                            Citizen = vehicle.Driver.User,
                            ToolUsed = this
                        });

                        var changes = new InventoryChangeSet(inv, vehicle.Driver.User);
                        changes.RemoveItem(seed.Type);
                        pack.AddChangeSet(changes);

                        if (pack.TryPerform())
                        {
                            var plant = EcoSim.PlantSim.SpawnPlant(seed.Species, targetPos);
                            plant.Tended = true;
                        }
                    }
                }
            }
        }
    }
}
