﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Agents;
    using Eco.Core.Serialization;
    using Eco.Core.Tests;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.World;

    public class AvatarCommands : IChatCommandHandler
    {
        private static List<WorldObserver> dummyPlayers = new List<WorldObserver>();

        [ChatCommand("Performs avatars manipulation commands.")]
        public static void Avatar(User user) { }

        [CITest(clientDependent: true)]
        [ChatSubCommand("Avatar", "Spawns a dummy avatar", ChatAuthorizationLevel.Developer)]
        public static void Dummy(User user, int count = 1)
        {
            count = count > 1 ? count : 1;
            for (int i = 0; i < count; ++i)
            {
                MakeDummy(user.Player);
            }
        }

        [CITest(clientDependent: true)]
        [ChatSubCommand("Avatar", "Spawns passed number of clones of your avatar", ChatAuthorizationLevel.Developer)]
        public static void MeTime(User user, int count = 1)
        {
            count = count > 1 ? count : 1;
            for (int i = 0; i < count; ++i)
            {
                MakeDummy(user.Player, user);
            }
        }

        [CITest(clientDependent: true)]
        [ChatSubCommand("Avatar", "Kills all spawned dummys", ChatAuthorizationLevel.Developer)]
        public static void LastPlayerOnEarth()
        {
            while (dummyPlayers.Count > 0)
                KillDummy(dummyPlayers.Last() as Player);
        }

        [CITest(clientDependent: true)]
        [ChatSubCommand("Avatar", "Toggles Third Person Camera", ChatAuthorizationLevel.User)]
        public static void ThirdPerson(User user)
        {
            user.Player.RPC("ToggleThirdPerson");
        }

        public static Player MakeDummy(Player player, User sourceUser = null)
        {
            var name = "Dummy #" + dummyPlayers.Count;
            var user = UserManager.GetOrCreateUser(name, name, name);
            user.Position = World.GetRandomLandPosNear(player.User.Position.XYZi) + new Vector3(0.0f, 0.5f, 0.0f);
            user.MarkDirty();
            var dummy = new Player(user, 30f, null);

            if (sourceUser != null)
            {
                dummy.User.OverrideInventory(sourceUser.Inventory);
                dummy.User.OverrideAvatar(sourceUser.Avatar);
            }

            dummyPlayers.Add(dummy);

            return dummy;
        }

        private static void KillDummy(Player dummy)
        {
            NetObjectManager.Remove(dummy);
            dummy.User.Logout();
            dummyPlayers.Remove(dummy as WorldObserver);
        }
    }
}
