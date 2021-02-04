// Copyright (c) Strange Loop Games. All rights reserved.
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
    [RequiresSkill(typeof(IndustrySkill), 1)]      
    public partial class SteelGearboxRecipe :
        RecipeFamily
    {
        public SteelGearboxRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SteelGearbox",
                    Localizer.DoStr("Steel Gearbox"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 8, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                    new IngredientElement(typeof(SteelGearItem), 4, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<SteelGearboxItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 2.5f;  

            this.LaborInCalories = CreateLaborInCaloriesValue(160, typeof(IndustrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelGearboxRecipe), 2, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Steel Gearbox"), typeof(SteelGearboxRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ElectricPlanerObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steel Gearbox")]
    [Weight(500)]      
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class SteelGearboxItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Provides speed and torque conversions from a rotating power source to another device"); } }
    }
}
