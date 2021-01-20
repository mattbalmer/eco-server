﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Layers;

    public class WorldLayerSettingsRainfall : WorldLayerSettings
    {
        public WorldLayerSettingsRainfall() : base()
        {
            this.Name = "Rainfall";
            this.DisplayName = Localizer.DoStr("Rainfall");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(-0.2f, 1.1f);
            this.RenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 0.5f, 1f);
            this.SumRelevant = false;
            this.Unit = string.Empty;
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.Moisture;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;

        }
    }
}
