// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Animals;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Types;

    public class Elk : AnimalEntity
    {
        public Elk(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class ElkSpecies : AnimalSpecies
        {
            public ElkSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Elk);

                // Info
                this.Name = "Elk";
                this.DisplayName = Localizer.DoStr("Elk");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() 
                {
                    typeof(Huckleberry),
                    typeof(OceanSpray),
                    typeof(Fireweed),
                    typeof(Fern),
                    typeof(Beans),
                    typeof(Salal)
,                   typeof(DeerLichen),
                };
                this.CalorieValue = 200f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(ElkCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(LandAnimalBrain);
                this.WanderingSpeed = 1.2f;
                this.Speed = 5.5f;
                this.ClimbHeight = 1;
                this.Health = 6.1f;
                this.Damage = 1f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 1f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                this.HeadDistance = 1f;
                this.TimeLayToStand = 2.5f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;

            }
        }
    }
}
