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
    [LocDisplayName("Basic Backpack")]
    [StartsDiscovered]
    [Weight(100)]
    [Tag("Clothes", 1)]
    [Ecopedia("Items", "Clothing", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BasicBackpackItem :
        ClothingItem        
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A basic backpack to carry supplies.\n\nIncreases max carry weight by 5 kg."); } }
        public override string Slot             { get { return ClothingSlot.Back; } }             
        public override bool Starter            { get { return false ; } }                       

        private static Dictionary<UserStatType, float> flatStats = new Dictionary<UserStatType, float>()
    {
                { UserStatType.MaxCarryWeight, 5000 },
    };
public override Dictionary<UserStatType, float> GetFlatStats() { return flatStats; }
    }

    
    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class BasicBackpackRecipe : RecipeFamily
    {
        public BasicBackpackRecipe()
        {
            this.Initialize(Localizer.DoStr("Basic Backpack"), typeof(BasicBackpackRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "BasicBackpack",
                    Localizer.DoStr("Basic Backpack"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(LeatherHideItem), 4, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), 
               new IngredientElement(typeof(ClothItem), 5, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),   
                    },
                new CraftingElement<BasicBackpackItem>()
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(TailoringSkill), typeof(BasicBackpackRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(BasicBackpackRecipe), this.UILink(), 1, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent)); 
            this.Initialize(Localizer.DoStr("Basic Backpack"), typeof(BasicBackpackRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
