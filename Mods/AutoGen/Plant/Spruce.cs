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

    public partial class PlantLayerSettingsSpruce : PlantLayerSettings
    {
        public PlantLayerSettingsSpruce() : base()
        {
            this.Name = "Spruce";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("Spruce"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = new Range(0f, 0.05f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "Spruce";
            this.VoxelsPerEntry = 20;
            this.Category = WorldLayerCategory.Plant;
            this.ValueType = WorldLayerValueType.FillRate;
            this.AreaDescription = "";
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
    public partial class Spruce : TreeEntity
    {
        public Spruce(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public Spruce() { }
        static TreeSpecies species;

        [Ecopedia("Plants", "Trees", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        public partial class SpruceSpecies : TreeSpecies
        {
            public SpruceSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Spruce);

                // Info
                this.Decorative = false;
                this.Name = "Spruce";
                this.DisplayName = Localizer.DoStr("Spruce");
                // Lifetime
                this.MaturityAgeDays = 5.5f;
                // Generation
                this.Height = 1;
                // Food
                this.CalorieValue = 15;
                // Resources
                this.PostHarvestingGrowth = 0;
                this.PickableAtPercent = 0;
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(SpruceLogItem), new Range(0, 50), 1),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                // Climate
                this.ReleasesCO2TonsPerDay = -0.1f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0.001f;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "SoilMoisture", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.5f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  5 });
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "CanopySpace", ConsumedCapacityPerPop =  26 }); 
                this.BlanketSpawnPercent = 0.5f; 
                this.IdealTemperatureRange = new Range(0.22f, 0.3f);
                this.IdealMoistureRange = new Range(0.25f, 0.45f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.2f, 0.32f);
                this.MoistureExtremes = new Range(0.2f, 0.55f);
                this.MaxPollutionDensity = 0.7f;
                this.PollutionDensityTolerance = 0.1f;
                this.VoxelsPerEntry = 20;

            }
        }
    }
}
