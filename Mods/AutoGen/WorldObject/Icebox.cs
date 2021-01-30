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
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(PublicStorageComponent))]                
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class IceboxObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Icebox"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(IceboxItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(IceboxItem.HousingVal);                               
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(8);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large itemsa

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Icebox")]
    [Ecopedia("Housing Objects", "Kitchen", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class IceboxItem :
        WorldObjectItem<IceboxObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A box of ice. It's in the name!");

        static IceboxItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.Kitchen,
                                                    Val = 1.5f,                                   
                                                    TypeForRoomLimit = "Food Storage", 
                                                    DiminishingReturnPercent = 0.3f    
        };}}
        

    }

    [RequiresSkill(typeof(CarpentrySkill), 5)]     
    public partial class IceboxRecipe :
        RecipeFamily
    {
        public IceboxRecipe()
        {
            var product = new Recipe(
                "Icebox",
                Localizer.DoStr("Icebox"),
                new IngredientElement[]
                {
               new IngredientElement("HewnLog", 10, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
               new IngredientElement("WoodBoard", 12, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                },
               new CraftingElement<IceboxItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 3;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CarpentrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(IceboxRecipe), 2, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Icebox"), typeof(IceboxRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
