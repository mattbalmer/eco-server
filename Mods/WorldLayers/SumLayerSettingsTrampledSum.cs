// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers;
    using Eco.Simulation.WorldLayers.Layers;

    public class SumLayerSettingsTrampledSum : SumLayerSettings
    {
        public SumLayerSettingsTrampledSum() : base()
        {
            this.Name            = LayerNames.TrampledSum;
            this.DisplayName     = Localizer.DoStr("Trampled Sum");
            this.InitMultiplier  = 1f;
            this.SyncToClient    = false;
            this.Range           = new Range(0f, 1f);
            this.MinColor        = new Color(1f, 1f, 1f);
            this.MaxColor        = new Color(1f, 0.5f, 0.5f);
            this.SumRelevant     = false;
            this.Unit            = string.Empty;
            this.VoxelsPerEntry  = 5;
            this.Category        = WorldLayerCategory.Pollution;
            this.ValueType       = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;
            this.Layers          = new[] { LayerNames.PlayerTrampled, LayerNames.Debris };
        }
    }
}
