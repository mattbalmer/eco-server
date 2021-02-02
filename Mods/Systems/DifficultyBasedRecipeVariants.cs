// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Core.Plugins.Interfaces;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;

    /// <summary> Registers recipe variants for different difficulty settings. </summary>
    public class DifficultyBasedRecipeVariants : IModInit
    {
        public static void PostInitialize()
        {
            // Normal recipe for lower collaboration settings. Uses defaults found in Tech Tree
            RecipeVariant.RegisterDefault<ComputerLabRecipe>(DifficultyConfig.EndgameRecipesNormal);
            RecipeVariant.RegisterDefault<LaserRecipe>(DifficultyConfig.EndgameRecipesNormal);

            // Expensive recipes for higher collaboration settings. All costs are static
            RecipeVariant.Register<ComputerLabRecipe>(DifficultyConfig.EndgameRecipesExpensive, new[]
            {
                new IngredientElement(typeof(AdvancedMasonryUpgradeItem), 1, true),
                new IngredientElement(typeof(CompositesUpgradeItem), 1, true),
                new IngredientElement(typeof(ElectronicsUpgradeItem), 1, true),
                new IngredientElement(typeof(IndustryUpgradeItem), 1, true),
                new IngredientElement(typeof(OilDrillingUpgradeItem), 1, true),
                new IngredientElement(typeof(AdvancedSmeltingUpgradeItem), 1, true),
                new IngredientElement(typeof(AdvancedCircuitItem), 100, true),
                new IngredientElement(typeof(PlasticItem), 100, true),
                new IngredientElement(typeof(ReinforcedConcreteItem), 200, true),
                 new IngredientElement("CompositeLumber", 200, true)

            });
            RecipeVariant.Register<LaserRecipe>(DifficultyConfig.EndgameRecipesExpensive, new[]
            {
                new IngredientElement(typeof(GoldBarItem), 80, true),
                new IngredientElement(typeof(SteelBarItem), 80, true),
                new IngredientElement(typeof(FramedGlassItem), 80, true),
                new IngredientElement(typeof(AdvancedCircuitItem), 40, true),
                new IngredientElement(typeof(ElectricMotorItem), 2, true),
                new IngredientElement(typeof(RadiatorItem), 10, true)
            });
        }
    }
}
