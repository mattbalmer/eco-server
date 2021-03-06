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
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]                          
    [RequireRoomMaterialTier(0.8f)]  
    public partial class RealEstateDeskObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Real Estate Desk"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Paper; 

        public virtual Type RepresentedItemType { get { return typeof(RealEstateDeskItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Economy"));                

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Real Estate Desk")]
    [Ecopedia("Work Stations", "Economic", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class RealEstateDeskItem :
        WorldObjectItem<RealEstateDeskObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A place to manage the sale and transfer of deeds and property.");

        static RealEstateDeskItem()
        {
            
        }

        

    }

    [RequiresSkill(typeof(CarpentrySkill), 4)]     
    public partial class RealEstateDeskRecipe :
        RecipeFamily
    {
        public RealEstateDeskRecipe()
        {
            var product = new Recipe(
                "RealEstateDesk",
                Localizer.DoStr("Real Estate Desk"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(PlantFibersItem), 40, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
               new IngredientElement("HewnLog", 15, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
               new IngredientElement("WoodBoard", 10, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                },
               new CraftingElement<RealEstateDeskItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 5;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CarpentrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(RealEstateDeskRecipe), 2, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Real Estate Desk"), typeof(RealEstateDeskRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
