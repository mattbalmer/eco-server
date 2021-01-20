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

    public partial class PlantLayerSettingsBigBluestem : PlantLayerSettings
    {
        public PlantLayerSettingsBigBluestem() : base()
        {
            this.Name = "BigBluestem";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("Big Bluestem"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = new Range(0f, 0.333333f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "Big Bluestem";
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
    public partial class BigBluestem : PlantEntity
    {
        public BigBluestem(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public BigBluestem() { }
        static PlantSpecies species;

        [Ecopedia("Plants", "Plants", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        public partial class BigBluestemSpecies : PlantSpecies
        {
            public BigBluestemSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(BigBluestem);

                // Info
                this.Decorative = false;
                this.Name = "BigBluestem";
                this.DisplayName = Localizer.DoStr("Big Bluestem");
                // Lifetime
                this.MaturityAgeDays = 0.65f;
                // Generation
                this.Height = 1;
                // Food
                this.CalorieValue = 4;
                // Resources
                this.PostHarvestingGrowth = 0.2f;
                this.ScythingKills = false; 
                this.PickableAtPercent = 0;
                this.RequireHarvestable = false; 
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(PlantFibersItem), new Range(2, 5), 1),
                   new SpeciesResource(typeof(BigBluestemSeedItem), new Range(1, 2), 0.1f),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                this.BlockType = typeof(BigBluestemBlock);
                // Climate
                this.ReleasesCO2TonsPerDay = -0.0002f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0.001f;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Nitrogen", HalfSpeedConcentration =  0.01f, MaxResourceContent =  0.01f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Phosphorus", HalfSpeedConcentration =  0.01f, MaxResourceContent =  0.01f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Potassium", HalfSpeedConcentration =  0.01f, MaxResourceContent =  0.01f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "SoilMoisture", HalfSpeedConcentration =  0.01f, MaxResourceContent =  0.02f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  1 }); 
                this.BlanketSpawnPercent = 1; 
                this.IdealTemperatureRange = new Range(0.63f, 0.79f);
                this.IdealMoistureRange = new Range(0.32f, 0.48f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.6f, 0.82f);
                this.MoistureExtremes = new Range(0.28f, 0.52f);
                this.MaxPollutionDensity = 0.7f;
                this.PollutionDensityTolerance = 0.1f;
                this.VoxelsPerEntry = 5;

            }
        }
    }
    [Serialized]
    [Reapable] 
    [Clearable]
    [MoveEfficiency(0.8f)] 
    public partial class BigBluestemBlock :
        PlantBlock { } 
}
