// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers;
    using Eco.Simulation.WorldLayers.Layers;

    public class SpreadLayerSettingsSaltWaterSpread : SpreadLayerSettings
    {
        public SpreadLayerSettingsSaltWaterSpread() : base()
        {
            this.HeightLayerName = "Height";
            this.Name = "SaltWaterSpread";
            this.DisplayName = Localizer.DoStr("Salt Water Spread");
            this.InitMultiplier = 1f;
            this.SyncToClient = true;
            this.Range = new Range(0f, 1f);
            this.OverrideRenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 0.8f, 1f);
            this.SumRelevant = false;
            this.Unit = string.Empty;
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.World;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;
            this.SpreadRate = 0.9f;
            this.ZeroAtHeightDiff = 5f;
            this.SourceInfluenceRate = 1f;
            this.BaseLayerName = LayerNames.SaltWater;

        }
    }
}
