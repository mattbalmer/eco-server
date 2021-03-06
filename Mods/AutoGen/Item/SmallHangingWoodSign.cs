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
    [RequiresSkill(typeof(CarpentrySkill), 1)]      
    [Category("Hidden"), Tag("NotInBrowser")]                                    
    public partial class SmallHangingWoodSignRecipe :
        RecipeFamily
    {
        public SmallHangingWoodSignRecipe()
        {
			CraftableDefault = false; 
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SmallHangingWoodSign",
                    Localizer.DoStr("Small Hanging Wood Sign"),
                    new IngredientElement[]
                    {
                    new IngredientElement("WoodBoard", 2, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
                    new IngredientElement("HewnLog", 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
                    new IngredientElement("Wood", 5, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<SmallHangingWoodSignItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 1;  

            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(CarpentrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmallHangingWoodSignRecipe), 2, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Small Hanging Wood Sign"), typeof(SmallHangingWoodSignRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Small Hanging Wood Sign")]
    [Category("Hidden")]    
    public partial class SmallHangingWoodSignItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A small sign for all of your smaller text needs!"); } }
    }
}
