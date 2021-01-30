// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.WorldLayers
{
    using System;
    using Eco.Core.Utils;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers;
    using Eco.Simulation.WorldLayers.Layers;
    using Range = Eco.Shared.Math.Range;

    public class WorldLayerSettingsInvertebrates : WorldLayerSettings
    {
        public WorldLayerSettingsInvertebrates() : base()
        {
            this.Name ="Invertebrates";
            this.DisplayName = Localizer.DoStr("Invertebrates");
            this.InitMultiplier = 1f;
            this.SyncToClient = true;
            this.Range = new Range(0f, 1f);
            this.OverrideRenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(1f, 0.5f, 0.5f);
            this.SumRelevant = false;
            this.Unit = string.Empty;
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.Animal;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = string.Empty;    
        }

        public override Type LayerType { get { return typeof(WorldLayerInvertebrates); } }
    }

    [Serialized]
    public class WorldLayerInvertebrates : WorldLayer
    {
        private WorldLayer constructedLayer;
        protected override void PostLoadSelf()
        {
            this.constructedLayer = WorldLayerManager.Obj.GetLayer(LayerNames.Constructed);
        }

        protected override void TickSelf()
        {
            // TODO: make more complicated and/or do this 'correctly' (defining this in mods seems like a decent mod-friendly way to do things)
            // buildings reduce invertebrate counts (...typically)
            this.Map.Set2D(pos => (1f - this.constructedLayer.RawEntry(pos)));
        }
        public override bool PostTick { get { return true; } }
    }
}
