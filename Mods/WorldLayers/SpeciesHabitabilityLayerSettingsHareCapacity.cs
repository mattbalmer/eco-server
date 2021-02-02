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

    public class SpeciesHabitabilityLayerSettingsHareCapacity : SpeciesHabitabilityLayerSettings
    {
        public SpeciesHabitabilityLayerSettingsHareCapacity() : base()
        {
            this.Species = "Hare";
            this.HabitabilityComponents.Add( new ConsumerComponent()
                {
                CalorieConsumption = 75, Prey = new List<Type>
                {
                    typeof(PlantLayerSettingsCamas),
                    typeof(PlantLayerSettingsWheat), //Plains Plants
                    typeof(PlantLayerSettingsBunchgrass),
                    typeof(PlantLayerSettingsCorn),
                    typeof(PlantLayerSettingsHuckleberry),
                    typeof(PlantLayerSettingsBigBluestem),
                    typeof(PlantLayerSettingsPricklyPear), //Desert Plants
                    typeof(PlantLayerSettingsCreosoteBush),
                    typeof(PlantLayerSettingsJointfir),
                    typeof(PlantLayerSettingsAgave)
                }
            } );
            this.Name = "HareCapacity";
            this.DisplayName = Localizer.DoStr("Hare Capacity");
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
