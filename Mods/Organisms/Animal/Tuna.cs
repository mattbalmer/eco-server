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

    public class Tuna : AnimalEntity
    {
        public Tuna(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Fish", true, InPageTooltip.DynamicTooltip)]
        public class TunaSpecies : AnimalSpecies
        {
            public TunaSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Tuna);

                // Info
                this.Name = "Tuna";
                this.DisplayName = Localizer.DoStr("Tuna");
                // Lifetime
                this.MaturityAgeDays = 0.65f;
                // Food
                this.FoodSources = new List<System.Type>() { typeof(Kelp), typeof(Seagrass) };
                this.CalorieValue = 100f;
                // Movement
                this.Flying = false;
                this.Swimming = true;
                this.CanSwimNearCoast = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(TunaItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(FishBrain);
                this.WanderingSpeed = 1f;
                this.Speed = 2f;
                this.Health = 2f;
                this.Damage = 1f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 1f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;

            }
        }
    }
}
