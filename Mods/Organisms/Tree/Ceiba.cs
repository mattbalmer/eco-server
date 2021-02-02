﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.Organisms
{
    using System;
    using System.Collections.Generic;
    using Eco.Mods.TechTree;
    using Eco.Simulation.Types;
    using Eco.World;
    using Eco.World.Blocks;
    using Range = Eco.Shared.Math.Range;
    
    public partial class Ceiba : TreeEntity
    {
        public partial class CeibaSpecies : TreeSpecies
        {
            public override void PostInit()
            {
                // Lifetime
                this.TreeHealth = 30f;
                this.LogHealth = 2f;
                // Resources
                this.ChanceToSpawnDebris = 0.3f;
                // Visuals
                this.BranchingDef = new List<TreeBranchDef>()
                {
                    new TreeBranchDef() { Name = "Branch0", Health = 3f, LeafPoints = 1, GrowthStartTime = new Range(0f, 0f), GrowthEndTime = new Range(1f, 1f) },
                    new TreeBranchDef() { Name = "Branch1V", Health = 4f, LeafPoints = 1, GrowthStartTime = new Range(0f, 0f), GrowthEndTime = new Range(1f, 1f) },
                    new TreeBranchDef() { Name = "Branch2", Health = 3f, LeafPoints = 1, GrowthStartTime = new Range(0f, 0f), GrowthEndTime = new Range(1f, 1f) },
                    new TreeBranchDef() { Name = "Branch3V", Health = 4f, LeafPoints = 1, GrowthStartTime = new Range(0f, 0f), GrowthEndTime = new Range(1f, 1f) },
                    new TreeBranchDef() { Name = "Attach_Tip", Health = 3f, LeafPoints = 1, GrowthStartTime = new Range(0f, 0f), GrowthEndTime = new Range(1f, 1f) },
                };
                this.TopBranchLeafPoints = 1;
                this.TopBranchHealth = 3;
                this.BranchRotations = null;
                this.RandomYRotation = true;
                this.BranchCount = new Range(5f, 5f);
                this.BlockType = new BlockType(typeof(TreeBlock));
                this.DebrisType = typeof(CeibaTreeDebrisBlock);
                this.DebrisResources = new Dictionary<Type, Range>()
                {
                    { typeof(WoodPulpItem), new Range(4, 5) },
                    { typeof(CeibaSeedItem), new Range(0, 1) },
                };
                this.TrunkResources = new Dictionary<Type, Range>()
                {
                    { typeof(WoodPulpItem), new Range(8, 10) }
                };
                this.XZScaleRange = new Range(.8f, 1.4f);
                this.YScaleRange = new Range(.8f, 1.4f);
                this.Density = 320f;
            }
        }
    }
}
