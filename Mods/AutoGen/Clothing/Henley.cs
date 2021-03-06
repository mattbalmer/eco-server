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
    [LocDisplayName("Henley")]
    [StartsDiscovered]
    [Weight(100)]
    [Tag("Clothes", 1)]
    [Ecopedia("Items", "Clothing", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class HenleyItem :
        ClothingItem        
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A Henley shirt is a collarless pullover shirt, characterized by a placket beneath the round neckline, about 8 to 13 cm long and usually having 2 to 5 buttons. It essentially resembles a collarless polo shirt."); } }
        public override string Slot             { get { return ClothingSlot.Shirt; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class HenleyRecipe : RecipeFamily
    {
        public HenleyRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Henley",
                    Localizer.DoStr("Henley"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(LeatherHideItem), 1, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), 
               new IngredientElement(typeof(PlantFibersItem), 25, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),   
                    },
                new CraftingElement<HenleyItem>()
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(TailoringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(HenleyRecipe), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent)); 
            this.Initialize(Localizer.DoStr("Henley"), typeof(HenleyRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
