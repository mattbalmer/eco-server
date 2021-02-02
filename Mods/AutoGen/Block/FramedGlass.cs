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
    [RequiresSkill(typeof(GlassworkingSkill), 1)]      
    public partial class FramedGlassRecipe :
        RecipeFamily
    {
        public FramedGlassRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "FramedGlass",
                    Localizer.DoStr("Framed Glass"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(GlassItem), 5, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)), 
                    new IngredientElement(typeof(SteelBarItem), 2, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<FramedGlassItem>(),  
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(GlassworkingSkill)); 
            this.ExperienceOnCraft = 1.5f;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(FramedGlassRecipe), 2, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Framed Glass"), typeof(FramedGlassRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [BlockTier(4)]                                          
    [RequiresSkill(typeof(GlassworkingSkill), 1)]      
    public partial class FramedGlassBlock :
        Block            
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(FramedGlassItem); } }  
    }

    [Serialized]
    [LocDisplayName("Framed Glass")]
    [MaxStackSize(40)]                           
    [Weight(10000)]      
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Currency][Tag("Currency")]                              
    [Tag("Constructable", 1)]                         
    [Tier(4)]                                      
    public partial class FramedGlassItem :
    BlockItem<FramedGlassBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Framed Glass"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("Glass which was reinforced by a steel frame."); } }

        public override bool CanStickToWalls { get { return false; } }  

        private static Type[] blockTypes = new Type[] {
        typeof(FramedGlassStacked1Block),
        typeof(FramedGlassStacked2Block),
        typeof(FramedGlassStacked3Block),
            typeof(FramedGlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class FramedGlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class FramedGlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class FramedGlassStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class FramedGlassStacked4Block : PickupableBlock { } //Only a wall if it's all 4 FramedGlass
}
