﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Layers;

    public class WorldLayerSettingsFertileGround : WorldLayerSettings
    {
        public WorldLayerSettingsFertileGround() : base()
        {
            this.Name = "FertileGround";
            this.DisplayName = Localizer.DoStr("Fertile Ground");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0.6470588f, 0.1647059f, 0.1647059f);
            this.SumRelevant = false;
            this.Unit = string.Empty;
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.World;
            this.ValueType = WorldLayerValueType.FillRate;
            this.AreaDescription = string.Empty;

        }
    }
}
