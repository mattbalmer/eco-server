﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
      using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using static Eco.Gameplay.Housing.HousingValue;               

    [Serialized]
    [RequireComponent(typeof(AirPollutionComponent))]           
    [RequireComponent(typeof(OnOffComponent))]                  
    [RequireComponent(typeof(ChimneyComponent))]                
    [RequireComponent(typeof(LiquidProducerComponent))]         
    [RequireComponent(typeof(AttachmentComponent))]             
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(PluginModulesComponent))]           
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(45)]                          
    [RequireRoomMaterialTier(1.8f, typeof(MasonryLavishReqTalent), typeof(MasonryFrugalReqTalent))]  
    public partial class CementKilnObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Cement Kiln"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(CementKilnItem); } } 


        private static string[] fuelTagList = new string[]
        {
            "Burnable Fuel",
        };

        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));                
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);                            
            this.GetComponent<FuelConsumptionComponent>().Initialize(50);                    
            this.GetComponent<HousingComponent>().Set(CementKilnItem.HousingVal);                               

            this.GetComponent<LiquidProducerComponent>().Setup(typeof(SmogItem), 1, this.NamedOccupancyOffset("ChimneyOut"));  
            this.GetComponent<AirPollutionComponent>().Initialize(this.GetComponent<LiquidProducerComponent>());  
        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Cement Kiln")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [LiquidProducer(typeof(SmogItem), 1)] 
    [AllowPluginModules(Tags = new[] { "AdvancedUpgrade", }, ItemTypes = new[] { typeof(MasonryAdvancedUpgradeItem), })]  
    public partial class CementKilnItem :
        WorldObjectItem<CementKilnObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A rotary kiln that produces cement and concrete products.");

        static CementKilnItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.Industrial,
                                                    TypeForRoomLimit = "", 
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(50)}w of {new HeatPower().Name} power from fuel"); 

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]     
    public partial class CementKilnRecipe :
        RecipeFamily
    {
        public CementKilnRecipe()
        {
            var product = new Recipe(
                "CementKiln",
                Localizer.DoStr("Cement Kiln"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(GearboxItem), 8, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)), 
               new IngredientElement(typeof(PistonItem), 4, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)), 
               new IngredientElement(typeof(IronBarItem), 24, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),    
                },
               new CraftingElement<CementKilnItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 20;  
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(SmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CementKilnRecipe), 100, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Cement Kiln"), typeof(CementKilnRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
}
