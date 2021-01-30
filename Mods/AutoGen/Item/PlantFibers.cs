﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [Serialized]
    [LocDisplayName("Plant Fibers")]
    [Compostable] 
    [Weight(10)]      
    [Fuel(100)][Tag("Fuel")]          
    [Yield(typeof(PlantFibersItem), typeof(GatheringSkill), new float[] { 1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f })]  
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("NaturalFiber", 1)]
    [Tag("Burnable Fuel", 1)]
    [Tag("Crop", 1)]                                 
    public partial class PlantFibersItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Harvested from a number of plants, these fibers are useful for a surprising number of things."); } }
    }
}
