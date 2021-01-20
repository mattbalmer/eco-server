// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(MiningSkill), 4)] 
    public partial class ConcentrateGoldLv2Recipe :
        RecipeFamily
    {
        public ConcentrateGoldLv2Recipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ConcentrateGoldLv2",
                    Localizer.DoStr("Concentrate Gold Lv2"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(CrushedGoldOreItem), 10, typeof(MiningSkill)),    
                    },
                    new CraftingElement[]
                    {
               new CraftingElement<GoldConcentrateItem>(2),  
               new CraftingElement<WetTailingsItem>(typeof(MiningSkill), 3),     
                    })
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(MiningSkill), typeof(ConcentrateGoldLv2Recipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ConcentrateGoldLv2Recipe), this.UILink(), 0.8f, typeof(MiningSkill));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Concentrate Gold Lv2"), typeof(ConcentrateGoldLv2Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FrothFloatationCellObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
