// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Objects;

    [RequireComponent(typeof(RegistrarComponent))]
    [RequireComponent(typeof(AuthDataTrackerComponent))]
    public partial class RegistrarObject : WorldObject
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            this.GetComponent<PropertyAuthComponent>().SetPublic();
        }
    }
}
