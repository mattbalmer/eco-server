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
    [RequiresSkill(typeof(IndustrySkill), 1)]      
    public partial class SteelAxleRecipe :
        RecipeFamily
    {
        public SteelAxleRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SteelAxle",
                    Localizer.DoStr("Steel Axle"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelBarItem), 4, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                    new IngredientElement(typeof(EpoxyItem), 3, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<SteelAxleItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 1;  

            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(IndustrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelAxleRecipe), 1.5f, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Steel Axle"), typeof(SteelAxleRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ElectricLatheObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steel Axle")]
    [Weight(500)]      
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class SteelAxleItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A rotating steel rod that can be fixed to wheels for use in vehicles."); } }
    }
}
