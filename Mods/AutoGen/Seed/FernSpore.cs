// Copyright (c) Strange Loop Games. All rights reserved.
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
    [LocDisplayName("Fern Spore")]
    [Weight(50)]  
    [StartsDiscovered]
    [Tag("Crop Seed", 1)]                                 
    public partial class FernSporeItem : SeedItem
    {
        static FernSporeItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow ferns."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Fern"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [LocDisplayName("Fern Spore Pack")]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class FernSporePackItem : SeedPackItem
    {
        static FernSporePackItem() { }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow ferns."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Fern"); } }
    }

    [RequiresSkill(typeof(FarmingSkill), 1)]    
    public class FernSporeRecipe : RecipeFamily
    {
        public FernSporeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "FernSpore",
                    Localizer.DoStr("Fern Spore"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(FiddleheadsItem), 1, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),   
                    },
                new CraftingElement<FernSporeItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(FarmingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(FernSporeRecipe), 1, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));    

            this.Initialize(Localizer.DoStr("Fern Spore"), typeof(FernSporeRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
