// Copyright (c) Strange Loop Games. All rights reserved.
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
    [RequireRoomVolume(45)]                          
    [RequireRoomMaterialTier(2.7f, typeof(IndustryLavishReqTalent), typeof(IndustryFrugalReqTalent))]  
    public partial class ElectricStampingPressObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Electric Stamping Press"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(ElectricStampingPressItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Crafting"));                
            this.GetComponent<PowerConsumptionComponent>().Initialize(100);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(ElectricStampingPressItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Electric Stamping Press")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [AllowPluginModules(Tags = new[] { "ModernUpgrade", }, ItemTypes = new[] { typeof(IndustryUpgradeItem), })]  
    public partial class ElectricStampingPressItem :
        WorldObjectItem<ElectricStampingPressObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A tool for shaping or cutting metal by deforming it with a die.");

        static ElectricStampingPressItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Industrial",
                                                    TypeForRoomLimit = "", 
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(100)}w of {new ElectricPower().Name} power");            

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(IndustrySkill), 1)]     
    public partial class ElectricStampingPressRecipe :
        RecipeFamily
    {
        public ElectricStampingPressRecipe()
        {
            var product = new Recipe(
                "ElectricStampingPress",
                Localizer.DoStr("Electric Stamping Press"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelBarItem), 24, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),    
                },
               new CraftingElement<ElectricStampingPressItem>()
            );
            this.Initialize(Localizer.DoStr("Electric Stamping Press"), typeof(ElectricStampingPressRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 20;  
            this.LaborInCalories = CreateLaborInCaloriesValue(400, typeof(IndustrySkill), typeof(ElectricStampingPressRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ElectricStampingPressRecipe), this.UILink(), 8, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Electric Stamping Press"), typeof(ElectricStampingPressRecipe));
            CraftingComponent.AddRecipe(typeof(ElectricMachinistTableObject), this);
        }
    }
}
