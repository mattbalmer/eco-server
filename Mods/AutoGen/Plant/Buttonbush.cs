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

    public partial class PlantLayerSettingsButtonbush : PlantLayerSettings
    {
        public PlantLayerSettingsButtonbush() : base()
        {
            this.Name = "Buttonbush";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("Buttonbush"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = new Range(0f, 0.333333f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "Buttonbush";
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
    public partial class Buttonbush : PlantEntity
    {
        public Buttonbush(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public Buttonbush() { }
        static PlantSpecies species;

        [Ecopedia("Plants", "Plants", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        public partial class ButtonbushSpecies : PlantSpecies
        {
            public ButtonbushSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Buttonbush);

                // Info
                this.Decorative = false;
                this.Name = "Buttonbush";
                this.DisplayName = Localizer.DoStr("Buttonbush");
                // Lifetime
                this.MaturityAgeDays = 0.5f;
                // Generation
                this.Height = 1;
                // Food
                this.CalorieValue = 0.5f;
                // Resources
                this.PostHarvestingGrowth = 0;
                this.PickableAtPercent = 0;
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(PlantFibersItem), new Range(1, 3), 1),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                this.BlockType = typeof(ButtonbushBlock);
                // Climate
                this.ReleasesCO2TonsPerDay = -0.0002f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0.001f;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Nitrogen", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.2f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Phosphorus", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.2f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Potassium", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.2f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  2 });
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "ShrubSpace", ConsumedCapacityPerPop =  5 }); 
                this.BlanketSpawnPercent = 0.6f; 
                this.IdealTemperatureRange = new Range(0.45f, 0.55f);
                this.IdealMoistureRange = new Range(0.65f, 0.75f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.4f, 0.6f);
                this.MoistureExtremes = new Range(0.6f, 0.8f);
                this.MaxPollutionDensity = 0.7f;
                this.PollutionDensityTolerance = 0.1f;
                this.VoxelsPerEntry = 5;

            }
        }
    }
    [Serialized]
    [Reapable] 
    [Clearable]
    [MoveEfficiency(0.3333f)] 
    public partial class ButtonbushBlock :
        PlantBlock { } 
}
