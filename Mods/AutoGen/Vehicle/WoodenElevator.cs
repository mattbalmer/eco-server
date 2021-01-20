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
    [LocDisplayName("Wooden Elevator")]
    [Weight(10000)]  
    [Ecopedia("Crafted Objects", "Specialty", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class WoodenElevatorItem : WorldObjectItem<WoodenElevatorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An elevator for transporting loads vertically."); } }
    }

    [RequiresSkill(typeof(MechanicsSkill), 1)] 
    public class WoodenElevatorRecipe : RecipeFamily
    {
        public WoodenElevatorRecipe()
        {
            this.Initialize(Localizer.DoStr("Wooden Elevator"), typeof(WoodenElevatorRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "WoodenElevator",
                    Localizer.DoStr("Wooden Elevator"),
                    new IngredientElement[]
                    {
                new IngredientElement(typeof(GearboxItem), 4, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
                new IngredientElement(typeof(CelluloseFiberItem), 4, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),   
                new IngredientElement("Lumber", 30, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),   
                new IngredientElement(typeof(PortableSteamEngineItem), 1, true),  
                    },
                new CraftingElement<WoodenElevatorItem>()
                )
            };
            this.ExperienceOnCraft = 15;  
            this.LaborInCalories = CreateLaborInCaloriesValue(500, typeof(MechanicsSkill), typeof(WoodenElevatorRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodenElevatorRecipe), this.UILink(), 10, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));    

            this.Initialize(Localizer.DoStr("Wooden Elevator"), typeof(WoodenElevatorRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }

}
