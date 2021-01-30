// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Players;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Eco.Gameplay.Items.Actionbar;
    using Eco.Shared.Utils;
    using System.IO;
    using Eco.Core.Tests;
    using Eco.Mods.TechTree;
    using Eco.Simulation;
    using Eco.Simulation.Types;
    using Eco.Shared.Localization;
    using Eco.Shared.Text;

    public class TechTreeSimData
    {
        public List<Type>   CurSkills  = new List<Type>();
        public List<Recipe> CurRecipes = new List<Recipe>();

        public List<Recipe>  UnusableRecipes  = new List<Recipe>();
        public HashSet<Type> CraftableItems   = new HashSet<Type>();
        public HashSet<Tag>  CraftableTags    = new HashSet<Tag>();
        public List<Type>    CraftingTables   = new List<Type>();
        public Queue<Type>   SkillsToEvaluate = new Queue<Type>();

        public void AddSkill(Type skill)
        {
            if ((Item.Get(skill) as Skill).IsSpecialty && !(Item.Get(skill) as Skill).IsRoot)
            {
                this.SkillsToEvaluate.Enqueue(skill);
                foreach (var tree in SkillTree.SpecialtyTreeFromSkill(skill).ChildrenRecursive())
                    this.SkillsToEvaluate.Enqueue(tree.StaticSkill.Type);
            }
        }

        public bool HasIngredient(IngredientElement element) => element.IsSpecificItem ? this.CraftableItems.Contains(element.Item.Type) : this.CraftableTags.Contains(element.Tag);

        public void AddItem(Type itemType)
        {
            this.CraftableItems.Add(itemType);
            this.CraftableTags.AddRange(Item.Get(itemType).Tags());
        }

        public void AddItems(IEnumerable<Type> itemTypes)
        {
            foreach (var itemType in itemTypes)
                this.AddItem(itemType);
        }
    }

    public class TechTreeSim : IChatCommandHandler
    {
        [CITest]
        [ChatSubCommand("Craft", "Simulates the tech tree", ChatAuthorizationLevel.Developer)]
        public static void TechTreeSimulation(User user)
        {
            var info = new InfoBuilder();
            var data = new TechTreeSimData();
            info.AppendLineLocStr("Starting Tech Tree Sim");

            info.AppendLineLocStr("Getting Starting Skills...");
            var introSkills = PlayerDefaults.GetDefaultSkills().ToList();
            introSkills.ForEach(x => data.AddSkill(x));

            info.AppendLineLocStr("Getting Initial Tables...");
            data.CraftingTables.Add(typeof(CampsiteObject));

            info.AppendLineLocStr("Getting Recipes with No Skills...");
            data.UnusableRecipes.AddRange(RecipeFamily.AllRecipes.SelectMany(x => x.Recipes).Where(x => !x.Family.RequiredSkills.Any() && x.Ingredients.Any()));

            info.AppendLineLocStr("Getting World Resources...");
            //manually defined for now since theres no easy way of checking for these
            data.AddItems(new List<Type>
            {
                typeof(DirtItem),
                typeof(SandItem),
                typeof(IronOreItem),
                typeof(CopperOreItem),
                typeof(GoldOreItem),
                typeof(CoalItem),
                typeof(ClayItem)
            });

            // Add all items with "Rock" tag
            data.AddItems(TagManager.TagToTypes[TagManager.Tag("Rock")]);

            info.AppendLineLocStr("Getting Species Resources...");
            var resourceless = new List<Species>();
            EcoSim.AllSpecies.ForEach(x =>
            {
                var speciesInfo = new InfoBuilder();
                AddNewResources(speciesInfo, x.ResourceList.Select(x => x.ResourceType), data);
                if (x is TreeSpecies treeSpecies)
                {
                    AddNewResources(speciesInfo, treeSpecies.TrunkResources.Keys, data);
                    AddNewResources(speciesInfo, treeSpecies.DebrisResources.Keys, data);
                }

                if (speciesInfo.IsEmpty)
                {
                    resourceless.Add(x);
                    speciesInfo.AppendLineLocStr("No resources");
                }

                info.AddSectionLoc($"Adding Species: {x.DisplayName}", speciesInfo);
            });
            
            info.AppendLine();
            info.AppendLineLocStr("Simulating...");
            info.AppendLine();

            UpdateRecipes(info, data);
            UpdateRecipesFromSkills(info, data);
            info.AppendLine();
            info.AppendLineLocStr("Tech Tree Sim Complete");
            ChatManager.SendChat(CheckStatus(info, data) ? "Tech Tree Complete" : "Tech Tree Failed, check the TechTreeSimulation.txt for more information.", user); //get issues with complete

            //PLANT DATA
            info.AppendLineLocStr("Plants Missing Resources");
            info.AppendLine(Localizer.NotLocalizedStr(string.Join(",", resourceless)));

            //CRAFTABLES
            var uncraftableAccessed = new InfoBuilder();
            foreach(var recipe in data.UnusableRecipes)
            {
                var recipeInfo = new InfoBuilder();
                ReportMissingIngredients(recipeInfo, recipe, data);

                if (!CraftingComponent.TablesForRecipe(recipe.Family.GetType()).Intersect(data.CraftingTables).Any())
                    recipeInfo.AppendLineLocStr("- missing crafting table");
                uncraftableAccessed.AddSection(recipe.DisplayName, recipeInfo);
            }
            info.AppendLine();
            info.AddSectionLocStr("Uncraftable Accessed", uncraftableAccessed);

            var uncraftableUnaccessed = new InfoBuilder();
            foreach (var recipe in RecipeFamily.AllRecipes.SelectMany(x => x.Recipes).Except(data.CurRecipes))
            {
                var recipeInfo  = new InfoBuilder();
                var missingSkillsInfo = new InfoBuilder();
                foreach (var skill in recipe.Family.RequiredSkills)
                {
                    if (!data.CurSkills.Contains(skill.SkillType))
                        missingSkillsInfo.AppendLine(skill.SkillItem.DisplayName);
                }
                recipeInfo.AddSectionLocStr("- missing skills:", missingSkillsInfo);

                ReportMissingIngredients(recipeInfo, recipe, data);

                // notify about missing crafting table
                if (!CraftingComponent.TablesForRecipe(recipe.Family.GetType()).Intersect(data.CraftingTables).Any())
                    recipeInfo.AppendLineLocStr("- missing crafting table");

                uncraftableUnaccessed.AddSection(recipe.DisplayName, recipeInfo);
            }
            info.AppendLine();
            info.AddSectionLocStr("Uncraftable Unaccessed", uncraftableUnaccessed);

            //ALL UNOBTAINABLE ITEMS
            info.AppendLine();
            info.AppendLineLocStr("Unobtainable Items");
            foreach (var item in Item.AllItems
                .Where(x => !(x is Skill) && !(x is ActionbarItem) && !(x is SkillScroll) && !x.Hidden)
                .Select(x => x.Type)
                .Except(data.CraftableItems))
                info.AppendLineLocStr("  " + item.Name);

            using var sw = new StreamWriter("TechTreeSimulation.txt");
            sw.Write(info.ToLocString());
        }

        private static void AddNewResources(InfoBuilder info, IEnumerable<Type> itemTypes, TechTreeSimData data)
        {
            foreach(var itemType in itemTypes)
            {
                data.AddItem(itemType);
                info.AppendLineLoc($" - New Resource: {Item.Get(itemType).DisplayName}");
            }
        }

        private static void ReportMissingIngredients(InfoBuilder recipeFamilyInfo, Recipe recipe, TechTreeSimData data)
        {
            var missingIngredientsInfo = new InfoBuilder();
            foreach (var ingredient in recipe.Ingredients)
            {
                if (!data.HasIngredient(ingredient))
                    missingIngredientsInfo.AppendLine(ingredient.StackObject.DisplayName);
            }
            recipeFamilyInfo.AddSectionLocStr("- missing ingredients:", missingIngredientsInfo);
        }

        private static bool CheckStatus(InfoBuilder info, TechTreeSimData data)
        {
            var s = new LocStringBuilder();
            if (!data.CraftingTables.Contains(typeof(LaserObject)))
                s.AppendLineLocStr("Error: Laser Unobtainable");
            if(data.UnusableRecipes.Any())
                s.AppendLineLocStr("Error: Visible Recipes Uncraftable");
            info.AppendLine(s.ToLocString());
            return s.ToLocString().Length <= 0;
        }

        private static void UpdateRecipesFromSkills(InfoBuilder info, TechTreeSimData data)
        {
            while (data.SkillsToEvaluate.Any())
            {
                var skill = data.SkillsToEvaluate.Dequeue();
                data.CurSkills.Add(skill);
                info.AppendLineLocStr("Adding Skill: " + skill.Name);
                foreach (var recipe in RecipeFamily.GetRecipesBySkill(skill))
                    data.UnusableRecipes.AddRange(recipe.Recipes);
                UpdateRecipes(info, data);
            }
        }

        private static void UpdateRecipes(InfoBuilder info, TechTreeSimData data)
        {
            var numRemoved = 1;
            while(numRemoved != 0)
            {
                numRemoved = 0;
                var toRemove = new List<Recipe>();
                foreach(var recipe in data.UnusableRecipes)
                {
                    if (data.CraftableItems.ContainsAll(recipe.Items.Select(x => x.Item.Type)))
                        toRemove.Add(recipe);
                    else if (recipe.Ingredients.All(data.HasIngredient) &&
                             CraftingComponent.TablesForRecipe(recipe.Family.GetType()).Intersect(data.CraftingTables).Any())
                    {
                        foreach(var product in recipe.Items.Select(x => x.Item))
                        {
                            data.AddItem(product.Type);
                            info.AppendLineLocStr(" - New Craftable Items: " + product);
                            if (product is WorldObjectItem)
                                data.CraftingTables.AddUnique((product as WorldObjectItem).WorldObjectType); //will need to specify power items
                            if (product is SkillBook)
                                data.AddSkill((product as SkillBook).Skill.Type);
                        }
                        toRemove.Add(recipe);
                        numRemoved++;
                    }
                }
                toRemove.ForEach(x =>
                {
                    data.UnusableRecipes.Remove(x);
                    data.CurRecipes.Add(x);
                });
            }
        }
    }
}
