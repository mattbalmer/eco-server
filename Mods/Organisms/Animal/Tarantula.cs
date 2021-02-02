// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Animals;
    using Eco.Mods.Organisms.Behaviors;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Time;
    using Eco.Simulation.Types;

    public class Tarantula : AnimalEntity
    {
        public Tarantula(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Invertebrates", true, InPageTooltip.DynamicTooltip)]
        public class TarantulaSpecies : AnimalSpecies
        {
            public TarantulaSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Tarantula);

                // Info
                this.Name = "Tarantula";
                this.DisplayName = Localizer.DoStr("Tarantula");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() {  };
                this.CalorieValue = 100f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    //new SpeciesResource(typeof(TarantulaCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(LandPredatorBrain);
                this.IsPredator = true;
                this.WanderingSpeed = 0.7f;
                this.Speed = 1f;
                this.ClimbHeight = 0;
                this.Health = 0.5f;
                this.Damage = 3f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 1f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                this.HeadDistance = 0.1f;
                this.TimeLayToStand = 4f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;
                // Tags
                this.Tags = new[] { "spider" };
            }
        }

        public override (bool, string) ShouldSleep => RelaxBehaviors.DaySleeper;
    }
}
