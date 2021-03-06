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
    [LocDisplayName("Skid Steer")]
    [Weight(25000)]  
    [AirPollution(0.5f)] 
    [Ecopedia("Crafted Objects", "Vehicles", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class SkidSteerItem : WorldObjectItem<SkidSteerObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Small scale bucket loader. Great for flat to low slope excavation."); } }
    }

    [RequiresSkill(typeof(IndustrySkill), 1)] 
    public class SkidSteerRecipe : RecipeFamily
    {
        public SkidSteerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SkidSteer",
                    Localizer.DoStr("Skid Steer"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(GearboxItem), 4, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                new IngredientElement(typeof(CelluloseFiberItem), 8, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                new IngredientElement(typeof(SteelPlateItem), 16, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),   
                new IngredientElement(typeof(AdvancedCombustionEngineItem), 1, true), 
                new IngredientElement(typeof(RubberWheelItem), 4, true), 
                new IngredientElement(typeof(RadiatorItem), 2, true), 
                new IngredientElement(typeof(SteelAxleItem), 1, true),  
                    },
                new CraftingElement<SkidSteerItem>()
                )
            };
            this.ExperienceOnCraft = 24;  
            this.LaborInCalories = CreateLaborInCaloriesValue(2500, typeof(IndustrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SkidSteerRecipe), 10, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));    

            this.Initialize(Localizer.DoStr("Skid Steer"), typeof(SkidSteerRecipe));
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }
    }

}
