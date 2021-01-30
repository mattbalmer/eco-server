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

    [Serialized]
    [RequireComponent(typeof(LiquidProducerComponent))]         
    [RequireComponent(typeof(AttachmentComponent))]             
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    public partial class ElectricWaterPumpObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Electric Water Pump"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(ElectricWaterPumpItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<PowerConsumptionComponent>().Initialize(100);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        

            this.GetComponent<LiquidProducerComponent>().Setup(typeof(WaterItem), 1, this.NamedOccupancyOffset("WaterOut"));  
        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Electric Water Pump")]
    [Ecopedia("Crafted Objects", "Specialty", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [LiquidProducer(typeof(WaterItem), 1)] 
    public partial class ElectricWaterPumpItem :
        WorldObjectItem<ElectricWaterPumpObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Pumps water from a source into a pipe network.");

        static ElectricWaterPumpItem()
        {
            
        }

        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(100)}w of {new ElectricPower().Name} power");            

    }

    [RequiresSkill(typeof(MechanicsSkill), 1)]     
    public partial class ElectricWaterPumpRecipe :
        RecipeFamily
    {
        public ElectricWaterPumpRecipe()
        {
            var product = new Recipe(
                "ElectricWaterPump",
                Localizer.DoStr("Electric Water Pump"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(IronPipeItem), 12, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
               new IngredientElement(typeof(IronBarItem), 8, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),    
                },
               new CraftingElement<ElectricWaterPumpItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 10;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(MechanicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElectricWaterPumpRecipe), 8, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Electric Water Pump"), typeof(ElectricWaterPumpRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
}
