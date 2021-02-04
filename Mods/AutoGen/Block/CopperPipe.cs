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
    using Eco.Gameplay.Pipes.LiquidComponents; 

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(SmeltingSkill), 1)]      
    public partial class CopperPipeRecipe :
        RecipeFamily
    {
        public CopperPipeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CopperPipe",
                    Localizer.DoStr("Copper Pipe"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(CopperBarItem), 2, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<CopperPipeItem>(),  
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(SmeltingSkill)); 
            this.ExperienceOnCraft = 0.5f;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperPipeRecipe), 0.8f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Copper Pipe"), typeof(CopperPipeRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Constructed]
    [BlockTier(2)]                                          
    [DoesntEncase]                                          
    [RequiresSkill(typeof(SmeltingSkill), 1)]      
    public partial class CopperPipeBlock :
        PipeBlock      
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(CopperPipeItem); } }  
    }

    [Serialized]
    [LocDisplayName("Copper Pipe")]
    [MaxStackSize(40)]                                       
    [Weight(2000)]      
    [Ecopedia("Blocks", "Pipes", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Constructable", 1)]                         
    [Tier(2)]                                      
    public partial class CopperPipeItem :
    PipeItem<CopperPipeBlock>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A pipe for transporting liquids."); } }

    }

}
