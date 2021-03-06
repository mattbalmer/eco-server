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
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class WashingMachineObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Washing Machine"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(WashingMachineItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<PowerConsumptionComponent>().Initialize(100);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(WashingMachineItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Washing Machine")]
    [Ecopedia("Housing Objects", "Washroom", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class WashingMachineItem :
        WorldObjectItem<WashingMachineObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Why hand scrub your clothes on a washboard when you could throw them into this magical cleaning machine?");

        static WashingMachineItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.Bathroom,
                                                    Val = 5,                                   
                                                    TypeForRoomLimit = "Washing", 
                                                    DiminishingReturnPercent = 0.2f    
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(100)}w of {new ElectricPower().Name} power");            

    }

    [RequiresSkill(typeof(IndustrySkill), 1)]     
    public partial class WashingMachineRecipe :
        RecipeFamily
    {
        public WashingMachineRecipe()
        {
            var product = new Recipe(
                "WashingMachine",
                Localizer.DoStr("Washing Machine"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelBarItem), 12, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
               new IngredientElement(typeof(BasicCircuitItem), 6, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),    
                },
               new CraftingElement<WashingMachineItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 2;  
            this.LaborInCalories = CreateLaborInCaloriesValue(400, typeof(IndustrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(WashingMachineRecipe), 10, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Washing Machine"), typeof(WashingMachineRecipe));
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }
}
