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

    public class Bison : AnimalEntity
    {
        public Bison(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;
        
        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class BisonSpecies : AnimalSpecies
        {
            public BisonSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Bison);

                // Info
                this.Name = "Bison";
                this.DisplayName = Localizer.DoStr("Bison");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() { typeof(CommonGrass), typeof(Bunchgrass), typeof(Wheat), typeof(BigBluestem), typeof(Switchgrass) };
                this.CalorieValue = 250f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(BisonCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(HerdAnimalBrain);
                this.WanderingSpeed = 1f;
                this.Speed = 4f;
                this.ClimbHeight = 1;
                this.Health = 10f;
                this.Damage = 1f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 0.6f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                this.HeadDistance = 1f;
                this.TimeLayToStand = 4f;
                this.TimeStandToLay = 3f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.2f;

                this.RotationSpeed = 45f;
                this.WanderingRotationSpeed = 22.5f;
                this.MinRotationToSlowDown = 10f;

            }
        }

        public override void FleeFrom(Vector3 position)
        {
            base.FleeFrom(position);
            GroupBehaviors.SyncFleePosition(this);
        }
    }
}
