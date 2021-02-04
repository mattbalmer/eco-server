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

    public class Wolf : AnimalEntity
    {
        public Wolf(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class WolfSpecies : AnimalSpecies
        {
            public WolfSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Wolf);

                // Info
                this.Name = "Wolf";
                this.DisplayName = Localizer.DoStr("Wolf");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() { typeof(Hare), typeof(Elk), typeof(MountainGoat), typeof(Deer), typeof(Turkey), typeof(Bison) };
                this.CalorieValue = 100f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(WolfCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.GroupInPacks = true;
                this.BrainType = typeof(LandPredatorBrain);
                this.IsPredator = true;
                this.WanderingSpeed = 0.5f;
                this.Speed = 5f;
                this.ClimbHeight = 1;
                this.Health = 3.2f;
                this.Damage = 3f;
                this.ChanceToAttack = 0.6f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 0f;
                this.FleePlayers = true;
                this.AttackRange = 2.5f;
                this.HeadDistance = 0.8f;
                this.TimeLayToStand = 4f;
                this.TimeAttackToIdle = 3f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;
            }
        }

        public override (bool, string) ShouldSleep => RelaxBehaviors.DaySleeper;
    }
}
