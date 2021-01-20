// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms.Behaviors
{
    using System.Collections.Generic;
    using Eco.Shared.States;
    using Eco.Simulation.Agents.AI;
    using Eco.Simulation.RouteProbing;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.Agents;
    using System;
    using Eco.Shared.Localization;

    public class FindAndEatSomethingBehavior
    {
        public static IEnumerator<BTResult> FindAndEatSomething(Animal agent, Behavior<Animal> noNearbyFoodBehavior, Func<IEnumerable<Vector3>> getFoodSources, float hungerRestoredPerEat)
        {
            var lastFoodSearchPos = Vector3.Zero;
            var foodSources = new Queue<Vector3>();

            //While we're still hungry and don't have prey
            while (agent.Hunger > Brain.HungerToStopEating)
            {
                foodSources.Clear();
                while (foodSources.Count == 0)
                {
                    //Look for food sources, if we havent checked already and found it empty or just killed an enemy animal
                    if (Vector3.WrappedDistance(lastFoodSearchPos, agent.Position) > 10 || (agent.TryGetMemory(Animal.IsAnimalKilledMemory, out bool isKilled) && isKilled))
                    {
                        foodSources.AddRange(getFoodSources());
                        lastFoodSearchPos = agent.Position;
                        agent.RemoveMemory(Animal.IsAnimalKilledMemory);
                    }
                    else //None found, get outta here
                        yield return new BTResult(noNearbyFoodBehavior.Do(agent), "No food in 10m radius of last query. Moving till we're > 10m from last query.");
                }

                //Food sources available, find paths to them. 
                var routeProps = new RouteProperties() {MaxTargetLocationHeightDelta = agent.Species.ClimbHeight};
                while (foodSources.Count > 0 && Vector3.WrappedDistance(lastFoodSearchPos, agent.Position) < 10)
                {
                    // Low-effort search for the first option or any other option visited while trying to hit the first with randomizing it in that area
                    var route            = AIUtil.GetRouteToAny(agent.FacingDir, agent.Position, foodSources, agent.Species.GetTraversalData(true), out var targetPosition, 100, 20, agent.Species.HeadDistance, routeProps);
                    var target           = targetPosition.Round;
                    var distanceToTarget = Vector3.WrappedDistanceSq(agent.Position, target);
                    
                    // Move to target if it's far away
                    if (distanceToTarget > 2f)
                    {
                        if (!route.HasValue) break;
                        
                        agent.SetRoute(route.Value, AnimalState.LookingForFood, route.Value.EndPosition.Round);
                        yield return BTResult.RunningChanged("walking to food");
                        
                        // Stop walking to food if the distance to it has changed or it disappeared
                        var agentTarget = agent.Target;
                        if (agentTarget == null || Vector3.WrappedDistanceSq(agentTarget.Value, target) > 2f) break;
                    }
                    
                    // Start eating food if it's close to us
                    if (Vector3.WrappedDistanceSq(target, agent.Position) <= 2f)
                    {
                        agent.ClearRoute();
                        agent.LookAt(target);
                        agent.ChangeState(AnimalState.Eating, 5, false);
                        agent.Hunger -= hungerRestoredPerEat;
                        yield return BTResult.RunningChanged("chowing down");

                        agent.LookAt(null);
                        lastFoodSearchPos = Vector3.Zero;
                        //Don't actually destroy the plant, because that's handled in the world layer simulation.  
                        //var plant = EcoSim.PlantSim.GetPlant(targetPlantPosition.WorldPosition3i + Vector3i.Up); 
                        //if (plant != null) EcoSim.PlantSim.DestroyPlant(plant, DeathType.EatenByAnimal);
                    }
                }
            }
        }
    }
}
