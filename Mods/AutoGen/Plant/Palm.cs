﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    }
// WORLD LAYER INFO
namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Layers;

    public partial class PlantLayerSettingsPalm : PlantLayerSettings
    {
        public PlantLayerSettingsPalm() : base()
        {
            this.Name = "Palm";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("Palm"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.OverrideRenderRange = new Range(0f, 0.05f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "Palm";
            this.VoxelsPerEntry = 20;
            this.Category = WorldLayerCategory.Plant;
            this.ValueType = WorldLayerValueType.FillRate;
            this.AreaDescription = "";
            this.Subcategory = "Palm".AddSpacesBetweenCapitals();
        }
    }
}

namespace Eco.Mods.Organisms
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Plants;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Simulation;
    using Eco.Simulation.Types;
    using Eco.World.Blocks;

    [Serialized]
    public partial class Palm : TreeEntity
    {
        public Palm(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public Palm() { }
        static TreeSpecies species;

        [Ecopedia("Plants", "Trees", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        [Tag("Plants")]
        public partial class PalmSpecies : TreeSpecies
        {
            public PalmSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Palm);

                // Info
                this.Decorative = false;
                this.Name = "Palm";
                this.DisplayName = Localizer.DoStr("Palm");
                // Lifetime
                this.MaturityAgeDays = 4.5f;
                // Generation
                this.Height = 1;
                // Food
                this.CalorieValue = 12;
                // Resources
                this.PostHarvestingGrowth = 0;
                this.ScythingKills = false; 
                this.PickableAtPercent = 0;
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(PalmLogItem), new Range(0, 30), 1),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                // Climate
                this.ReleasesCO2TonsPerDay = -0.0375f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0.0001f;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "SoilMoisture", HalfSpeedConcentration =  0.0f, MaxResourceContent =  1.0f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  1 });
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "CanopySpace", ConsumedCapacityPerPop =  5 }); 
                this.BlanketSpawnPercent = 0.7f; 
                this.IdealTemperatureRange = new Range(0.6f, 0.8f);
                this.IdealMoistureRange = new Range(0.75f, 0.95f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.6f, 0.8f);
                this.MoistureExtremes = new Range(0.7f, 1);
                this.MaxPollutionDensity = 0.7f;
                this.PollutionDensityTolerance = 0.1f;
                this.VoxelsPerEntry = 20;

            }
        }
    }
}
