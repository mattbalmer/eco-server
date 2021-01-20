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
    [RequireRoomMaterialTier(1.7f, typeof(MechanicsLavishReqTalent), typeof(MechanicsFrugalReqTalent))]  
    public partial class LatheObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Lathe"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(LatheItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));                
            this.GetComponent<PowerConsumptionComponent>().Initialize(200);                      
            this.GetComponent<PowerGridComponent>().Initialize(5, new MechanicalPower());        
            this.GetComponent<HousingComponent>().Set(LatheItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Lathe")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [AllowPluginModules(Tags = new[] { "AdvancedUpgrade", }, ItemTypes = new[] { typeof(MechanicsAdvancedUpgradeItem), })]  
    public partial class LatheItem :
        ModuleItem<LatheObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A set of smoothing and woodworking tools that assist in creating wheels and transportation.");

        static LatheItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Industrial",
                                                    TypeForRoomLimit = "", 
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(200)}w of {new MechanicalPower().Name} power");            

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresModule(typeof(ScrewPressObject))]           
    [RequiresSkill(typeof(MechanicsSkill), 1)]     
    public partial class LatheRecipe :
        RecipeFamily
    {
        public LatheRecipe()
        {
            var product = new Recipe(
                "Lathe",
                Localizer.DoStr("Lathe"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(IronWheelItem), 4, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
               new IngredientElement(typeof(IronPlateItem), 12, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),    
                },
               new CraftingElement<LatheItem>()
            );
            this.Initialize(Localizer.DoStr("Lathe"), typeof(LatheRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 20;  
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(MechanicsSkill), typeof(LatheRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(LatheRecipe), this.UILink(), 5, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Lathe"), typeof(LatheRecipe));
            CraftingComponent.AddRecipe(typeof(MachinistTableObject), this);
        }
    }
}
