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
    public partial class SmallStockpileObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Small Stockpile"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(SmallStockpileItem); } } 



        protected override void Initialize()
        {


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Small Stockpile")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class SmallStockpileItem :
        WorldObjectItem<SmallStockpileObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Designates a 3x3x3 area as storage for large items.");

        static SmallStockpileItem()
        {
            
        }

        

    }

    public partial class SmallStockpileRecipe :
        RecipeFamily
    {
        public SmallStockpileRecipe()
        {
            var product = new Recipe(
                "SmallStockpile",
                Localizer.DoStr("Small Stockpile"),
                new IngredientElement[]
                {
               new IngredientElement("Wood", 5),   
                },
               new CraftingElement<SmallStockpileItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(10); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.Initialize(Localizer.DoStr("Small Stockpile"), typeof(SmallStockpileRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
