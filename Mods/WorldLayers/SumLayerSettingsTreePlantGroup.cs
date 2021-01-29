// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Layers;

    public class SumLayerSettingsTreePlantGroup : SumLayerSettings
    {
        public SumLayerSettingsTreePlantGroup()
        {
            this.Name            = "TreePlantGroup";
            this.DisplayName     = Localizer.DoStr("Trees");
            this.InitMultiplier  = 1f;
            this.SyncToClient    = false;
            this.Range           = new Range(0f, 1f);
            this.MinColor        = new Color(1f, 1f, 1f);
            this.MaxColor        = new Color(0f, 1f, 0f);
            this.SumRelevant     = false;
            this.Unit            = string.Empty;
            this.VoxelsPerEntry  = 20;
            this.Category        = WorldLayerCategory.PlantGroup;
            this.ValueType       = WorldLayerValueType.FillRate;
            this.AreaDescription = string.Empty;
            this.Layers          = new[] { "Birch", "Cedar", "Redwood", "Fir", "Spruce" };
        }
    }
}
