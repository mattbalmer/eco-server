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
    [RequiresSkill(typeof(PotterySkill), 1)]      
    public partial class BrickRecipe :
        RecipeFamily
    {
        public BrickRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Brick",
                    Localizer.DoStr("Brick"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(ClayItem), 1, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)), 
                    new IngredientElement(typeof(MortarItem), 4, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<BrickItem>(),  
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(PotterySkill)); 
            this.ExperienceOnCraft = 1;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(BrickRecipe), 0.5f, typeof(PotterySkill), typeof(PotteryFocusedSpeedTalent), typeof(PotteryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Brick"), typeof(BrickRecipe));
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
    [RequiresSkill(typeof(PotterySkill), 1)]      
    public partial class BrickBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(BrickItem); } }  
    }

    [Serialized]
    [LocDisplayName("Brick")]
    [MaxStackSize(40)]                           
    [Weight(10000)]      
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Constructable", 1)]                         
    [Tier(2)]                                      
    public partial class BrickItem :
    BlockItem<BrickBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Durable building material made from fired blocks and mortar."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(BrickStacked1Block),
        typeof(BrickStacked2Block),
        typeof(BrickStacked3Block),
            typeof(BrickStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class BrickStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class BrickStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class BrickStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class BrickStacked4Block : PickupableBlock { } //Only a wall if it's all 4 Brick
}
