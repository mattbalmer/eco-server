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
    using Eco.Simulation.Types;

    public class Deer : AnimalEntity
    {
        public Deer(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class DeerSpecies : AnimalSpecies
        {
            public DeerSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Deer);

                // Info
                this.Name = "Deer";
                this.DisplayName = Localizer.DoStr("Deer");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() {typeof(Huckleberry), typeof(Fern), typeof(Beans), typeof(Salal), typeof(Switchgrass), typeof(Bunchgrass), typeof(Wheat), typeof(DeerLichen), typeof(Trillium)};
                this.CalorieValue = 180f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(DeerCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(LandAnimalBrain);
                this.WanderingSpeed = 1f;
                this.Speed = 5.5f;
                this.ClimbHeight = 1;
                this.Health = 4.5f;
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

        public override void FleeFrom(Vector3 position)
        {
            base.FleeFrom(position);
            GroupBehaviors.SyncFleePosition(this);
        }
    }
}
