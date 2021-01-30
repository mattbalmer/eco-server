// Copyright (c) Strange Loop Games. All rights reserved.
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

    public class SpeciesHabitabilityLayerSettingsWolfCapacity : SpeciesHabitabilityLayerSettings
    {
        public SpeciesHabitabilityLayerSettingsWolfCapacity() : base()
        {
            this.Species = "Wolf";
            this.HabitabilityComponents.Add( new ConsumerComponent() { CalorieConsumption = 250, Prey = new List<Type> { typeof(AnimalLayerSettingsElk), typeof(AnimalLayerSettingsHare), typeof(AnimalLayerSettingsMountainGoat), typeof(AnimalLayerSettingsDeer), typeof(AnimalLayerSettingsBison) } } );
            this.Name = "WolfCapacity";
            this.DisplayName = Localizer.DoStr("Wolf Capacity");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.OverrideRenderRange = null;
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
