// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.EcopediaRoot;

    [Serialized]
    [LocDisplayName("Baked Tomato")]
    [Weight(300)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("BakedVegetable", 1)]
    [Tag("BakedFood", 1)]
    public partial class BakedTomatoItem : FoodItem
    {
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Baked tomatoes might not look as red or plump as the raw variety, but they are nice and tasty."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 5, Protein = 1, Vitamins = 13};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BakingSkill), 1)]    
    public partial class BakedTomatoRecipe :
        RecipeFamily
    {
        public BakedTomatoRecipe()
        {
            var product = new Recipe(
                "BakedTomato",
                Localizer.DoStr("Baked Tomato"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(TomatoItem), 4, typeof(BakingSkill), typeof(BakingLavishResourcesTalent)),   
                },
                    new CraftingElement<BakedTomatoItem>(1)  
                
            );
            this.Initialize(Localizer.DoStr("Baked Tomato"), typeof(BakedTomatoRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(BakingSkill), typeof(BakedTomatoRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(BakedTomatoRecipe), this.UILink(), 2, typeof(BakingSkill), typeof(BakingFocusedSpeedTalent), typeof(BakingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Baked Tomato"), typeof(BakedTomatoRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}
