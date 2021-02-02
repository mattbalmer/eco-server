﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(BasicEngineeringSkill), 1)]      
    public partial class WoodenWheelRecipe :
        RecipeFamily
    {
        public WoodenWheelRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "WoodenWheel",
                    Localizer.DoStr("Wooden Wheel"),
                    new IngredientElement[]
                    {
                    new IngredientElement("HewnLog", 4, typeof(BasicEngineeringSkill), typeof(BasicEngineeringLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<WoodenWheelItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 1;  

            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(BasicEngineeringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodenWheelRecipe), 2, typeof(BasicEngineeringSkill), typeof(BasicEngineeringFocusedSpeedTalent), typeof(BasicEngineeringParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wooden Wheel"), typeof(WoodenWheelRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(WainwrightTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Wooden Wheel")]
    [Weight(500)]      
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class WoodenWheelItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A basic wheel for use in early wooden vehicles."); } }
    }
}
