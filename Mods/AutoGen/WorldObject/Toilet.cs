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
    [RequireComponent(typeof(MountComponent))]                  
    public partial class ToiletObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Toilet"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(ToiletItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(ToiletItem.HousingVal);                               
            this.GetComponent<MountComponent>().Initialize(1);                             

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Toilet")]
    [Ecopedia("Housing Objects", "Washroom", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class ToiletItem :
        WorldObjectItem<ToiletObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("When you gotta go, you gotta go.");

        static ToiletItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.Bathroom,
                                                    Val = 3,                                   
                                                    TypeForRoomLimit = "Toilet", 
                                                    DiminishingReturnPercent = 0.1f    
        };}}
        

    }

    [RequiresSkill(typeof(PotterySkill), 5)]     
    public partial class ToiletRecipe :
        RecipeFamily
    {
        public ToiletRecipe()
        {
            var product = new Recipe(
                "Toilet",
                Localizer.DoStr("Toilet"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(ClayItem), 30, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)), 
               new IngredientElement(typeof(IronBarItem), 10, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)),    
                },
               new CraftingElement<ToiletItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 2;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(PotterySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ToiletRecipe), 4, typeof(PotterySkill), typeof(PotteryFocusedSpeedTalent), typeof(PotteryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Toilet"), typeof(ToiletRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}
