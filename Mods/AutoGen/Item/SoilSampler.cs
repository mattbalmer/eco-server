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
    [RequiresSkill(typeof(FertilizersSkill), 0)]      
    public partial class SoilSamplerRecipe :
        RecipeFamily
    {
        public SoilSamplerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SoilSampler",
                    Localizer.DoStr("Soil Sampler"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 2, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)), 
                    new IngredientElement("WoodBoard", 2, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<SoilSamplerItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 1;  

            this.LaborInCalories = CreateLaborInCaloriesValue(50, typeof(FertilizersSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SoilSamplerRecipe), 4, typeof(FertilizersSkill), typeof(FertilizersFocusedSpeedTalent), typeof(FertilizersParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Soil Sampler"), typeof(SoilSamplerRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

}
