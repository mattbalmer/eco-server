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

    public partial class PlantLayerSettingsCriminiMushroom : PlantLayerSettings
    {
        public PlantLayerSettingsCriminiMushroom() : base()
        {
            this.Name = "CriminiMushroom";
            this.DisplayName = string.Format("{0} {1}", Localizer.DoStr("Crimini Mushroom"), Localizer.DoStr("Population"));
            this.InitMultiplier = 1;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = new Range(0f, 0.333333f);
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 1f, 0f);
            this.SumRelevant = true;
            this.Unit = "Crimini Mushroom";
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
    public partial class CriminiMushroom : PlantEntity
    {
        public CriminiMushroom(WorldPosition3i mapPos, PlantPack plantPack) : base(species, mapPos, plantPack) { }
        public CriminiMushroom() { }
        static PlantSpecies species;

        [Ecopedia("Plants", "Fungi", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
        public partial class CriminiMushroomSpecies : PlantSpecies
        {
            public CriminiMushroomSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(CriminiMushroom);

                // Info
                this.Decorative = false;
                this.Name = "CriminiMushroom";
                this.DisplayName = Localizer.DoStr("Crimini Mushroom");
                this.IsConsideredNearbyFoodDuringSpawnCheck = true; 
                // Lifetime
                this.MaturityAgeDays = 0.5f;
                // Generation
                this.Height = 1;
                // Food
                this.CalorieValue = 1;
                // Resources
                this.PostHarvestingGrowth = 0;
                this.PickableAtPercent = 0;
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(CriminiMushroomsItem), new Range(1, 3), 1),
                   new SpeciesResource(typeof(CriminiMushroomSporesItem), new Range(1, 2), 0.2f),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Visuals
                this.BlockType = typeof(CriminiMushroomBlock);
                // Climate
                this.ReleasesCO2TonsPerDay = -0.0001f;
                // WorldLayers
                this.MaxGrowthRate = 0.02f;
                this.MaxDeathRate = 0.01f;
                this.SpreadRate = 0.001f;
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "Potassium", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.2f });
                this.ResourceConstraints.Add(new ResourceConstraint() { LayerName = "SoilMoisture", HalfSpeedConcentration =  0.1f, MaxResourceContent =  0.1f }); 
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "FertileGround", ConsumedCapacityPerPop =  3.6f });
                this.CapacityConstraints.Add(new CapacityConstraint() { CapacityLayerName = "ShrubSpace", ConsumedCapacityPerPop =  3.6f }); 
                this.BlanketSpawnPercent = 0.8f; 
                this.IdealTemperatureRange = new Range(0.45f, 0.75f);
                this.IdealMoistureRange = new Range(0.65f, 0.85f);
                this.IdealWaterRange = new Range(0, 0.1f);
                this.WaterExtremes = new Range(0, 0.2f);
                this.TemperatureExtremes = new Range(0.4f, 0.8f);
                this.MoistureExtremes = new Range(0.6f, 0.9f);
                this.MaxPollutionDensity = 0.7f;
                this.PollutionDensityTolerance = 0.1f;
                this.VoxelsPerEntry = 5;

            }
        }
    }
    [Serialized]
    [Clearable]
    public partial class CriminiMushroomBlock :
        InteractablePlantBlock { } 
}
