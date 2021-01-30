// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Animals;
    using Eco.Shared.Networking;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.States;
	using Eco.Mods.TechTree;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Types;
    using Eco.Core.Utils;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Shared.Serialization;
    using Range = Eco.Shared.Math.Range;

    public class SnappingTurtle : AnimalEntity
    {
        public SnappingTurtle(Animal parent, Vector3 pos, bool corpse = false) : base(parent, pos, species, corpse) { }
        static AnimalSpecies species;

        [Ecopedia("Animals", "Reptiles", true, InPageTooltip.DynamicTooltip)]
        public class SnappingTurtleSpecies : AnimalSpecies
        {
            public SnappingTurtleSpecies() : base()
            {
                species = this;
                this.InstanceType = typeof(SnappingTurtle);
                // Info
                this.Name = "SnappingTurtle";
                this.DisplayName = Localizer.DoStr("SnappingTurtle");
                // Lifetime
                this.MaturityAgeDays = 1f;
                // Food
                this.FoodSources = new List<System.Type>()
                { 
                    typeof(Clam),
                    typeof(PeatMoss),
                    typeof(Bullrush),
                    typeof(FilmyFern),
                    typeof(Buttonbush)
                };
                this.CalorieValue = 100f;
                // Movement
                this.Flying = false;
                this.Swimming = true;
                this.FloatOnSurface = true;
                // Resources
                this.ResourceList = new List<SpeciesResource>()
                {
                    new SpeciesResource(typeof(SnappingTurtleCarcassItem), new Range(1f, 1f)),
                };
                this.ResourceBonusAtGrowth = 0.9f;
                // Behavior
                this.BrainType = typeof(AmphibiousBrain);
                this.IsPredator = false;
                this.WanderingSpeed = 0.13f;
                this.Speed = 0.2f;
                this.ClimbHeight = 0;
                this.Health = 2.5f;
                this.Damage = 3f;
                this.DelayBetweenAttacksRangeSec = new Range(0.8f, 2.5f);
                this.FearFactor = 0f;
                this.FleePlayers = true;
                this.AttackRange = 1f;
                this.HeadDistance = 1f;
                // Climate
                this.ReleasesCO2TonsPerDay = 0.02f;
            }

            // SnappingTurtles can spawn on land or water
            public override bool IsValidSpawnPathPos(Vector3i pos) { return true; }
        }
        
        public override Result TryApplyDamage(INetObject damager, float damage, InteractionContext context, Item tool, Type damageDealer = null, float experienceMultiplier = 1f)
        {
            damage = Tortoise.BlockDamage(damager, damage, this);
            return base.TryApplyDamage(damager, damage, context, tool, damageDealer, experienceMultiplier);
        }
    }
}
