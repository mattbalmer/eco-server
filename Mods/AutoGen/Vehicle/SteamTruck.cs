// Copyright (c) Strange Loop Games. All rights reserved.
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
    [LocDisplayName("Steam Truck")]
    [Weight(25000)]  
    [AirPollution(0.2f)] 
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class SteamTruckItem : WorldObjectItem<SteamTruckObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A truck that runs on steam."); } }
    }

    [RequiresSkill(typeof(MechanicsSkill), 2)] 
    public class SteamTruckRecipe : RecipeFamily
    {
        public SteamTruckRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SteamTruck",
                    Localizer.DoStr("Steam Truck"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(IronPlateItem), 12, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
                new IngredientElement(typeof(IronPipeItem), 8, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
                new IngredientElement(typeof(ScrewsItem), 24, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
                new IngredientElement(typeof(LeatherHideItem), 20, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),   
                new IngredientElement("Lumber", 30, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),   
                new IngredientElement(typeof(PortableSteamEngineItem), 1, true), 
                new IngredientElement(typeof(IronWheelItem), 4, true), 
                new IngredientElement(typeof(IronAxleItem), 1, true),  
                    },
                new CraftingElement<SteamTruckItem>()
                )
            };
            this.ExperienceOnCraft = 25;  
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(MechanicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteamTruckRecipe), 10, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));    

            this.Initialize(Localizer.DoStr("Steam Truck"), typeof(SteamTruckRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]              
    [RequireComponent(typeof(FuelConsumptionComponent))]         
    [RequireComponent(typeof(PublicStorageComponent))]      
    [RequireComponent(typeof(MovableLinkComponent))]        
    [RequireComponent(typeof(AirPollutionComponent))]       
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]   
    [RequireComponent(typeof(TailingsReportComponent))]     
    public partial class SteamTruckObject : PhysicsWorldObject, IRepresentsItem
    {
        static SteamTruckObject()
        {
            WorldObject.AddOccupancy<SteamTruckObject>(new List<BlockOccupancy>(0));
        }

        public override LocString DisplayName { get { return Localizer.DoStr("Steam Truck"); } }
        public Type RepresentedItemType { get { return typeof(SteamTruckItem); } }

        private static string[] fuelTagList = new string[]
        {
        "Burnable Fuel",
        };

        private SteamTruckObject() { }

        protected override void Initialize()
        {
            base.Initialize();
            
            this.GetComponent<PublicStorageComponent>().Initialize(24, 5000000);           
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);           
            this.GetComponent<FuelConsumptionComponent>().Initialize(25);    
            this.GetComponent<AirPollutionComponent>().Initialize(0.2f);            
            this.GetComponent<VehicleComponent>().Initialize(18, 2, 2);
            this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2,2,3 * 2));  
        }
    }
}
