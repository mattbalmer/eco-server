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
    using Eco.Simulation.Types;

    public class Agouti : AnimalEntity
    {
        public Agouti(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Mammals", true, InPageTooltip.DynamicTooltip)]
        public class AgoutiSpecies : AnimalSpecies
        {
            public AgoutiSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Agouti);

                // Info
                this.Name = "Agouti";
                this.DisplayName = Localizer.DoStr("Agouti");
                this.DisplayDescription = Localizer.DoStr("A long-legged tropical rodent that can be found throughout the rainforest.");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>()
                {
                    typeof(FilmyFern),
                    typeof(Taro),
                    typeof(Papaya),
                    typeof(LatticeMushroom),
                    typeof(Heliconia),
                    typeof(Orchid)
                };
                this.CalorieValue = 80f;
                // Movement
                this.Flying = false;
                this.Swimming = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(AgoutiCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(LandAnimalBrain);
                this.WanderingSpeed = 1f;
                this.Speed = 4.5f;
                this.ClimbHeight = 1;
                this.Health = 1f;
                this.Damage = 1f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 1f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                this.HeadDistance = 0.7f;
                this.TimeLayToStand = 2.5f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;

            }
        }
    }
}
