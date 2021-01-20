﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using System.Collections.Generic;
    using Eco.Mods.TechTree;
    using Eco.Simulation.Types;
    using Eco.World.Blocks;
    using Range = Eco.Shared.Math.Range;
    
    public partial class SaguaroCactus : TreeEntity
    {
        public partial class SaguaroCactusSpecies : TreeSpecies
        {
            public override void PostInit()
            {
                // Lifetime
                this.TreeHealth = 7f;
                this.LogHealth = 2f;
                // Resources
                this.ChanceToSpawnDebris = 0.2f;
                // Visuals
                this.BranchingDef = new List<TreeBranchDef>()
                {
                    new TreeBranchDef() { Name = "Branch0", Health = 3f, LeafPoints = 0, GrowthStartTime = new Range(0f, 0.05f), GrowthEndTime = new Range(0.4f, 0.6f) },
                    new TreeBranchDef() { Name = "Branch1", Health = 3f, LeafPoints = 0, GrowthStartTime = new Range(0f, 0.05f), GrowthEndTime = new Range(0.4f, 0.6f) },
                    new TreeBranchDef() { Name = "Branch2", Health = 3f, LeafPoints = 0, GrowthStartTime = new Range(0f, 0.05f), GrowthEndTime = new Range(0.4f, 0.6f) },
                    new TreeBranchDef() { Name = "Branch3", Health = 3f, LeafPoints = 0, GrowthStartTime = new Range(0f, 0.05f), GrowthEndTime = new Range(0.4f, 0.6f) },
                };
                this.TopBranchLeafPoints = 0;
                this.TopBranchHealth = 0;
                this.BranchRotations = new float[] {0f, 90f, 180f, 270f};
                this.RandomYRotation = false;
                this.BranchCount = new Range(1f, 3f);
                this.BlockType = typeof(TreeBlock);
                this.DebrisType = typeof(SaguaroCactusDebrisBlock);
                this.DebrisResources = new Dictionary<Type, Range>()
                {
                    { typeof(WoodPulpItem), new Range(4, 5) },
                    { typeof(SaguaroSeedItem), new Range(0, 1) },
                    { typeof(GiantCactusFruitItem), new Range(0, 1) },
                };
                this.TrunkResources = new Dictionary<Type, Range>()
                {
                    { typeof(WoodPulpItem), new Range(4, 6) }
                };
                this.XZScaleRange = new Range(.8f, 1.4f);
                this.YScaleRange = new Range(.8f, 1.4f);
                this.Density = 250f;
            }
        }
    }
}
