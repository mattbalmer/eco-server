﻿// Copyright (c) Strange Loop Games. All rights reserved.
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
    [LocDisplayName("Derpy Hat")]
    [StartsDiscovered]
    [Weight(100)]
    [Tag("Clothes", 1)]
    [Ecopedia("Items", "Clothing", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class DerpyHatItem :
        ClothingItem        
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Dorky sombrero that doesn't fit anyone. You feel embarrassed to wear it."); } }
        public override string Slot             { get { return ClothingSlot.Head; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class DerpyHatRecipe : RecipeFamily
    {
        public DerpyHatRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "DerpyHat",
                    Localizer.DoStr("Derpy Hat"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(LeatherHideItem), 2, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), 
               new IngredientElement(typeof(PlantFibersItem), 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),   
                    },
                new CraftingElement<DerpyHatItem>()
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(TailoringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(DerpyHatRecipe), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent)); 
            this.Initialize(Localizer.DoStr("Derpy Hat"), typeof(DerpyHatRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
