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
    using Eco.Gameplay.Pipes.LiquidComponents; 

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]      
    public partial class AsphaltConcreteRecipe :
        RecipeFamily
    {
        public AsphaltConcreteRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "AsphaltConcrete",
                    Localizer.DoStr("Asphalt Concrete"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(CementItem), 1, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)), 
                    new IngredientElement(typeof(SandItem), 2, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),    
                    new IngredientElement("CrushedRock", 5, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<AsphaltConcreteItem>(2),                          
                    }
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(BasicEngineeringSkill)); 
            this.ExperienceOnCraft = 1.5f;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(AsphaltConcreteRecipe), 4, typeof(BasicEngineeringSkill), typeof(BasicEngineeringFocusedSpeedTalent), typeof(BasicEngineeringParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Asphalt Concrete"), typeof(AsphaltConcreteRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]      
    public partial class AsphaltConcreteBlock :
        PickupableBlock      
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(AsphaltConcreteItem); } }  
    }

    [Serialized]
    [LocDisplayName("Asphalt Concrete")]
    [MaxStackSize(10)]                                       
    [Weight(10000)]      
    [MakesRoads]                                             
    [Ecopedia("Blocks", "Roads", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    [Tag("Road", 1)]
    [Tag("Constructable", 1)]
    [Tag("RoadType", 1)]                         
    public partial class AsphaltConcreteItem :
    RoadItem<AsphaltConcreteBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Asphalt Concrete"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A paved surface constructed with asphalt and concrete. It's durable and extremely efficient for any wheeled vehicle."); } }

    }

}
