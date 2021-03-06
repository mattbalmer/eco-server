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
    [LocDisplayName("Cookeina Mushroom Spores")]
    [Weight(50)]  
    [StartsDiscovered]
    [Tag("Crop Seed", 1)]                                 
    public partial class CookeinaMushroomSporesItem : SeedItem
    {
        static CookeinaMushroomSporesItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow cookeina mushrooms."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("CookeinaMushroom"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [LocDisplayName("Cookeina Mushroom Spores Pack")]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class CookeinaMushroomSporesPackItem : SeedPackItem
    {
        static CookeinaMushroomSporesPackItem() { }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow cookeina mushrooms."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("CookeinaMushroom"); } }
    }

    [RequiresSkill(typeof(FarmingSkill), 1)]    
    public class CookeinaMushroomSporesRecipe : RecipeFamily
    {
        public CookeinaMushroomSporesRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CookeinaMushroomSpores",
                    Localizer.DoStr("Cookeina Mushroom Spores"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(CookeinaMushroomsItem), 1, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),   
                    },
                new CraftingElement<CookeinaMushroomSporesItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(FarmingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CookeinaMushroomSporesRecipe), 1, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));    

            this.Initialize(Localizer.DoStr("Cookeina Mushroom Spores"), typeof(CookeinaMushroomSporesRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
