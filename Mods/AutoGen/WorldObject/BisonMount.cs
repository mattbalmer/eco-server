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
    public partial class BisonMountObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Bison Mount"); } } 


        public virtual Type RepresentedItemType { get { return typeof(BisonMountItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(BisonMountItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Bison Mount")]
    [Ecopedia("Housing Objects", "Decoration", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class BisonMountItem :
        WorldObjectItem<BisonMountObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A fluffy, but very dead, bison head on a mount.");

        static BisonMountItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2.5f,                                   
                                                    TypeForRoomLimit = "Decoration", 
                                                    DiminishingReturnPercent = 0.2f    
        };}}
        

    }

    [RequiresSkill(typeof(TailoringSkill), 4)]     
    public partial class BisonMountRecipe :
        RecipeFamily
    {
        public BisonMountRecipe()
        {
            var product = new Recipe(
                "BisonMount",
                Localizer.DoStr("Bison Mount"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(ClothItem), 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),    
               new IngredientElement("Lumber", 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),    
               new IngredientElement(typeof(BisonCarcassItem), 1, true),  
                },
               new CraftingElement<BisonMountItem>()
            );
            this.Initialize(Localizer.DoStr("Bison Mount"), typeof(BisonMountRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 4;  
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(TailoringSkill), typeof(BisonMountRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(BisonMountRecipe), this.UILink(), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Bison Mount"), typeof(BisonMountRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}
