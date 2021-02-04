// Copyright (c) Strange Loop Games. All rights reserved.
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
    public partial class CopperConcentrateRecipe :
        RecipeFamily
    {
        public CopperConcentrateRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CopperConcentrate",
                    Localizer.DoStr("Copper Concentrate"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(CrushedCopperOreItem), 7, typeof(MiningSkill)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<CopperConcentrateItem>(),  
                   new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 3), 
 
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(MiningSkill)); 
            this.ExperienceOnCraft = 2;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperConcentrateRecipe), 1.5f, typeof(MiningSkill));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Copper Concentrate"), typeof(CopperConcentrateRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Diggable]
    [RequiresSkill(typeof(MiningSkill), 1)]      
    public partial class CopperConcentrateBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(CopperConcentrateItem); } }  
    }

    [Serialized]
    [LocDisplayName("Copper Concentrate")]
    [MaxStackSize(40)]                                       
    [Weight(20000)]      
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("ConcentratedOre", 1)]
    [Tag("Excavatable", 1)]                         
    [RequiresTool(typeof(ShovelItem))] 
    public partial class CopperConcentrateItem :
    BlockItem<CopperConcentrateBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Copper Concentrate"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Copper ore that has been concentrated to remove impurities. Ore concentrate is used by smiths to smelt metal bars."); } }

        public override bool CanStickToWalls { get { return false; } }  
    }

}
