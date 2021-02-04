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
    [RequiresSkill(typeof(GlassworkingSkill), 1)]      
    public partial class GlassRecipe :
        RecipeFamily
    {
        public GlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Glass",
                    Localizer.DoStr("Glass"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SandItem), 6, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),    
                    new IngredientElement(typeof(CrushedLimestoneItem), 1, true),  
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GlassItem>(),  
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(GlassworkingSkill)); 
            this.ExperienceOnCraft = 1;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(GlassRecipe), 1.5f, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Glass"), typeof(GlassRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(2)]                                          
    [DoesntEncase]                                          
    [RequiresSkill(typeof(GlassworkingSkill), 1)]      
    public partial class GlassBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(GlassItem); } }  
    }

    [Serialized]
    [LocDisplayName("Glass")]
    [MaxStackSize(40)]                           
    [Weight(10000)]      
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Constructable", 1)]                         
    [Tier(2)]                                      
    public partial class GlassItem :
    BlockItem<GlassBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Glass"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A transparent, solid material useful for more than just windows."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(GlassStacked1Block),
        typeof(GlassStacked2Block),
        typeof(GlassStacked3Block),
            typeof(GlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class GlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GlassStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class GlassStacked4Block : PickupableBlock { } //Only a wall if it's all 4 Glass
}
