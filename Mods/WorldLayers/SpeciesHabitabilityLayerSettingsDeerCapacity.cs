﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using System;
    using System.Collections.Generic;
    using Eco.Shared.Localization;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Components.Habitability;
    using Eco.Simulation.WorldLayers.Layers;
    using Range = Eco.Shared.Math.Range;

    public class SpeciesHabitabilityLayerSettingsDeerCapacity : SpeciesHabitabilityLayerSettings
    {
        public SpeciesHabitabilityLayerSettingsDeerCapacity() : base()
        {
            this.Species = "Deer";
            this.HabitabilityComponents.Add( new ConsumerComponent() { CalorieConsumption = 150, Prey = new List<Type> { typeof(PlantLayerSettingsHuckleberry), typeof(PlantLayerSettingsBeans), typeof(PlantLayerSettingsFern), typeof(PlantLayerSettingsSalal), typeof(PlantLayerSettingsSwitchgrass), typeof(PlantLayerSettingsTrillium), typeof(PlantLayerSettingsOak), typeof(PlantLayerSettingsCamas), typeof(PlantLayerSettingsPumpkin) } } );
            this.Name = "DeerCapacity";
            this.DisplayName = Localizer.DoStr("Deer Capacity");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = false;
            this.Unit = string.Empty;
            this.VoxelsPerEntry = 40;
            this.Category = WorldLayerCategory.Animal;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;

        }
    }
}
