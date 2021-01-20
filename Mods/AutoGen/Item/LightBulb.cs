// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(ElectronicsSkill), 1)]      
    public partial class LightBulbRecipe :
        RecipeFamily
    {
        public LightBulbRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "LightBulb",
                    Localizer.DoStr("Light Bulb"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(GlassItem), 2, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)), 
                    new IngredientElement(typeof(CopperWiringItem), 6, typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<LightBulbItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 2;  

            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(ElectronicsSkill), typeof(LightBulbRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(LightBulbRecipe), this.UILink(), 2, typeof(ElectronicsSkill), typeof(ElectronicsFocusedSpeedTalent), typeof(ElectronicsParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Light Bulb"), typeof(LightBulbRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Light Bulb")]
    [Weight(50)]      
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class LightBulbItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("An electric light with a wire filament."); } }
    }
}
