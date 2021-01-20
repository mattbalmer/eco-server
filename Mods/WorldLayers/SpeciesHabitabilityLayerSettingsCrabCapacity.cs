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

    public class SpeciesHabitabilityLayerSettingsCrabCapacity : SpeciesHabitabilityLayerSettings
    {
        public SpeciesHabitabilityLayerSettingsCrabCapacity() : base()
        {
            this.Species = "Crab";
            this.HabitabilityComponents.Add(new ConsumerComponent() 
            { 
                CalorieConsumption = 150, Prey = new List<Type> 
                { 
                    typeof(AnimalLayerSettingsTuna), 
                    typeof(AnimalLayerSettingsSalmon), 
                    typeof(PlantLayerSettingsUrchin),
                    typeof(PlantLayerSettingsClam)
                } 
            });
            this.Name = "CrabCapacity";
            this.DisplayName = Localizer.DoStr("Crab Capacity");
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
