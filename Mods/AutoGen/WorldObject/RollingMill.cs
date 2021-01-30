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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(PluginModulesComponent))]           
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]                          
    [RequireRoomMaterialTier(1.8f, typeof(AdvancedSmeltingLavishReqTalent), typeof(AdvancedSmeltingFrugalReqTalent))]  
    public partial class RollingMillObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Rolling Mill"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(RollingMillItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));                
            this.GetComponent<PowerConsumptionComponent>().Initialize(250);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(RollingMillItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Rolling Mill")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [AllowPluginModules(Tags = new[] { "AdvancedUpgrade", }, ItemTypes = new[] { typeof(AdvancedSmeltingUpgradeItem), })]  
    public partial class RollingMillItem :
        WorldObjectItem<RollingMillObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("For rolling steel into more buildable materials.");

        static RollingMillItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.Industrial,
                                                    TypeForRoomLimit = "", 
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(250)}w of {new ElectricPower().Name} power");            

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(MechanicsSkill), 1)]     
    public partial class RollingMillRecipe :
        RecipeFamily
    {
        public RollingMillRecipe()
        {
            var product = new Recipe(
                "RollingMill",
                Localizer.DoStr("Rolling Mill"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelBarItem), 8, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
               new IngredientElement(typeof(GearboxItem), 4, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),    
                },
               new CraftingElement<RollingMillItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 5;  
            this.LaborInCalories = CreateLaborInCaloriesValue(600, typeof(MechanicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(RollingMillRecipe), 20, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Rolling Mill"), typeof(RollingMillRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
}
