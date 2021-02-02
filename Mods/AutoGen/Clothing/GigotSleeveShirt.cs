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
    [LocDisplayName("Gigot Sleeve Shirt")]
    [StartsDiscovered]
    [Weight(100)]
    [Tag("Clothes", 1)]
    [Ecopedia("Items", "Clothing", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class GigotSleeveShirtItem :
        ClothingItem        
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Cool piratey shirt that makes your biceps look bigger than they really are."); } }
        public override string Slot             { get { return ClothingSlot.Shirt; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(TailoringSkill), 1)]
    public class GigotSleeveShirtRecipe : RecipeFamily
    {
        public GigotSleeveShirtRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GigotSleeveShirt",
                    Localizer.DoStr("Gigot Sleeve Shirt"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(PlantFibersItem), 30, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),   
                    },
                new CraftingElement<GigotSleeveShirtItem>()
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(TailoringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(GigotSleeveShirtRecipe), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent)); 
            this.Initialize(Localizer.DoStr("Gigot Sleeve Shirt"), typeof(GigotSleeveShirtRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}
