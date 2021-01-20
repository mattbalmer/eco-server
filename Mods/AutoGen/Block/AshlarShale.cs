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
    [RequiresSkill(typeof(AdvancedMasonrySkill), 1)]      
    public partial class AshlarShaleRecipe :
        RecipeFamily
    {
        public AshlarShaleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "AshlarShale",
                    Localizer.DoStr("Ashlar Shale"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(ShaleItem), 20, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)), 
                    new IngredientElement(typeof(MortarItem), 6, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)), 
                    new IngredientElement(typeof(SteelBarItem), 1, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<AshlarShaleItem>(),  
                   new CraftingElement<CrushedShaleItem>(typeof(AdvancedMasonrySkill), 2), 
 
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(AdvancedMasonrySkill), typeof(AshlarShaleRecipe), this.UILink()); 
            this.ExperienceOnCraft = 1.5f;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(AshlarShaleRecipe), this.UILink(), 2, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryFocusedSpeedTalent), typeof(AdvancedMasonryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Ashlar Shale"), typeof(AshlarShaleRecipe));
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
    public partial class AshlarShaleBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(AshlarShaleItem); } }  
    }

    [Serialized]
    [LocDisplayName("Ashlar Shale")]
    [MaxStackSize(20)]                           
    [Weight(30000)]      
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("AshlarStone", 1)]
    [Tag("Constructable", 1)]                         
    [Tier(4)]                                      
    public partial class AshlarShaleItem :
    BlockItem<AshlarShaleBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Ashlar Shale"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Ashlar is finely cut stone made by an expert mason. Ashlar stone is an especially decorative building material that comes in a variety of styles based on the type of rock used."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(AshlarShaleStacked1Block),
        typeof(AshlarShaleStacked2Block),
        typeof(AshlarShaleStacked3Block),
            typeof(AshlarShaleStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class AshlarShaleStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class AshlarShaleStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class AshlarShaleStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class AshlarShaleStacked4Block : PickupableBlock { } //Only a wall if it's all 4 AshlarShale
}
