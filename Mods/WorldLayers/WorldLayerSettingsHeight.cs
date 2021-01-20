﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers;
    using Eco.Simulation.WorldLayers.Layers;

    public class WorldLayerSettingsHeight : WorldLayerSettings
    {
        public WorldLayerSettingsHeight() : base()
        {
            this.Name = LayerNames.Height;
            this.DisplayName = Localizer.DoStr("Height");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 110f);
            this.RenderRange = new Range(60f, 77f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0.6470588f, 0.1647059f, 0.1647059f);
            this.SumRelevant = false;
            this.Unit = Localizer.DoStr("meters above bedrock");
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.World;
            this.ValueType = WorldLayerValueType.Amount;
            this.AreaDescription = string.Empty;
        }
    }
}
