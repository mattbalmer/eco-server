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
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class LargeLumberStockpileObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Lumber Stockpile"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(LargeLumberStockpileItem); } } 



        protected override void Initialize()
        {


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Large Lumber Stockpile")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class LargeLumberStockpileItem :
        WorldObjectItem<LargeLumberStockpileObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("An extra large lumber platform that has been reinforced to allow mass storage of items. ");

        static LargeLumberStockpileItem()
        {
            
        }

        

    }

    [RequiresSkill(typeof(CarpentrySkill), 5)]     
    public partial class LargeLumberStockpileRecipe :
        RecipeFamily
    {
        public LargeLumberStockpileRecipe()
        {
            var product = new Recipe(
                "LargeLumberStockpile",
                Localizer.DoStr("Large Lumber Stockpile"),
                new IngredientElement[]
                {
               new IngredientElement("Lumber", 20, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
               new IngredientElement("WoodBoard", 15, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                },
               new CraftingElement<LargeLumberStockpileItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 3;  
            this.LaborInCalories = CreateLaborInCaloriesValue(2000, typeof(CarpentrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeLumberStockpileRecipe), 12, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Large Lumber Stockpile"), typeof(LargeLumberStockpileRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}
