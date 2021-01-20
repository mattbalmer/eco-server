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
    [LocDisplayName("Sugar")]
    [Weight(100)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SugarItem : FoodItem
    {
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Sugar"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Even sweet lovers don't eat sugar plain."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 15, Fat = 0, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 50; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillingSkill), 1)]    
    public partial class SugarRecipe :
        RecipeFamily
    {
        public SugarRecipe()
        {
            var product = new Recipe(
                "Sugar",
                Localizer.DoStr("Sugar"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(HuckleberriesItem), 8, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),   
                },
                    new CraftingElement<SugarItem>(1)  
                
            );
            this.Initialize(Localizer.DoStr("Sugar"), typeof(SugarRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill), typeof(SugarRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SugarRecipe), this.UILink(), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Sugar"), typeof(SugarRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}
