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
    [LocDisplayName("Shorts")]
    [StartsDiscovered]
    [Weight(100)]
    [Tag("Clothes", 1)]
    [Ecopedia("Items", "Clothing", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ShortsItem :
        ClothingItem        
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Cargo shorts that are ideal for exploring the great outdoors. More practical than elegant."); } }
        public override string Slot             { get { return ClothingSlot.Pants; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class ShortsRecipe : RecipeFamily
    {
        public ShortsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Shorts",
                    Localizer.DoStr("Shorts"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(LeatherHideItem), 4, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), 
               new IngredientElement(typeof(PlantFibersItem), 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),   
                    },
                new CraftingElement<ShortsItem>()
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(TailoringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ShortsRecipe), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent)); 
            this.Initialize(Localizer.DoStr("Shorts"), typeof(ShortsRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
