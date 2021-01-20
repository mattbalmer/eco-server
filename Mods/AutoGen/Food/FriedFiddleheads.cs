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
    [LocDisplayName("Fried Fiddleheads")]
    [Weight(200)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("FriedVegetable", 1)]
    public partial class FriedFiddleheadsItem : FoodItem
    {
        public override LocString DisplayDescription            { get { return Localizer.DoStr("Secret's in the sauce."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 11, Fat = 6, Protein = 3, Vitamins = 4};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 1)]    
    public partial class FriedFiddleheadsRecipe :
        RecipeFamily
    {
        public FriedFiddleheadsRecipe()
        {
            var product = new Recipe(
                "FriedFiddleheads",
                Localizer.DoStr("Fried Fiddleheads"),
                new IngredientElement[]
                {
            new IngredientElement(typeof(FiddleheadsItem), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
            new IngredientElement("Fat", 1, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),   
                },
                    new CraftingElement<FriedFiddleheadsItem>(1)  
                
            );
            this.Initialize(Localizer.DoStr("Fried Fiddleheads"), typeof(FriedFiddleheadsRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill), typeof(FriedFiddleheadsRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(FriedFiddleheadsRecipe), this.UILink(), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Fried Fiddleheads"), typeof(FriedFiddleheadsRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}
