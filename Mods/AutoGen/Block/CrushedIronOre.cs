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
    [RequiresSkill(typeof(MiningSkill), 1)]      
    public partial class CrushedIronOreRecipe :
        RecipeFamily
    {
        public CrushedIronOreRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CrushedIronOre",
                    Localizer.DoStr("Crushed Iron Ore"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronOreItem), 12, true),  
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<CrushedIronOreItem>(2),                          
 
                   new CraftingElement<CrushedSandstoneItem>(1), 
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(MiningSkill)); 
            this.ExperienceOnCraft = 0.5f;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrushedIronOreRecipe), 1.5f, typeof(MiningSkill));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Crushed Iron Ore"), typeof(CrushedIronOreRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ArrastraObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]      
    public partial class CrushedIronOreBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(CrushedIronOreItem); } }  
    }

    [Serialized]
    [LocDisplayName("Crushed Iron Ore")]
    [MaxStackSize(10)]                                       
    [Weight(30000)]      
    [StartsDiscovered]                                      
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Excavatable", 1)]                         
    [RequiresTool(typeof(ShovelItem))] 
    public partial class CrushedIronOreItem :
    BlockItem<CrushedIronOreBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Iron Ore"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Crushed iron ore that is ready to be concentrated."); } }

        public override bool CanStickToWalls { get { return false; } }  
    }

}
