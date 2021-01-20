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
    [LocDisplayName("Charred Taro")]
    [Weight(100)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("CharredVegetable", 1)]
    public partial class CharredTaroItem : FoodItem
    {
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Charred Taro"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Blackened taro root. Not the tastiest meal, but a great source of energy for early rainforest settlers."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 0, Protein = 1, Vitamins = 1};
        public override float Calories                          { get { return 350; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 0)]    
    public partial class CharredTaroRecipe :
        RecipeFamily
    {
        public CharredTaroRecipe()
        {
            var product = new Recipe(
                "CharredTaro",
                Localizer.DoStr("Charred Taro"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(TaroRootItem), 1, true),  
                },
                    new CraftingElement<CharredTaroItem>(1)  
                
            );
            this.Initialize(Localizer.DoStr("Charred Taro"), typeof(CharredTaroRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill), typeof(CharredTaroRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredTaroRecipe), this.UILink(), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Charred Taro"), typeof(CharredTaroRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
