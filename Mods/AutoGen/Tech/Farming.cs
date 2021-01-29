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
    [LocDisplayName("Farming")]
    [Ecopedia("Professions", "Farmer", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]    
    [RequiresSkill(typeof(FarmerSkill), 0), Tag("Farmer Specialty"), Tier(2)]    
    [Tag("Specialty")] 
    public partial class FarmingSkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The art of planting and cultivating flora. Level by crafting related recipes and using the hoe."); } }

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
        public override int Tier { get { return 2; } }
    }

    [Serialized]
    [LocDisplayName("Farming Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FarmingSkillBook : SkillBook<FarmingSkill, FarmingSkillScroll>
    {
    }

    [Serialized]
    [LocDisplayName("Farming Skill Scroll")]
    public partial class FarmingSkillScroll : SkillScroll<FarmingSkill, FarmingSkillBook>
    {
    }

    [RequiresSkill(typeof(GatheringSkill), 0)] 
    public partial class FarmingSkillBookRecipe : RecipeFamily
    {
        public FarmingSkillBookRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Farming",
                    Localizer.DoStr("Farming"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(GatheringResearchPaperBasicItem), 2), 
               new IngredientElement(typeof(GeologyResearchPaperBasicItem), 1),  
                    },
                new CraftingElement<FarmingSkillBook>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(500); 
            this.CraftMinutes = CreateCraftTimeValue(5);

            this.Initialize(Localizer.DoStr("Farming Skill Book"), typeof(FarmingSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
