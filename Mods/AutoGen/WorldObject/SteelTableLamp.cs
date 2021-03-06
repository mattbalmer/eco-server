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
    [RequireComponent(typeof(OnOffComponent))]                   
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    [RequireComponent(typeof(HousingComponent))]                  
    public partial class SteelTableLampObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Steel Table Lamp"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(SteelTableLampItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<PowerConsumptionComponent>().Initialize(60);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(SteelTableLampItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Steel Table Lamp")]
    [Ecopedia("Housing Objects", "Lights", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class SteelTableLampItem :
        WorldObjectItem<SteelTableLampObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("For late night studying. Or working. Or anything, really.");

        static SteelTableLampItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.General,
                                                    Val = 3,                                   
                                                    TypeForRoomLimit = "Lights", 
                                                    DiminishingReturnPercent = 0.7f    
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(60)}w of {new ElectricPower().Name} power");            

    }

    [RequiresSkill(typeof(ElectronicsSkill), 2)]     
    public partial class SteelTableLampRecipe :
        RecipeFamily
    {
        public SteelTableLampRecipe()
        {
            var product = new Recipe(
                "SteelTableLamp",
                Localizer.DoStr("Steel Table Lamp"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelBarItem), 8, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), 
               new IngredientElement(typeof(PlasticItem), 6, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), 
               new IngredientElement(typeof(CopperWiringItem), 5, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),    
               new IngredientElement(typeof(LightBulbItem), 1, true),  
                },
               new CraftingElement<SteelTableLampItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 5;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(ElectronicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelTableLampRecipe), 4, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Steel Table Lamp"), typeof(SteelTableLampRecipe));
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }
}
