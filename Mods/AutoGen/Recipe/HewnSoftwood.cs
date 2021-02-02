// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
        using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [RequiresSkill(typeof(LoggingSkill), 1)] 
    public partial class HewnSoftwoodRecipe :
        Recipe
    {
        public HewnSoftwoodRecipe()
        {
            this.Name        = "HewnSoftwood";
            this.DisplayName = Localizer.DoStr("Hewn Softwood");
            this.Ingredients = new List<IngredientElement>
            {
                new IngredientElement("Softwood", 2, typeof(LoggingSkill)),   
            };
            this.Items = new List<CraftingElement>
            {
                new CraftingElement<SoftwoodHewnLogItem>(1),
            };
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(CarpentryTableObject), typeof(HewnLogsRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
