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

    public class Hare : AnimalEntity
    {
        public Hare(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class HareSpecies : AnimalSpecies
        {
            public HareSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Hare);

                // Info
                this.Name = "Hare";
                this.DisplayName = Localizer.DoStr("Hare");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() {typeof(Camas), typeof(Wheat), typeof(Bunchgrass), typeof(Corn), typeof(Huckleberry), typeof(BigBluestem), typeof(CreosoteBush), typeof(PricklyPear), typeof(Agave)};
                this.CalorieValue = 30f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(HareCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(HerdAnimalBrain);
                this.WanderingSpeed = 1.2f;
                this.Speed = 5f;
                this.ClimbHeight = 1;
                this.Health = 1f;
                this.Damage = 1f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 0.8f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;

            }
        }
    }
}
