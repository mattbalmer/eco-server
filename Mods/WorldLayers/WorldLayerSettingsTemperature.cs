// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Layers;

    public class WorldLayerSettingsTemperature : TemperatureLayerSettings
    {
        public WorldLayerSettingsTemperature()
        {
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.CelsiusRange = new Range(-10f, 30f);
            this.OverrideRenderRange = null;
            this.MinColor = new Color(0f, 0.5f, 1f);
            this.MaxColor = new Color(1f, 0.5f, 0.5f);
            this.SumRelevant = false;
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.World;
            this.AreaDescription = string.Empty;
        }
    }
}
