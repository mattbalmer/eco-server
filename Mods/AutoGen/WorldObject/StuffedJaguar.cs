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
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class StuffedJaguarObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stuffed Jaguar"); } } 


        public virtual Type RepresentedItemType { get { return typeof(StuffedJaguarItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(StuffedJaguarItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Stuffed Jaguar")]
    [Ecopedia("Housing Objects", "Decoration", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class StuffedJaguarItem :
        WorldObjectItem<StuffedJaguarObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("It looks so real!");

        static StuffedJaguarItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.General,
                                                    Val = 3,                                   
                                                    TypeForRoomLimit = "Decoration", 
                                                    DiminishingReturnPercent = 0.1f    
        };}}
        

    }

    [RequiresSkill(typeof(TailoringSkill), 5)]     
    public partial class StuffedJaguarRecipe :
        RecipeFamily
    {
        public StuffedJaguarRecipe()
        {
            var product = new Recipe(
                "StuffedJaguar",
                Localizer.DoStr("Stuffed Jaguar"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(ClothItem), 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),    
               new IngredientElement("Lumber", 5, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),    
               new IngredientElement(typeof(JaguarCarcassItem), 1, true),  
                },
               new CraftingElement<StuffedJaguarItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 4;  
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(TailoringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(StuffedJaguarRecipe), 12, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Stuffed Jaguar"), typeof(StuffedJaguarRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}
