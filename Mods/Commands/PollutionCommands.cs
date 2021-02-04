// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods
{
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Players;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Shared.Math;
    using Eco.Simulation.WorldLayers;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Items;
    using System.Linq;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Garbage;
    using System.Threading.Tasks;
    using Eco.Core.IoC;
    using Eco.Core.Tests;

    public class PollutionCommands : IChatCommandHandler
    {
        [ChatCommand("Performs commands for world pollution.", ChatAuthorizationLevel.Admin)]
        public static void Pollute(User user) { }

        [ChatSubCommand("Pollute", "Just in case you like living in TRASH CITY", ChatAuthorizationLevel.Admin)]
        public static void TrashCity(User user)
        {
            var randItems = Item.AllItems.Where(x => !x.IsCarried && !(x is TrashItem) && x.Category != "Hidden").ToList();

            // Needs to be in dedicated task, to prevent main thread hanging, which causes timeout
            Task.Run(() =>
            {
                for (var i = 0; i < 100000; i++)
                {
                    var pos       = World.GetTopGroundPos(World.GetRandomLandPos().XZ) + Vector3i.Up;
                    var inventory = new DecayingInventory(4, pos);
                    for (var j = 0; j < 4; j++)
                    {
                        inventory.AddItem(randItems.Random());
                        var rand = RandomUtil.Range(50, 43200);
                        inventory.StartTimers[j] = rand;
                        inventory.EndTimers[j]   = rand + 43200;
                    }
                    inventory.UpdateVisuals();
                    GarbageManager.Obj.RegisterDecayingInventory(pos, inventory);
                }
            });
        }

        [ChatSubCommand("Pollute", "Creates X tons of air pollution", ChatAuthorizationLevel.Admin)]
        public static void Air(User user, float tons) => WorldLayerManager.Obj.ClimateSim.AddAirPollutionTons(new WorldPosition3i(user.Position.XYZi), tons);

        [ChatSubCommand("Pollute", "Changes CO2 PPM by X", ChatAuthorizationLevel.Admin)]
        public static void CO2(User user, float ppm) => WorldLayerManager.Obj.ClimateSim.State.TotalCO2 += ppm;

        [CITest]
        [ChatSubCommand("Pollute", "Rains tailings from the heavens to ruin the world", ChatAuthorizationLevel.Admin)]
        public static void All(User user)
        {
            for (var i = 0; i < 1000; i++)
                World.SetBlock<TailingsBlock>(World.GetTopGroundPos(World.GetRandomLandPos().XZ) + Vector3i.Up);
        }

        [CITest]
        [ChatSubCommand("Pollute", "Creates AIR POLLUTION MACHINES OF DOOM", "apgen", ChatAuthorizationLevel.Developer)]
        public static void AirPollutionGenerators(User user)
        {
            for (var i = 0; i < 50; i++)
                WorldObjectManager.ForceAdd(ServiceHolder<IWorldObjectManager>.Obj.GetTypeFromName("AirPollutionGeneratorObject"), user, World.GetTopGroundPos(World.GetRandomLandPos().XZ) + Vector3i.Up, Quaternion.Identity);
        }
    }
}
