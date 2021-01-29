// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers;
    using Eco.Simulation.WorldLayers.Layers;

    public class WorldLayerSettingsSaltWater : WorldLayerSettings
    {
        public WorldLayerSettingsSaltWater() : base()
        {
            this.Name            = LayerNames.SaltWater;
            this.DisplayName     = Localizer.DoStr("Salt Water");
            this.InitMultiplier  = 1f;
            this.SyncToClient    = false;
            this.Range           = new Range(0f, 1f);
            this.MinColor        = new Color(1f, 1f, 1f);
            this.MaxColor        = new Color(0f, 0.8f, 1f);
            this.SumRelevant     = false;
            this.Unit            = string.Empty;
            this.VoxelsPerEntry  = 5;
            this.Category        = WorldLayerCategory.World;
            this.ValueType       = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;

        }
    }
}
