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
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(MountComponent))]                  
    public partial class LumberChairObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Lumber Chair"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(LumberChairItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(LumberChairItem.HousingVal);                               
            this.GetComponent<MountComponent>().Initialize(1);                             

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Lumber Chair")]
    [Ecopedia("Housing Objects", "Seating", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class LumberChairItem :
        WorldObjectItem<LumberChairObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A sturdy lumber chair. It doesn't feel as wobbly as more basic wooden chairs.");

        static LumberChairItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1,                                   
                                                    TypeForRoomLimit = "Seating", 
                                                    DiminishingReturnPercent = 0.7f    
        };}}
        

    }

    [RequiresSkill(typeof(CarpentrySkill), 6)]     
    public partial class LumberChairRecipe :
        RecipeFamily
    {
        public LumberChairRecipe()
        {
            var product = new Recipe(
                "LumberChair",
                Localizer.DoStr("Lumber Chair"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(NailItem), 8, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
               new IngredientElement("Lumber", 6, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                },
               new CraftingElement<LumberChairItem>()
            );
            this.Initialize(Localizer.DoStr("Lumber Chair"), typeof(LumberChairRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 2;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CarpentrySkill), typeof(LumberChairRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(LumberChairRecipe), this.UILink(), 3, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Lumber Chair"), typeof(LumberChairRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}
