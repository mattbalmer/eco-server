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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]                  
    public partial class CarvedPumpkinObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Carved Pumpkin"); } } 


        public virtual Type RepresentedItemType { get { return typeof(CarvedPumpkinItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(CarvedPumpkinItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Carved Pumpkin")]
    [Ecopedia("Housing Objects", "Decoration", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class CarvedPumpkinItem :
        WorldObjectItem<CarvedPumpkinObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Spooky pumpkin that emits a mystical light.");

        static CarvedPumpkinItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1,                                   
                                                    TypeForRoomLimit = "Decoration", 
                                                    DiminishingReturnPercent = 0.4f    
        };}}
        

    }

    public partial class CarvedPumpkinRecipe :
        RecipeFamily
    {
        public CarvedPumpkinRecipe()
        {
            var product = new Recipe(
                "CarvedPumpkin",
                Localizer.DoStr("Carved Pumpkin"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(TallowCandleItem), 1, true), 
               new IngredientElement(typeof(PumpkinItem), 1, true),  
                },
               new CraftingElement<CarvedPumpkinItem>()
            );
            this.Initialize(Localizer.DoStr("Carved Pumpkin"), typeof(CarvedPumpkinRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(50); 
            this.CraftMinutes = CreateCraftTimeValue(3);
            this.Initialize(Localizer.DoStr("Carved Pumpkin"), typeof(CarvedPumpkinRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
