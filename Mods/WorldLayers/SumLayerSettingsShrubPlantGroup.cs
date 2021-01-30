// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Layers;

    public class SumLayerSettingsShrubPlantGroup : SumLayerSettings
    {
        public SumLayerSettingsShrubPlantGroup() : base()
        {
            this.Name = "ShrubPlantGroup";
            this.DisplayName = Localizer.DoStr("Shrubs");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 16f);
            this.OverrideRenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = false;
            this.Unit = string.Empty;
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.PlantGroup;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;
            this.Layers = new string[] {"Camas", "Bunchgrass", "Fern", "Huckleberry", "CommonGrass", "Wheat"};

        }
    }
}
