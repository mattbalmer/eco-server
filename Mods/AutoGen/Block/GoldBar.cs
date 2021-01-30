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
    [RequiresSkill(typeof(SmeltingSkill), 1)]      
    public partial class GoldBarRecipe :
        RecipeFamily
    {
        public GoldBarRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GoldBar",
                    Localizer.DoStr("Gold Bar"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(GoldConcentrateItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GoldBarItem>(2),                          
                   new CraftingElement<SlagItem>(typeof(SmeltingSkill), 1), 
 
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(SmeltingSkill)); 
            this.ExperienceOnCraft = 2;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(GoldBarRecipe), 0.3f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Gold Bar"), typeof(GoldBarRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [RequiresSkill(typeof(SmeltingSkill), 1)]      
    public partial class GoldBarBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(GoldBarItem); } }  
    }

    [Serialized]
    [LocDisplayName("Gold Bar")]
    [MaxStackSize(40)]                           
    [Weight(30000)]      
    [Ecopedia("Blocks", "Metals", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Metal", 1)]                         
    public partial class GoldBarItem :
    BlockItem<GoldBarBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Refined bar of gold."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(GoldBarStacked1Block),
        typeof(GoldBarStacked2Block),
        typeof(GoldBarStacked3Block),
            typeof(GoldBarStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class GoldBarStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GoldBarStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GoldBarStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class GoldBarStacked4Block : PickupableBlock { } //Only a wall if it's all 4 GoldBar
}
