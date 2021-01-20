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
    [RequireComponent(typeof(OnOffComponent))]                   
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(HousingComponent))]                  
    public partial class TallowLampObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Tallow Lamp"); } } 


        public virtual Type RepresentedItemType { get { return typeof(TallowLampItem); } } 


        private static string[] fuelTagList = new string[]
        {
            "Fat",
        };

        protected override void Initialize()
        {

            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);                            
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);                    
            this.GetComponent<HousingComponent>().Set(TallowLampItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Tallow Lamp")]
    [Ecopedia("Housing Objects", "Lights", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class TallowLampItem :
        WorldObjectItem<TallowLampObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A pottery lamp. Fuel with tallow.");

        static TallowLampItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1,                                   
                                                    TypeForRoomLimit = "Lights", 
                                                    DiminishingReturnPercent = 0.7f    
        };}}
        
        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(1)}w of {new HeatPower().Name} power from fuel"); 

    }

    [RequiresSkill(typeof(MasonrySkill), 1)]     
    public partial class TallowLampRecipe :
        RecipeFamily
    {
        public TallowLampRecipe()
        {
            var product = new Recipe(
                "TallowLamp",
                Localizer.DoStr("Tallow Lamp"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(ClayItem), 2, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)), 
               new IngredientElement(typeof(TallowItem), 3, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),    
                },
               new CraftingElement<TallowLampItem>()
            );
            this.Initialize(Localizer.DoStr("Tallow Lamp"), typeof(TallowLampRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 2;  
            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(MasonrySkill), typeof(TallowLampRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(TallowLampRecipe), this.UILink(), 2, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Tallow Lamp"), typeof(TallowLampRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}
