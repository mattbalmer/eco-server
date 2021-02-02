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

    public partial class PlantLayerSettingsJointfir : PlantLayerSettings
    {
        public PlantLayerSettingsJointfir() : base()
        {
            this.Name = "Jointfir";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("Jointfir"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.OverrideRenderRange = new Range(0f, 0.333333f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "Jointfir";
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.Plant;
            this.ValueType = WorldLayerValueType.FillRate;
            this.AreaDescription = "";
            this.Subcategory = "Jointfir".AddSpacesBetweenCapitals();
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
    public partial class Jointfir : PlantEntity
    {
        public Jointfir(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public Jointfir() { }
        static PlantSpecies species;

        [Ecopedia("Plants", "Plants", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        [Tag("Plants")]
        public partial class JointfirSpecies : PlantSpecies
        {
            public JointfirSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Jointfir);

                // Info
                this.Decorative = false;
                this.Name = "Jointfir";
                this.DisplayName = Localizer.DoStr("Jointfir");
                // Lifetime
                this.MaturityAgeDays = 0.65f;
                // Generation
                this.Height = 1;
                // Food
                this.CalorieValue = 4;
                // Resources
                this.PostHarvestingGrowth = 0;
                this.PickableAtPercent = 0;
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(PlantFibersItem), new Range(2, 4), 1),
                   new SpeciesResource(typeof(JointfirSeedItem), new Range(1, 2), 0.1f),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                this.BlockType = typeof(JointfirBlock);
                // Climate
                this.ReleasesCO2TonsPerDay = -0.0002f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0.001f;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Phosphorus", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.2f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "SoilMoisture", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.05f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  4 });
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "ShrubSpace", ConsumedCapacityPerPop =  4 }); 
                this.GenerationSpawnCountPerPoint = new Range(5, 9); 
                this.GenerationSpawnPointMultiplier = 0.2f; 
                this.BlanketSpawnPercent = 0.8f; 
                this.IdealTemperatureRange = new Range(0.75f, 0.85f);
                this.IdealMoistureRange = new Range(0.1f, 0.25f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.7f, 1);
                this.MoistureExtremes = new Range(0.05f, 0.3f);
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
    public partial class JointfirBlock :
        PlantBlock { } 
}
