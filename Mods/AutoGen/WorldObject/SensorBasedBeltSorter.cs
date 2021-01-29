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
    public partial class SensorBasedBeltSorterObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Sensor Based Belt Sorter"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(SensorBasedBeltSorterItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));                
            this.GetComponent<PowerConsumptionComponent>().Initialize(250);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(SensorBasedBeltSorterItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Sensor Based Belt Sorter")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [AllowPluginModules(Tags = new[] { "ModernUpgrade", }, ItemTypes = new[] { typeof(MiningModernUpgradeItem), })]  
    public partial class SensorBasedBeltSorterItem :
        WorldObjectItem<SensorBasedBeltSorterObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A machine for dry concentration that produces less harmful tailings. Can only be used to concentrate Iron.");

        static SensorBasedBeltSorterItem()
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

    [RequiresSkill(typeof(IndustrySkill), 1)]     
    public partial class SensorBasedBeltSorterRecipe :
        RecipeFamily
    {
        public SensorBasedBeltSorterRecipe()
        {
            var product = new Recipe(
                "SensorBasedBeltSorter",
                Localizer.DoStr("Sensor Based Belt Sorter"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelPlateItem), 10, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
               new IngredientElement(typeof(SteelGearboxItem), 5, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
               new IngredientElement(typeof(RivetItem), 16, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
               new IngredientElement(typeof(AdvancedCircuitItem), 5, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
               new IngredientElement(typeof(BasicCircuitItem), 5, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),    
               new IngredientElement(typeof(ElectricMotorItem), 1, true),  
                },
               new CraftingElement<SensorBasedBeltSorterItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 6;  
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(IndustrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SensorBasedBeltSorterRecipe), 5, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Sensor Based Belt Sorter"), typeof(SensorBasedBeltSorterRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}
