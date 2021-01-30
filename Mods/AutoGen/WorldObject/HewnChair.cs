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
    public partial class HewnChairObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Hewn Chair"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(HewnChairItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(HewnChairItem.HousingVal);                               
            this.GetComponent<MountComponent>().Initialize(1);                             

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Hewn Chair")]
    [Ecopedia("Housing Objects", "Seating", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class HewnChairItem :
        WorldObjectItem<HewnChairObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A raised surface supported by legs. Without the back, it might be a stool.");

        static HewnChairItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.General,
                                                    Val = 0.5f,                                   
                                                    TypeForRoomLimit = "Seating", 
                                                    DiminishingReturnPercent = 0.7f    
        };}}
        

    }

    [RequiresSkill(typeof(CarpentrySkill), 1)]     
    public partial class HewnChairRecipe :
        RecipeFamily
    {
        public HewnChairRecipe()
        {
            var product = new Recipe(
                "HewnChair",
                Localizer.DoStr("Hewn Chair"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(PlantFibersItem), 12, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
               new IngredientElement("HewnLog", 12, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
               new IngredientElement("WoodBoard", 12, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                },
               new CraftingElement<HewnChairItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 2;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CarpentrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(HewnChairRecipe), 3, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Hewn Chair"), typeof(HewnChairRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
