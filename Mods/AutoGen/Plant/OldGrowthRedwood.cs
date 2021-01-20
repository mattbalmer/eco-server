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

    public partial class PlantLayerSettingsOldGrowthRedwood : PlantLayerSettings
    {
        public PlantLayerSettingsOldGrowthRedwood() : base()
        {
            this.Name = "OldGrowthRedwood";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("Old Growth Redwood"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = new Range(0f, 0.05f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "Old Growth Redwood";
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
    public partial class OldGrowthRedwood : TreeEntity
    {
        public OldGrowthRedwood(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public OldGrowthRedwood() { }
        static TreeSpecies species;

        [Ecopedia("Plants", "Trees", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        public partial class OldGrowthRedwoodSpecies : TreeSpecies
        {
            public OldGrowthRedwoodSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(OldGrowthRedwood);

                // Info
                this.Decorative = false;
                this.NoSpread = true; 
                this.Name = "OldGrowthRedwood";
                this.DisplayName = Localizer.DoStr("Old Growth Redwood");
                this.DisplayDescription = Localizer.DoStr("Old growth redwood trees develop over centuries, with some living trees being over 2000 years old. Unlike most trees, these are a non-renewable resource and will not grow back if harvested.");
                // Lifetime
                this.MaturityAgeDays = 0.5f;
                // Generation
                this.Height = 1;
                // Food
                this.CalorieValue = 50;
                // Resources
                this.PostHarvestingGrowth = 0;
                this.ScythingKills = false; 
                this.PickableAtPercent = 0;
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(RedwoodLogItem), new Range(450, 500), 1),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                // Climate
                this.ReleasesCO2TonsPerDay = -0.2f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "SoilMoisture", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.7f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  20 });
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "CanopySpace", ConsumedCapacityPerPop =  26 }); 
                this.GenerationSpawnCountPerPoint = new Range(1, 2); 
                this.GenerationSpawnPointMultiplier = 0.05f; 
                this.BlanketSpawnPercent = 0.1f; 
                this.IdealTemperatureRange = new Range(0.35f, 0.48f);
                this.IdealMoistureRange = new Range(0.52f, 0.58f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.32f, 0.5f);
                this.MoistureExtremes = new Range(0.5f, 0.6f);
                this.MaxPollutionDensity = 0.7f;
                this.PollutionDensityTolerance = 0.1f;
                this.VoxelsPerEntry = 20;

            }
        }
    }
}
