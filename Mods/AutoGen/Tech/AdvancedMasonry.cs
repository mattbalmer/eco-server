// Copyright (c) Strange Loop Games. All rights reserved.
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
    [LocDisplayName("Advanced Masonry")]
    [Ecopedia("Professions", "Mason", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]    
    [RequiresSkill(typeof(MasonSkill), 0), Tag("Mason Specialty"), Tier(4)]    
    [Tag("Specialty")] 
    public partial class AdvancedMasonrySkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced masonry allows the production of high-quality stone furniture and material for houses. Level by crafting related recipes. "); } }

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
    [LocDisplayName("Advanced Masonry Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class AdvancedMasonrySkillBook : SkillBook<AdvancedMasonrySkill, AdvancedMasonrySkillScroll>
    {
    }

    [Serialized]
    [LocDisplayName("Advanced Masonry Skill Scroll")]
    public partial class AdvancedMasonrySkillScroll : SkillScroll<AdvancedMasonrySkill, AdvancedMasonrySkillBook>
    {
    }

    [RequiresSkill(typeof(PotterySkill), 1)] 
    public partial class AdvancedMasonrySkillBookRecipe : RecipeFamily
    {
        public AdvancedMasonrySkillBookRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "AdvancedMasonry",
                    Localizer.DoStr("Advanced Masonry"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(GeologyResearchPaperAdvancedItem), 20), 
               new IngredientElement(typeof(GeologyResearchPaperModernItem), 10), 
               new IngredientElement(typeof(MetallurgyResearchPaperModernItem), 10), 
               new IngredientElement(typeof(EngineeringResearchPaperModernItem), 10),  
 new IngredientElement("Basic Research", 30), 
 new IngredientElement("Advanced Research", 10),  
                    },
                new CraftingElement<AdvancedMasonrySkillBook>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(10000); 
            this.CraftMinutes = CreateCraftTimeValue(30);

            this.Initialize(Localizer.DoStr("Advanced Masonry Skill Book"), typeof(AdvancedMasonrySkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
