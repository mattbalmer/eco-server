// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using System.Collections.Generic;
    using Eco.Mods.Organisms.Behaviors;
    using Eco.Core.Items;
    using Eco.Gameplay.Animals;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.States;
    using Eco.Shared.Utils;
	using Eco.Mods.TechTree;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Simulation.Types;
    using Eco.Simulation.WorldLayers;
    using Range = Eco.Shared.Math.Range;

    public class Alligator : AnimalEntity
    {
        public Alligator(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Reptiles", true, InPageTooltip.DynamicTooltip)]
        public class AlligatorSpecies : AnimalSpecies
        {
            public AlligatorSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(Alligator);
                // Info
                this.Name = "Alligator";
                this.DisplayName = Localizer.DoStr("Alligator");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>() { typeof(Turkey), typeof(Tuna), typeof(Salmon), typeof(Trout), typeof(Deer), typeof(Elk), typeof(Hare), typeof(Agouti), typeof(SnappingTurtle), typeof(Tortoise), typeof(Crab) };
                this.CalorieValue = 100f;
                // Movement
                this.Flying = false;
                this.Swimming = true;
                this.FloatOnSurface = true;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(AlligatorCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(AmphibiousBrain);
                this.IsPredator = true;
                this.WanderingSpeed = 0.21f;
                this.Speed = 1.5f;
                this.ClimbHeight = 0 ;
                this.Health = 7f;
                this.Damage = 3f;
                this.ChanceToAttack = 0.8f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 0f;
                this.FleePlayers = true;
                this.AttackRange = 2.5f;
                this.HeadDistance = 1.5f;
                this.TimeAttackToIdle = 3.3f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;

                this.RotationSpeed = 45f;
                this.WanderingRotationSpeed = 22.5f;
                this.MinRotationToSlowDown = 5f;
            }

            // Alligators can spawn on land or water
            public override bool IsValidSpawnPathPos(Vector3i pos) => World.World.IsUnderwater(pos) || RandomUtil.Chance(.3f);
        }
    }
}
