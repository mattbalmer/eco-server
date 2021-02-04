﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using System.ComponentModel;

    [RequiresSkill(typeof(FertilizersSkill), 2)]  
    public partial class PeltFertilizerRecipe : RecipeFamily
    {
        public PeltFertilizerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "PeltFertilizer",
                    Localizer.DoStr("Pelt Fertilizer"),
                    new IngredientElement[]
                    {
              new IngredientElement(typeof(FiberFillerItem), 1, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)), 
              new IngredientElement(typeof(FurPeltItem), 2, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)),   
                    },
                new CraftingElement<PeltFertilizerItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FertilizersSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(PeltFertilizerRecipe), 0.3f, typeof(FertilizersSkill), typeof(FertilizersFocusedSpeedTalent), typeof(FertilizersParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Pelt Fertilizer"), typeof(PeltFertilizerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [LocDisplayName("Pelt Fertilizer")]
    [Weight(500)]  
    [Category("Tool")]
    [Tag("Fertilizer", 1)]
    public partial class PeltFertilizerItem : FertilizerItem<PeltFertilizerItem>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A fertilize made from fur pelts and filler."); } }

        static PeltFertilizerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 4));
            nutrients.Add(new NutrientElement("Phosphorus", 2));
            nutrients.Add(new NutrientElement("Potassium", 2));
        }
    }
}
