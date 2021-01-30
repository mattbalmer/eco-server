// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Components;
    using Eco.Simulation.WorldLayers.Layers;
    using Eco.World.Blocks;

    public class BiomeLayerSettingsOceanBiome : BiomeLayerSettings
    {
        public BiomeLayerSettingsOceanBiome() : base()
        {
            this.Name = "OceanBiome";
            this.DisplayName = Localizer.DoStr("Ocean Biome");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.OverrideRenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0.7f, 0.3f, 1.0f);
            this.SumRelevant = false;
            this.Unit = string.Empty;
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.Biome;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;
            this.Components.Add(new BiomeComponent() { TopBlock = typeof(OceanSandBlock) });

        }
    }

    public class BiomeLayerSettingsDeepOceanBiome : BiomeLayerSettings
    {
        public BiomeLayerSettingsDeepOceanBiome() : base()
        {
            this.Name = "DeepOceanBiome";
            this.DisplayName = Localizer.DoStr("Deep Ocean Biome");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.OverrideRenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0.7f, 0.3f, 1.0f);
            this.SumRelevant = false;
            this.Unit = string.Empty;
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.Biome;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;
            this.Components.Add(new BiomeComponent() { TopBlock = typeof(OceanSandBlock) });

        }
    }
}
