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
    [LocDisplayName("Carpentry")]
    [Ecopedia("Professions", "Carpenter", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]    
    [RequiresSkill(typeof(CarpenterSkill), 0), Tag("Carpenter Specialty"), Tier(1)]    
    [Tag("Specialty")] 
    public partial class CarpentrySkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Cutting logs into usable crafting and building materials is an important skill for budding communities. Level by crafting related recipes."); } }

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
        public override int Tier { get { return 1; } }
    }

    [Serialized]
    [LocDisplayName("Carpentry Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CarpentrySkillBook : SkillBook<CarpentrySkill, CarpentrySkillScroll>
    {
    }

    [Serialized]
    [LocDisplayName("Carpentry Skill Scroll")]
    public partial class CarpentrySkillScroll : SkillScroll<CarpentrySkill, CarpentrySkillBook>
    {
    }

    [RequiresSkill(typeof(LoggingSkill), 0)] 
    public partial class CarpentrySkillBookRecipe : RecipeFamily
    {
        public CarpentrySkillBookRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Carpentry",
                    Localizer.DoStr("Carpentry"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(DendrologyResearchPaperBasicItem), 3),  
                    },
                new CraftingElement<CarpentrySkillBook>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(500); 
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.Initialize(Localizer.DoStr("Carpentry Skill Book"), typeof(CarpentrySkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
