// Copyright (c) Strange Loop Games. All rights reserved.
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

    [RequiresSkill(typeof(FertilizersSkill), 3)]  
    public partial class CompositeFillerRecipe : RecipeFamily
    {
        public CompositeFillerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CompositeFiller",
                    Localizer.DoStr("Composite Filler"),
                    new IngredientElement[]
                    {
              new IngredientElement(typeof(PulpFillerItem), 1, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)), 
              new IngredientElement(typeof(FiberFillerItem), 1, typeof(FertilizersSkill), typeof(FertilizersLavishResourcesTalent)),   
                    },
                new CraftingElement<CompositeFillerItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FertilizersSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CompositeFillerRecipe), 0.3f, typeof(FertilizersSkill), typeof(FertilizersFocusedSpeedTalent), typeof(FertilizersParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Composite Filler"), typeof(CompositeFillerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [LocDisplayName("Composite Filler")]
    [Weight(500)]  
    [Category("Tool")]
    [Tag("Fertilizer", 1)]
    public partial class CompositeFillerItem : FertilizerItem<CompositeFillerItem>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A mix of different fillers that provide the benefits of both"); } }

        static CompositeFillerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 0.5f));
            nutrients.Add(new NutrientElement("Phosphorus", 0.5f));
            nutrients.Add(new NutrientElement("Potassium", 0.5f));
        }
    }
}
