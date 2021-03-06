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
    [RequiresSkill(typeof(CarpentrySkill), 1)] 
    public partial class SawSoftwoodBoardsRecipe :
        Recipe
    {
        public SawSoftwoodBoardsRecipe()
        {
            this.Name        = "SawSoftwoodBoards";
            this.DisplayName = Localizer.DoStr("Saw Softwood Boards");
            this.Ingredients = new List<IngredientElement>
            {
                new IngredientElement(typeof(SoftwoodHewnLogItem), 2, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),   
            };
            this.Items = new List<CraftingElement>
            {
                new CraftingElement<SoftwoodBoardItem>(3),
            };
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SawmillObject), typeof(SawBoardsRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
