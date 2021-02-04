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
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class ModernStreetLightObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Modern Street Light"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(ModernStreetLightItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<PowerConsumptionComponent>().Initialize(100);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(ModernStreetLightItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Modern Street Light")]
    [Ecopedia("Housing Objects", "Lights", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class ModernStreetLightItem :
        WorldObjectItem<ModernStreetLightObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A towering metal light post that requires electricity to run.");

        static ModernStreetLightItem()
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
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(100)}w of {new ElectricPower().Name} power");            

    }

    [RequiresSkill(typeof(ElectronicsSkill), 5)]     
    public partial class ModernStreetLightRecipe :
        RecipeFamily
    {
        public ModernStreetLightRecipe()
        {
            var product = new Recipe(
                "ModernStreetLight",
                Localizer.DoStr("Modern Street Light"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelPlateItem), 6, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), 
               new IngredientElement(typeof(PlasticItem), 4, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), 
               new IngredientElement(typeof(CopperWiringItem), 6, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),    
               new IngredientElement(typeof(LightBulbItem), 1, true),  
                },
               new CraftingElement<ModernStreetLightItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 5;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(ElectronicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernStreetLightRecipe), 6, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Modern Street Light"), typeof(ModernStreetLightRecipe));
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }
}
