﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.SearchAndSelect;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [LocDisplayName("Tomato Seed")]
    [Weight(50)]  
    [StartsDiscovered]
    [Tag("Crop Seed", 1)]                                 
    public partial class TomatoSeedItem : SeedItem
    {
        static TomatoSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow tomato plants."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Tomatoes"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [LocDisplayName("Tomato Seed Pack")]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class TomatoSeedPackItem : SeedPackItem
    {
        static TomatoSeedPackItem() { }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow tomato plants."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Tomatoes"); } }
    }

    [RequiresSkill(typeof(FarmingSkill), 1)]    
    public class TomatoSeedRecipe : RecipeFamily
    {
        public TomatoSeedRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "TomatoSeed",
                    Localizer.DoStr("Tomato Seed"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(TomatoItem), 2, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),   
                    },
                new CraftingElement<TomatoSeedItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(FarmingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(TomatoSeedRecipe), 1, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));    

            this.Initialize(Localizer.DoStr("Tomato Seed"), typeof(TomatoSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
