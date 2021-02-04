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

    public class Turkey : AnimalEntity
    {
        public Turkey(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Birds", true, InPageTooltip.DynamicTooltip)]
        public class TurkeySpecies : AnimalSpecies
        {
            public TurkeySpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Turkey);

                // Info
                this.Name = "Turkey";
                this.DisplayName = Localizer.DoStr("Turkey");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() {typeof(Camas), typeof(Wheat), typeof(Bunchgrass), typeof(Corn), typeof(Huckleberry), typeof(BigBluestem)};
                this.CalorieValue = 75f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(TurkeyCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(LandAnimalBrain);
                this.WanderingSpeed = 0.7f;
                this.Speed = 3.5f;
                this.ClimbHeight = 1;
                this.Health = 1.5f;
                this.Damage = 1f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 0.5f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                this.TimeLayToStand = 3.5f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;

            }
        }
    }
}
