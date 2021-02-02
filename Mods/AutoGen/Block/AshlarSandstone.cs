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
    [RequiresSkill(typeof(AdvancedMasonrySkill), 1)]      
    public partial class AshlarSandstoneRecipe :
        RecipeFamily
    {
        public AshlarSandstoneRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "AshlarSandstone",
                    Localizer.DoStr("Ashlar Sandstone"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SandstoneItem), 20, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)), 
                    new IngredientElement(typeof(MortarItem), 6, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)), 
                    new IngredientElement(typeof(SteelBarItem), 1, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<AshlarSandstoneItem>(),  
                   new CraftingElement<CrushedSandstoneItem>(typeof(AdvancedMasonrySkill), 2), 
 
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(AdvancedMasonrySkill)); 
            this.ExperienceOnCraft = 1.5f;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(AshlarSandstoneRecipe), 2, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryFocusedSpeedTalent), typeof(AdvancedMasonryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Ashlar Sandstone"), typeof(AshlarSandstoneRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(AdvancedMasonryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(4)]                                          
    [RequiresSkill(typeof(AdvancedMasonrySkill), 1)]      
    public partial class AshlarSandstoneBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(AshlarSandstoneItem); } }  
    }

    [Serialized]
    [LocDisplayName("Ashlar Sandstone")]
    [MaxStackSize(40)]                           
    [Weight(10000)]      
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("AshlarStone", 1)]
    [Tag("Constructable", 1)]                         
    [Tier(4)]                                      
    public partial class AshlarSandstoneItem :
    BlockItem<AshlarSandstoneBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Ashlar Sandstone"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Ashlar is finely cut stone made by an expert mason. Ashlar stone is an especially decorative building material that comes in a variety of styles based on the type of rock used."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(AshlarSandstoneStacked1Block),
        typeof(AshlarSandstoneStacked2Block),
        typeof(AshlarSandstoneStacked3Block),
            typeof(AshlarSandstoneStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class AshlarSandstoneStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class AshlarSandstoneStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class AshlarSandstoneStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class AshlarSandstoneStacked4Block : PickupableBlock { } //Only a wall if it's all 4 AshlarSandstone
}
