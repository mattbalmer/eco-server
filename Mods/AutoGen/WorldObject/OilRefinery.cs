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
    [RequireComponent(typeof(LiquidConverterComponent))]        
    [RequireComponent(typeof(PluginModulesComponent))]           
    public partial class OilRefineryObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Oil Refinery"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(OilRefineryItem); } } 


        private static string[] fuelTagList = new string[]
        {
            "Burnable Fuel",
        };

        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));                
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);                            
            this.GetComponent<FuelConsumptionComponent>().Initialize(50);                    
            this.GetComponent<HousingComponent>().Set(OilRefineryItem.HousingVal);                               

            this.GetComponent<LiquidProducerComponent>().Setup(typeof(SmogItem), 1.4f, this.NamedOccupancyOffset("ChimneyOut"));  
            this.GetComponent<AirPollutionComponent>().Initialize(this.GetComponent<LiquidProducerComponent>());  
            this.GetComponent<LiquidConverterComponent>().Setup(typeof(WaterItem), typeof(SewageItem), this.NamedOccupancyOffset("WaterInputPort"), this.NamedOccupancyOffset("SewageOutputPort"), 0.3f, 0.9f); 
        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Oil Refinery")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [LiquidProducer(typeof(SmogItem), 1.4f)] 
    [AllowPluginModules(Tags = new[] { "ModernUpgrade", }, ItemTypes = new[] { typeof(OilDrillingUpgradeItem), })]  
    public partial class OilRefineryItem :
        WorldObjectItem<OilRefineryObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Sets of pipes and tanks which refine crude petroleum into usable products.");

        static OilRefineryItem()
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

    [RequiresSkill(typeof(MechanicsSkill), 1)]     
    public partial class OilRefineryRecipe :
        RecipeFamily
    {
        public OilRefineryRecipe()
        {
            var product = new Recipe(
                "OilRefinery",
                Localizer.DoStr("Oil Refinery"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(BrickItem), 12, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
               new IngredientElement(typeof(IronBarItem), 16, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
               new IngredientElement(typeof(IronGearItem), 24, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),    
                },
               new CraftingElement<OilRefineryItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 40;  
            this.LaborInCalories = CreateLaborInCaloriesValue(700, typeof(MechanicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRefineryRecipe), 20, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Oil Refinery"), typeof(OilRefineryRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
}
