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

    public class Jaguar : AnimalEntity
    {
        public Jaguar(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class JaguarSpecies : AnimalSpecies
        {
            public JaguarSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Jaguar);

                // Info
                this.Name = "Jaguar";
                this.DisplayName = Localizer.DoStr("Jaguar");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>()
                {
                    typeof(Hare),
                    typeof(Deer),
                    typeof(Wolf),
                    typeof(Agouti),
                    typeof(SnappingTurtle)
                };
                this.CalorieValue = 100f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(JaguarCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(LandPredatorBrain);
                this.IsPredator = true;
                this.WanderingSpeed = 1f;
                this.Speed = 6.5f;
                this.ClimbHeight = 1;
                this.Health = 4.5f;
                this.Damage = 5f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 0f;
                this.FleePlayers = true;
                this.AttackRange = 3f;
                this.HeadDistance = 1f;
                this.TimeAttackToIdle = 3f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;
            }
            
            // Jaguars can spawn on land or water
            public override bool IsValidSpawnPathPos(Vector3i pos) { return true; }
        }

        public override (bool, string) ShouldSleep => RelaxBehaviors.DaySleeper;
    }
}
