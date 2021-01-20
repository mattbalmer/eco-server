// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Mods.Organisms.Behaviors;
    using Eco.Gameplay.Animals;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.States;
	using Eco.Mods.TechTree;
    using Eco.Shared.Utils;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Simulation.Types;
    using Eco.Simulation.WorldLayers;
    using Range = Eco.Shared.Math.Range;

    public class Crab : AnimalEntity
    {
        public Crab(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Invertebrates", true, InPageTooltip.DynamicTooltip)]
        public class CrabSpecies : AnimalSpecies
        {
            public CrabSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Crab);
                // Info
                this.Name = "Crab";
                this.DisplayName = Localizer.DoStr("Crab");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() { typeof(Clam) };
                this.CalorieValue = 50f;
                // Movement
                this.Flying = false;
                this.Swimming = true;
                this.FloatOnSurface = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(CrabCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(AmphibiousBrain);
                this.IsPredator = false;
                this.WanderingSpeed = 0.2f;
                this.Speed = 0.5f;
                this.ClimbHeight = 0;
                this.Health = 3f;
                this.Damage = 3f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 1f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                this.HeadDistance = 1f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;
            }

            // Crabs can spawn on land or water
            public override bool IsValidSpawnPathPos(Vector3i pos) { return true; }
        }
    }
}
