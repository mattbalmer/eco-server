// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using Eco.Mods.Organisms.Behaviors;
    using Eco.Shared.Utils;
    using Eco.Shared.States;
    using Eco.Simulation.Agents;
    using Eco.Simulation.Agents.AI;
    using Eco.Simulation.WorldLayers;
    using Eco.Gameplay.AI;

    public class AmphibiousBrain : LandAnimalBrain 
    {
        public static readonly Behavior<Animal> AmphibiousTreeRoot;
        public static readonly Behavior<Animal> PredatorAmphibiousTreeRoot;
        public static readonly Behavior<Animal> LandTree;
        public static readonly Behavior<Animal> FloatingTree;
        public static readonly Behavior<Animal> DivingTree;

        public override Behavior<Animal> RootBehavior(Animal animal) => animal.Species.IsPredator ? PredatorAmphibiousTreeRoot : AmphibiousTreeRoot;

        const float MinIdleTime            = 3f;
        const float MaxIdleTime            = 10f;
        const float MinFloatIdleTime       = 10f;
        const float MaxFloatIdleTime       = 20f;
        const float ChanceToSurface        = 0.3f;
        const float ChanceToDive           = 0.2f;
        const float TimeToStopFloating     = 2f;
        const float DiveAlertness          = 200;
        const float MaxHeightAboveSeaLevel = 5;

        static AmphibiousBrain()
        {
            LandTree = BT.If("Land Tree", x => (!World.World.IsUnderwater(x.Position.WorldPosition3i), "on land"),
                    BT.Selector("Amphibious On Land",
                        MovementBehaviors.AmphibiousFlee,
                        BT.If("Return Home", MovementBehaviors.ShouldReturnHome, MovementBehaviors.AmphibiousWanderHome),
                        BT.If("Return to Water", x => (x.Position.y > WorldLayerManager.Obj.ClimateSim.State.SeaLevel + MaxHeightAboveSeaLevel, $"above sea-level {(x.Position.Y + WorldLayerManager.Obj.ClimateSim.State.SeaLevel).ToString("0.#")} not more than {MaxHeightAboveSeaLevel}"),
                            MovementBehaviors.MoveToWater),
                        BT.Random("Relax", 
                            RelaxBehaviors.TryIdle,
                            MovementBehaviors.AmphibiousWander)));

            FloatingTree = BT.If("Floating", x => (x.Floating, "floating"),
                    BT.Selector("Floating",
                        BT.If("Surface swim", x => (x.State == AnimalState.FloatingIdle && !x.Species.IsPredator, "is idling and not predator"),
                            // floating amphibious need time to flip back over before doing other things
                            Anim(AnimalState.SurfaceSwimming, true, TimeToStopFloating)),
                        BT.If("Flee Dive", x => (x.Alertness > DiveAlertness, $"alert {x.Alertness.ToString("0.#")} > {DiveAlertness.ToString("0.#")}"),
                            stopFloating,
                            BT.Selector("Flee or Wander",
                                MovementBehaviors.SwimFlee, 
                                MovementBehaviors.SwimWander)),
                        MovementBehaviors.AmphibiousFlee,
                        BT.If("Random Dive", x => AIUtil.Chance(ChanceToDive), 
                            stopFloating,
                            MovementBehaviors.SwimWander),
                        BT.If("Return Home", MovementBehaviors.ShouldReturnHome,
                            MovementBehaviors.AmphibiousWanderHome),
                        BT.If("Idle", x => AIUtil.Chance(ChanceToIdle),
                            Anim(AnimalState.FloatingIdle, true, _ => RandomUtil.Range(MinFloatIdleTime, MaxFloatIdleTime))),
                        MovementBehaviors.AmphibiousWander));

            DivingTree = BT.Selector("Diving",
                    MovementBehaviors.SwimFlee,
                    BT.If("Return Home", MovementBehaviors.ShouldReturnHome,
                        startFloating,
                        MovementBehaviors.SwimWanderHomeSurface),
                    BT.If("Surface", x => (x.Alertness < DiveAlertness && RandomUtil.Chance(ChanceToSurface), $"alert {x.Alertness.ToString("0.#")} < {DiveAlertness.ToString("0.#")} and {ChanceToSurface.ToString("P0")} chance"),
                        startFloating,
                        MovementBehaviors.SwimWanderSurface),
                    BT.If("Wander", x => AIUtil.Chance(1 - ChanceToIdle),
                        MovementBehaviors.SwimWander),
                    Anim(AnimalState.SwimmingIdle, true, _ => RandomUtil.Range(MinIdleTime, MaxIdleTime)));

            // TODO: dive for food & eat on surface (need tummy eating animation)
            AmphibiousTreeRoot         = BT.Selector("Amphibious", 
                BT.If("Animal On Land", x => (!World.World.IsUnderwater(x.Position.WorldPosition3i), "on land"),
                    BT.Selector("Landing",
                        MovementBehaviors.Flee,
                        FindAndEatPlants,
                        LandTree)),
                BT.If("Animal In Water", x => (World.World.IsUnderwater(x.Position.WorldPosition3i), "in water"),
                    BT.Selector("Swimming",
                        MovementBehaviors.SwimFlee, 
                        FloatingTree,
                        DivingTree)),
                RelaxBehaviors.Idle);
            
            PredatorAmphibiousTreeRoot = BT.Selector("Amphibious Predator",
                BT.If("Predator On Land", x => (!World.World.IsUnderwater(x.Position.WorldPosition3i), "on land"),
                    BT.Selector("Landing",
                        MovementBehaviors.Flee,
                        LandPredatorBrain.FindAndAttackEnemyTree,
                        LandPredatorBrain.FindAndEatCorpse,
                        LandTree)
                ),
                BT.If("Predator In Water", x => (World.World.IsUnderwater(x.Position.WorldPosition3i), "in water"),
                    BT.Selector("Swimming",
                        MovementBehaviors.SwimFlee,
                        FloatingTree,
                        DivingTree)
                ),
                RelaxBehaviors.Idle); 
        }

        static Behavior<Animal> stopFloating = BT.Success("Stop Floating", x => x.Floating = false);
        static Behavior<Animal> startFloating = BT.Success("Start Floating", x => x.Floating = true);
    }
}
