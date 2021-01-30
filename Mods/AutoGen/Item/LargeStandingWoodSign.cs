﻿// Copyright (c) Strange Loop Games. All rights reserved.
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
    [RequiresSkill(typeof(CarpentrySkill), 3)]      
    [Category("Hidden"), Tag("NotInBrowser")]                                    
    public partial class LargeStandingWoodSignRecipe :
        RecipeFamily
    {
        public LargeStandingWoodSignRecipe()
        {
			CraftableDefault = false; 
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "LargeStandingWoodSign",
                    Localizer.DoStr("Large Standing Wood Sign"),
                    new IngredientElement[]
                    {
                    new IngredientElement("WoodBoard", 5, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
                    new IngredientElement("HewnLog", 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
                    new IngredientElement("Wood", 10, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<LargeStandingWoodSignItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 2;  

            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CarpentrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeStandingWoodSignRecipe), 3, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Large Standing Wood Sign"), typeof(LargeStandingWoodSignRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Large Standing Wood Sign")]
    [Category("Hidden")]    
    public partial class LargeStandingWoodSignItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A large sign for all of your larger text needs!"); } }
    }
}
