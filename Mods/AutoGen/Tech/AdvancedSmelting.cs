﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [LocDisplayName("Advanced Smelting")]
    [Ecopedia("Professions", "Smith", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]    
    [RequiresSkill(typeof(SmithSkill), 0), Tag("Smith Specialty"), Tier(4)]    
    public partial class AdvancedSmeltingSkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced smelting aids in the production of steel - a key ingredient in the progress of any group. Level by crafting advanced smelting recipes."); } }

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }


        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 1,
                
                1 - 0.5f,
                
                1 - 0.55f,
                
                1 - 0.6f,
                
                1 - 0.65f,
                
                1 - 0.7f,
                
                1 - 0.75f,
                
                1 - 0.8f,
                
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;
        public static AdditiveStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 0,
                
                0.5f,
                
                0.55f,
                
                0.6f,
                
                0.65f,
                
                0.7f,
                
                0.75f,
                
                0.8f,
                
            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public static int[] SkillPointCost = {
            
            1,
            
            1,
            
            1,
            
            1,
            
            1,
            
            1,
            
            1,
            
        };
        public override int RequiredPoint { get { return this.Level < SkillPointCost.Length ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < SkillPointCost.Length ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 4; } }
    }

    [Serialized]
    [LocDisplayName("Advanced Smelting Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class AdvancedSmeltingSkillBook : SkillBook<AdvancedSmeltingSkill, AdvancedSmeltingSkillScroll>
    {
    }

    [Serialized]
    [LocDisplayName("Advanced Smelting Skill Scroll")]
    public partial class AdvancedSmeltingSkillScroll : SkillScroll<AdvancedSmeltingSkill, AdvancedSmeltingSkillBook>
    {
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)] 
    public partial class AdvancedSmeltingSkillBookRecipe : RecipeFamily
    {
        public AdvancedSmeltingSkillBookRecipe()
        {
            this.Initialize(Localizer.DoStr("Advanced Smelting"), typeof(AdvancedSmeltingSkillBookRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "AdvancedSmelting",
                    Localizer.DoStr("Advanced Smelting"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(MetallurgyResearchPaperBasicItem), 20), 
               new IngredientElement(typeof(MetallurgyResearchPaperAdvancedItem), 20),  
 new IngredientElement("Basic Research", 10),  
                    },
                new CraftingElement<AdvancedSmeltingSkillBook>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(10000); 
            this.CraftMinutes = CreateCraftTimeValue(30);

            this.Initialize(Localizer.DoStr("Advanced Smelting Skill Book"), typeof(AdvancedSmeltingSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
