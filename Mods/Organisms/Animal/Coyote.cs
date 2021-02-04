// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Animals;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
	using Eco.Mods.TechTree;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Time;
    using Eco.Simulation.Types;
    using Eco.Mods.Organisms.Behaviors;

    public class Coyote : AnimalEntity
    {
        public Coyote(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;
        
        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class CoyoteSpecies : AnimalSpecies
        {
            public CoyoteSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Coyote);

                // Info
                this.Name = "Coyote";
                this.DisplayName = Localizer.DoStr("Coyote");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() {typeof(Hare), typeof(BighornSheep), typeof(Deer), typeof(Tortoise), typeof(Turkey), typeof(Otter)};
                this.CalorieValue = 100f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(CoyoteCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(LandPredatorBrain);
                this.IsPredator = true;
                this.WanderingSpeed = 0.5f;
                this.Speed = 4.5f;
                this.ClimbHeight = 1;
                this.Health = 5.5f;
                this.Damage = 3f;
                this.ChanceToAttack = 0.6f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 0f;
                this.FleePlayers = true;
                this.AttackRange = 2.5f;
                this.HeadDistance = 0.5f;
                this.TimeLayToStand = 4f;
                this.TimeAttackToIdle = 3f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;
            }
        }

        public override (bool, string) ShouldSleep => RelaxBehaviors.DaySleeper;
    }
}
