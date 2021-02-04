﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Components.VehicleModules;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    
    [Serialized]
    [LocDisplayName("Wheelbarrow")]
    [Weight(5000)]  
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class WheelbarrowItem : WorldObjectItem<WheelbarrowObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Small wheelbarrow for hauling minimal loads."); } }
    }

    [RequiresSkill(typeof(CarpentrySkill), 1)] 
    public class WheelbarrowRecipe : RecipeFamily
    {
        public WheelbarrowRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Wheelbarrow",
                    Localizer.DoStr("Wheelbarrow"),
                    new IngredientElement[]
                    {
                new IngredientElement("HewnLog", 2, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
                new IngredientElement("WoodBoard", 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),   
                new IngredientElement(typeof(WoodenWheelItem), 1, true),  
                    },
                new CraftingElement<WheelbarrowItem>()
                )
            };
            this.ExperienceOnCraft = 5;  
            this.LaborInCalories = CreateLaborInCaloriesValue(75, typeof(CarpentrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(WheelbarrowRecipe), 2, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));    

            this.Initialize(Localizer.DoStr("Wheelbarrow"), typeof(WheelbarrowRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]      
    [RequireComponent(typeof(MovableLinkComponent))]        
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]     
    public partial class WheelbarrowObject : PhysicsWorldObject, IRepresentsItem
    {
        static WheelbarrowObject()
        {
            WorldObject.AddOccupancy<WheelbarrowObject>(new List<BlockOccupancy>(0));
        }

        public override LocString DisplayName { get { return Localizer.DoStr("Wheelbarrow"); } }
        public Type RepresentedItemType { get { return typeof(WheelbarrowItem); } }


        private WheelbarrowObject() { }

        protected override void Initialize()
        {
            base.Initialize();
            
            this.GetComponent<PublicStorageComponent>().Initialize(8, 1400000);           
            this.GetComponent<VehicleComponent>().Initialize(10, 1, 1);
            this.GetComponent<VehicleComponent>().HumanPowered(0.5f);           
        }
    }
}
