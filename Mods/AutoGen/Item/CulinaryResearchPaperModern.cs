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
    [RequiresSkill(typeof(AdvancedCookingSkill), 2)]      
    public partial class CulinaryResearchPaperModernRecipe :
        RecipeFamily
    {
        public CulinaryResearchPaperModernRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CulinaryResearchPaperModern",
                    Localizer.DoStr("Culinary Research Paper Modern"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(BoiledSausageItem), 10, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(BreadItem), 10, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),    
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<CulinaryResearchPaperModernItem>(), 
                    }
                )
            };


            this.ExperienceOnCraft = 8;  

            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(AdvancedCookingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Culinary Research Paper Modern"), typeof(CulinaryResearchPaperModernRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Culinary Research Paper Modern")]
    [Weight(10)]      
    [Ecopedia("Items", "Research Papers", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Modern Research", 1)]
    [Tag("Research", 1)]                                 
    public partial class CulinaryResearchPaperModernItem :
    Item                                    
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A document containing important research information. Used to discover new skills at the research table."); } }
    }
}
