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
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerGeneratorComponent))]         
    [RequireComponent(typeof(HousingComponent))]                  
    [PowerGenerator(typeof(MechanicalPower))]                 
    public partial class WaterwheelObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Waterwheel"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(WaterwheelItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<PowerGridComponent>().Initialize(10, new MechanicalPower());        
            this.GetComponent<PowerGeneratorComponent>().Initialize(200);                       
            this.GetComponent<HousingComponent>().Set(WaterwheelItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Waterwheel")]
    [Ecopedia("Crafted Objects", "Power Generation", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class WaterwheelItem :
        WorldObjectItem<WaterwheelObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Use the power of flowing water to produce mechanical power.");

        static WaterwheelItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Industrial",
                                                    TypeForRoomLimit = "", 
        };}}
        
        [Tooltip(8)] private LocString PowerProductionTooltip  => Localizer.Do($"Produces: {Text.Info(200)}w of {new MechanicalPower().Name} power");             

    }

    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]     
    public partial class WaterwheelRecipe :
        RecipeFamily
    {
        public WaterwheelRecipe()
        {
            var product = new Recipe(
                "Waterwheel",
                Localizer.DoStr("Waterwheel"),
                new IngredientElement[]
                {
               new IngredientElement("HewnLog", 10, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)), 
               new IngredientElement("WoodBoard", 5, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),    
                },
               new CraftingElement<WaterwheelItem>()
            );
            this.Initialize(Localizer.DoStr("Waterwheel"), typeof(WaterwheelRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 8;  
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(BasicEngineeringSkill), typeof(WaterwheelRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(WaterwheelRecipe), this.UILink(), 10, typeof(BasicEngineeringSkill), typeof(BasicEngineeringFocusedSpeedTalent), typeof(BasicEngineeringParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Waterwheel"), typeof(WaterwheelRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
