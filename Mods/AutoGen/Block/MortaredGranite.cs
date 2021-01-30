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
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(MasonrySkill), 2)]      
    public partial class MortaredGraniteRecipe :
        Recipe
    {
        public MortaredGraniteRecipe()
        {
            this.Name        = "MortaredGranite";
            this.DisplayName = Localizer.DoStr("Mortared Granite");
            this.Ingredients = new List<IngredientElement>
            {
                new IngredientElement(typeof(GraniteItem), 4, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                new IngredientElement(typeof(MortarItem), 1, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),   
            };
            this.Items = new List<CraftingElement>
            {
                new CraftingElement<MortaredGraniteItem>() 
            };
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(MasonryTableObject), typeof(MortaredStoneRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(1)]                                          
    [RequiresSkill(typeof(MasonrySkill), 2)]      
    public partial class MortaredGraniteBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(MortaredGraniteItem); } }  
    }

    [Serialized]
    [LocDisplayName("Mortared Granite")]
    [MaxStackSize(15)]                           
    [Weight(10000)]      
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("MortaredStone", 1)]
    [Tag("Constructable", 1)]                         
    [Tier(1)]                                      
    public partial class MortaredGraniteItem :
    BlockItem<MortaredGraniteBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Mortared Granite"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Used to create tough but rudimentary buildings."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(MortaredGraniteStacked1Block),
        typeof(MortaredGraniteStacked2Block),
            typeof(MortaredGraniteStacked3Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class MortaredGraniteStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class MortaredGraniteStacked2Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class MortaredGraniteStacked3Block : PickupableBlock { } //Only a wall if it's all 4 MortaredGranite
}
