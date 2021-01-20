// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms.Behaviors
{
    using Eco.Shared.Localization;
    using System;
    using Eco.Gameplay.Players;
    using Eco.Shared.Networking;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Shared.States;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Items;
    using Eco.Mods.TechTree;
    using Eco.Shared.Math;
    using Eco.Simulation.Time;

    public class PredatorBehaviors
    {
        private const float RunTimeAfterAttackingPlayer   = 10f;
        private const float EnemyNearbyAlertness          = 100f;
        private const float ChanceToFleeFromEnemy         = 0.65f;
        private const float EatPreyTime                   = 3000f; //Have them sitting there eating for a very long time. 
        
        public static Behavior<Animal> TryFleeing { get; } = new BehaviorBasic<Animal>("Try to run", (beh, agent) =>
        {
            var (result, msg) = ConsiderFleeing(agent);
            return result ? BTResult.Success(msg) : BTResult.Failure(msg);
        });

        public static (bool result, string msg) ConsiderFleeing(Animal agent, bool skipChance = false)
        {
            // Run immediately if just attacked player or randomly choose run or not
            // For immediate run remember that we need to run away for a long time
            var fleePosition = agent.Position + agent.FacingDir;
            var chanceToFlee = !skipChance && RandomUtil.Chance(ChanceToFleeFromEnemy);
            agent.TryGetMemory(Animal.IsPlayerAttackedMemory, out bool attackedPlayer);
            if (attackedPlayer) chanceToFlee = true;
            if (agent.Prey != null)
            {
                if (!chanceToFlee && agent.Prey is Player playerEnemy)
                {
                    // Be aware of a player with fire
                    var selectedItem   = playerEnemy.User.Inventory?.Toolbar?.SelectedItem;
                    var playerWithFire = selectedItem is TorchItem;
                    if (playerWithFire) chanceToFlee = true;
                } 
                fleePosition = agent.Prey.Position;
            }

            if (!chanceToFlee) return (false, "no flee");
            agent.Prey = null;
            if (attackedPlayer)
            {
                agent.FleeFromImmediately(fleePosition);
                agent.SetMemory(Animal.ShouldFleeTillMemory, WorldTime.Seconds + RunTimeAfterAttackingPlayer);
                agent.SetMemory(Animal.IsPlayerAttackedMemory, false);
            }
            else agent.FleeFrom(fleePosition);
            return (true, "preparing to flee");
        }
        
        public static (bool result, string msg) FindEnemy(Animal agent) => agent.Prey != null ? (true, "enemy remembered") : (false, "no enemy around");

        public static (bool result, string msg) CheckAttacking(Animal agent)
        {
            // If we haven't chosen attack or run away, think and remember the choice
            if (!agent.TryGetMemory(Animal.RunOrAttackMemory, out bool isAttackChoice))
            {
                isAttackChoice = RandomUtil.Chance(agent.Species.ChanceToAttack);
                if (!isAttackChoice) return (false, "no attack");
                agent.SetMemory(Animal.RunOrAttackMemory, true);
            }
            // Check special fleeing conditions like player keeps torch or weapon
            ConsiderFleeing(agent, true);

            return (isAttackChoice, isAttackChoice ? "attacking" : "no attack");
        }

        public static (bool result, string msg) ChasePrey(Animal agent)
        {
            // Chase an enemy when we have it around
            if (agent.Prey == null) return (false, "forgotten prey");

            var distanceToEnemy = agent.Position.WrappedDistance(agent.Prey.Position);

            if (distanceToEnemy <= agent.Species.AttackRange)
            {
                if (agent.Prey is Player)
                { 
                    // Growl on target while we have low anger
                    if (agent.Anger < Animal.AngerLevelToAttack)
                    {
                        agent.ClearRoute();
                        agent.LookAt(agent.Prey);
                        return (agent.ChangeState(AnimalState.Growl, 2, true).Status != BTStatus.Failure, "growling");
                    }
                }
                // Stopping an enemy before attacking to make a good chase
                else if (agent.Prey is Animal animalPrey) animalPrey.ClearRoute();
                    
                var attackResult = AttackTarget(agent.Prey, agent, agent.Species.TimeAttackToIdle);
                return (attackResult.Status != BTStatus.Failure, attackResult.Msg);
            }

            // Player chasing will be available only when we're anger (not executes for passive acting)
            var canChasePlayer = !(agent.Prey is Player) || (agent.Prey is Player && agent.Anger > 0.1f);
            // Start chasing a prey if it's in our detection range
            if (distanceToEnemy > agent.Species.AttackRange && distanceToEnemy < agent.Species.DetectRange && canChasePlayer)
            {
                var agentPreyPosition = agent.Prey.Position;
                // Move to prey's direction closer
                if (agent.Prey is Animal animalPrey) agentPreyPosition += animalPrey.DesiredDirection(.4f / animalPrey.DesiredSpeed);
                
                var movingResult = MovementBehaviors.MoveTo(agent, agentPreyPosition, false);
                if (movingResult.Status != BTStatus.Failure) 
                {
                    //If we're pursuing a player only, then we do more frequent ticks, in case they're moving.
                    if (agent.Prey is Player)
                    {
                        var percentDistance = MathUtil.GetPercentThrough(distanceToEnemy, agent.Species.AttackRange, agent.DetectionRange, true);
                        agent.NextTick = Math.Min(agent.NextTick, WorldTime.Seconds + 1.5f);
                    }
                    return (true, "moving to enemy");
                }
            }

            // enemy is undefined or far away
            agent.Prey = null;
            agent.LookAt(null);
            return (false, "enemy is undefined");
        }
        
        private static BTResult AttackTarget(INetObjectPosition target, Animal agent, float attackTime)
        {
            agent.ClearRoute();
            agent.Alertness = EnemyNearbyAlertness; // Make an animal feel stressed to prevent sleep, etc.

            agent.LookAt(agent.Prey);

            if (target is Player)
                return agent.ChangeState(AnimalState.AttackPrey, attackTime, false);
            if (target is Animal animal && animal.Alive)
                return agent.ChangeState(AnimalState.AttackPrey, attackTime, false);

            //Animal is dead and we can eat it. Skipping current behavior to pass it to eating corpse action
            agent.Prey = null;
            return BTResult.Failure("enemy is dead");
        }
    }
}
