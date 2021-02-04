﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// This file modified by @mbalmer eco-custom-server script
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
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(CompositesSkill), 1)]      
    public partial class CompositeCedarLumberRecipe :
        Recipe
    {
        public CompositeCedarLumberRecipe()
        {
            this.Name        = "CompositeCedarLumber";
            this.DisplayName = Localizer.DoStr("Composite Cedar Lumber");
            this.Ingredients = new List<IngredientElement>
            {
                new IngredientElement(typeof(CedarLogItem), 1, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),
                new IngredientElement(typeof(PlasticItem), 1, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),
                new IngredientElement(typeof(EpoxyItem), 1, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),   
                new IngredientElement("Lumber",  1, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),   
            };
            this.Items = new List<CraftingElement>
            {
                new CraftingElement<CompositeCedarLumberItem>() 
            };
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(AdvancedCarpentryTableObject), typeof(CompositeLumberRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [BlockTier(4)]                                          
    [RequiresSkill(typeof(CompositesSkill), 1)]      
    public partial class CompositeCedarLumberBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(CompositeCedarLumberItem); } }  
    }

    [Serialized]
    [LocDisplayName("Composite Cedar Lumber")]
    [MaxStackSize(40)]                           
    [Weight(10000)]      
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("CompositeLumber", 1)]
    [Tag("SoftwoodLumber", 1)]
    [Tag("Constructable", 1)]                         
    [Tier(4)]                                      
    public partial class CompositeCedarLumberItem :
    BlockItem<CompositeCedarLumberBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Composite Cedar Lumber"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A composite lumber made from a combination of wood and plastic."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(CompositeCedarLumberStacked1Block),
        typeof(CompositeCedarLumberStacked2Block),
        typeof(CompositeCedarLumberStacked3Block),
            typeof(CompositeCedarLumberStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class CompositeCedarLumberStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class CompositeCedarLumberStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class CompositeCedarLumberStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class CompositeCedarLumberStacked4Block : PickupableBlock { } //Only a wall if it's all 4 CompositeCedarLumber
}
