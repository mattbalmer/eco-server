// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Components;
    using System.ComponentModel;

    [RequireComponent(typeof(AirPollutionComponent))]
    public partial class AirPollutionGeneratorObject : WorldObject
    {
        protected override void PostInitialize()
        {
            this.GetComponent<AirPollutionComponent>().Initialize(10f);
        }
    }
}
