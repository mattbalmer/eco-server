﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// This file modified by @mbalmer eco-custom-server script

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;

    public partial class StorageSiloObject : WorldObject
    {
        protected override void PostInitialize()
        {
            base.PostInitialize();
            this.GetComponent<LinkComponent>().Initialize(20);
            this.GetComponent<PublicStorageComponent>().Storage.AddInvRestriction(new SiloRestriction());
        }
    }

    public partial class PoweredStorageSiloObject : WorldObject
    {
        protected override void PostInitialize()
        {
            base.PostInitialize();
            this.GetComponent<LinkComponent>().Initialize(20);
            this.GetComponent<PublicStorageComponent>().Storage.AddInvRestriction(new SiloRestriction());
        }
    }
}
