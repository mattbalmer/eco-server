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
    using Eco.Shared.Utils;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Simulation.Types;
    using Eco.Simulation.WorldLayers;
    using Eco.Mods.TechTree;
    using Range = Eco.Shared.Math.Range;

    public class Otter : AnimalEntity
    {
        public Otter(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class OtterSpecies : AnimalSpecies
        {
            public OtterSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Otter);

                // Info
                this.Name = "Otter";
                this.DisplayName = Localizer.DoStr("Otter");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() {typeof(Clam), typeof(Urchin), typeof(Tuna), typeof(Salmon), typeof(Trout)};
                this.CalorieValue = 50f;
                // Movement
                this.Flying = false;
                this.Swimming = true;
                this.FloatOnSurface = true;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(OtterCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(AmphibiousBrain);
                this.WanderingSpeed = 0.5f;
                this.Speed = 3f;
                this.ClimbHeight = 1;
                this.Health = 1f;
                this.Damage = 1f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 1f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;
            }

            // Otters can spawn on land or water
            public override bool IsValidSpawnPathPos(Vector3i pos) { return true; }
        }
    }
}
