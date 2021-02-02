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
    [RequiresSkill(typeof(SmeltingSkill), 1)]      
    public partial class IronSawBladeRecipe :
        RecipeFamily
    {
        public IronSawBladeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "IronSawBlade",
                    Localizer.DoStr("Iron Saw Blade"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 6, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<IronSawBladeItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 2;  

            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(SmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronSawBladeRecipe), 1.2f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Iron Saw Blade"), typeof(IronSawBladeRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Iron Saw Blade")]
    [Weight(100)]      
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class IronSawBladeItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A disc shaped iron saw that can be attached to rotary machines to shape wood products."); } }
    }
}
