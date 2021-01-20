// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [LocDisplayName("Garden Boots")]
    [StartsDiscovered]
    [Weight(100)]
    [Tag("Clothes", 1)]
    [Ecopedia("Items", "Clothing", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class GardenBootsItem :
        ClothingItem        
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A sturdy pair of rubber footwear designed to provide protection against water, rain, and mud."); } }
        public override string Slot             { get { return ClothingSlot.Shoes; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class GardenBootsRecipe : RecipeFamily
    {
        public GardenBootsRecipe()
        {
            this.Initialize(Localizer.DoStr("Garden Boots"), typeof(GardenBootsRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GardenBoots",
                    Localizer.DoStr("Garden Boots"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(LeatherHideItem), 2, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), 
               new IngredientElement(typeof(FurPeltItem), 6, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),   
                    },
                new CraftingElement<GardenBootsItem>()
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(TailoringSkill), typeof(GardenBootsRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(GardenBootsRecipe), this.UILink(), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent)); 
            this.Initialize(Localizer.DoStr("Garden Boots"), typeof(GardenBootsRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
