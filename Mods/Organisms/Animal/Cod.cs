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

    public class Cod : AnimalEntity
    {
        public Cod(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Fish", true, InPageTooltip.DynamicTooltip)]
        public class CodSpecies : AnimalSpecies
        {
            public CodSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Cod);

                // Info
                this.Name = "Cod";
                this.DisplayName = Localizer.DoStr("Cod");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() { typeof(Kelp), typeof(Seagrass) };
                this.CalorieValue = 50f;
                // Movement
                this.Flying = false;
                this.Swimming = true;
                this.CanSwimNearCoast = false;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(CodItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(FishBrain);
                this.WanderingSpeed = 1f;
                this.Speed = 1.5f;
                this.Health = 3f;
                this.Damage = 0f;
                this.DelayBetweenAttacksRangeSec = new Range(0f, 0f);
                this.FearFactor = 1f;
                this.FleePlayers = true;
                this.AttackRange = 0f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;

            }
        }
    }
}
