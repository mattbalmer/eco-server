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
    public partial class CopperBarRecipe :
        RecipeFamily
    {
        public CopperBarRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CopperBar",
                    Localizer.DoStr("Copper Bar"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(CopperConcentrateItem), 1, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<CopperBarItem>(2),                          
                   new CraftingElement<SlagItem>(typeof(SmeltingSkill), 1), 
 
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(SmeltingSkill), typeof(CopperBarRecipe), this.UILink()); 
            this.ExperienceOnCraft = 2;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperBarRecipe), this.UILink(), 0.25f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Copper Bar"), typeof(CopperBarRecipe));
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
    public partial class CopperBarBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(CopperBarItem); } }  
    }

    [Serialized]
    [LocDisplayName("Copper Bar")]
    [MaxStackSize(20)]                           
    [Weight(15000)]      
    [Ecopedia("Blocks", "Metals", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Metal", 1)]                         
    public partial class CopperBarItem :
    BlockItem<CopperBarBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Refined bar of copper."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(CopperBarStacked1Block),
        typeof(CopperBarStacked2Block),
        typeof(CopperBarStacked3Block),
            typeof(CopperBarStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class CopperBarStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class CopperBarStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class CopperBarStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class CopperBarStacked4Block : PickupableBlock { } //Only a wall if it's all 4 CopperBar
}
