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

    public partial class PlantLayerSettingsSalal : PlantLayerSettings
    {
        public PlantLayerSettingsSalal() : base()
        {
            this.Name = "Salal";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("Salal"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.OverrideRenderRange = new Range(0f, 0.333333f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "Salal";
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.Plant;
            this.ValueType = WorldLayerValueType.FillRate;
            this.AreaDescription = "";
            this.Subcategory = "Salal".AddSpacesBetweenCapitals();
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
    public partial class Salal : PlantEntity
    {
        public Salal(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public Salal() { }
        static PlantSpecies species;

        [Ecopedia("Plants", "Plants", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        [Tag("Plants")]
        public partial class SalalSpecies : PlantSpecies
        {
            public SalalSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Salal);

                // Info
                this.Decorative = false;
                this.Name = "Salal";
                this.DisplayName = Localizer.DoStr("Salal");
                // Lifetime
                this.MaturityAgeDays = 0.8f;
                // Generation
                this.Height = 1;
                // Food
                this.CalorieValue = 4;
                // Resources
                this.PostHarvestingGrowth = 0;
                this.PickableAtPercent = 0;
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(PlantFibersItem), new Range(1, 3), 1),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                this.BlockType = typeof(SalalBlock);
                // Climate
                this.ReleasesCO2TonsPerDay = -0.0001f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0.001f;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Nitrogen", HalfSpeedConcentration =  0.08f, MaxResourceContent =  0.1f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Phosphorus", HalfSpeedConcentration =  0.05f, MaxResourceContent =  0.1f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Potassium", HalfSpeedConcentration =  0.05f, MaxResourceContent =  0.1f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "SoilMoisture", HalfSpeedConcentration =  0.05f, MaxResourceContent =  0.05f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  1 }); 
                this.BlanketSpawnPercent = 0.8f; 
                this.IdealTemperatureRange = new Range(0.22f, 0.48f);
                this.IdealMoistureRange = new Range(0.52f, 0.58f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.19f, 0.5f);
                this.MoistureExtremes = new Range(0.48f, 0.6f);
                this.MaxPollutionDensity = 0.7f;
                this.PollutionDensityTolerance = 0.1f;
                this.VoxelsPerEntry = 5;

            }
        }
    }
    [Serialized]
    [Reapable] 
    [Clearable]
    [MoveEfficiency(0.75f)] 
    public partial class SalalBlock :
        PlantBlock { } 
}
