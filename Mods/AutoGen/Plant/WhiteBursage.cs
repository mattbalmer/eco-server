// Copyright (c) Strange Loop Games. All rights reserved.
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

    public partial class PlantLayerSettingsWhiteBursage : PlantLayerSettings
    {
        public PlantLayerSettingsWhiteBursage() : base()
        {
            this.Name = "WhiteBursage";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("White Bursage"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = new Range(0f, 0.333333f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "White Bursage";
            this.VoxelsPerEntry = 5;
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
    public partial class WhiteBursage : PlantEntity
    {
        public WhiteBursage(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public WhiteBursage() { }
        static PlantSpecies species;

        [Ecopedia("Plants", "Plants", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        public partial class WhiteBursageSpecies : PlantSpecies
        {
            public WhiteBursageSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(WhiteBursage);

                // Info
                this.Decorative = false;
                this.Name = "WhiteBursage";
                this.DisplayName = Localizer.DoStr("White Bursage");
                // Lifetime
                this.MaturityAgeDays = 0.5f;
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
                   new SpeciesResource(typeof(WhiteBursageSeedItem), new Range(1, 2), 0.1f),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                this.BlockType = typeof(WhiteBursageBlock);
                // Climate
                this.ReleasesCO2TonsPerDay = -0.0002f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0.001f;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Nitrogen", HalfSpeedConcentration =  0.4f, MaxResourceContent =  0.5f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Phosphorus", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.2f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Potassium", HalfSpeedConcentration =  0.2f, MaxResourceContent =  0.3f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "SoilMoisture", HalfSpeedConcentration =  0.3f, MaxResourceContent =  0.2f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  1 });
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "ShrubSpace", ConsumedCapacityPerPop =  4 }); 
                this.GenerationSpawnCountPerPoint = new Range(5, 9); 
                this.GenerationSpawnPointMultiplier = 0.2f; 
                this.BlanketSpawnPercent = 0.8f; 
                this.IdealTemperatureRange = new Range(0.75f, 0.9f);
                this.IdealMoistureRange = new Range(0.05f, 0.25f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.7f, 1);
                this.MoistureExtremes = new Range(0, 0.3f);
                this.MaxPollutionDensity = 0.7f;
                this.PollutionDensityTolerance = 0.1f;
                this.VoxelsPerEntry = 5;

            }
        }
    }
    [Serialized]
    [Reapable] 
    [Clearable]
    [MoveEfficiency(0.7f)] 
    public partial class WhiteBursageBlock :
        PlantBlock { } 
}
