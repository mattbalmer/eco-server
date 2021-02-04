// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;

    public partial class FrugalWorkspaceTalent
    {
        public override void OnLearned(User user)
        {
            base.OnLearned(user);
            ResetRoomRequirements(user);
        }
        public override void OnUnLearned(User user)
        {
            base.OnUnLearned(user);
            ResetRoomRequirements(user);
        }
        private static void ResetRoomRequirements(User user)
        {
            foreach (var obj in WorldObjectManager.GetOwnedBy(user))
            {
                var requirements = obj.GetComponent<RoomRequirementsComponent>();
                requirements?.MarkDirty();
            }
        }
    }
   
    

}
