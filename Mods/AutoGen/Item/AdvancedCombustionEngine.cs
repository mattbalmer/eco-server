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
    [RequiresSkill(typeof(IndustrySkill), 1)]      
    public partial class AdvancedCombustionEngineRecipe :
        RecipeFamily
    {
        public AdvancedCombustionEngineRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "AdvancedCombustionEngine",
                    Localizer.DoStr("Advanced Combustion Engine"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(SteelPlateItem), 16, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                    new IngredientElement(typeof(RivetItem), 12, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                    new IngredientElement(typeof(PistonItem), 6, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                    new IngredientElement(typeof(ValveItem), 6, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                    new IngredientElement(typeof(ServoItem), 6, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                    new IngredientElement(typeof(AdvancedCircuitItem), 6, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)), 
                    new IngredientElement(typeof(RadiatorItem), 3, typeof(IndustrySkill), typeof(IndustryLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<AdvancedCombustionEngineItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 20;  

            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(IndustrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(AdvancedCombustionEngineRecipe), 4, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));     
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Advanced Combustion Engine"), typeof(AdvancedCombustionEngineRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Advanced Combustion Engine")]
    [Weight(1000)]      
    [Tag("Currency")][Currency]              
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class AdvancedCombustionEngineItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A more advanced version of the normal combustion engine that produces a greater output."); } }
    }
}
