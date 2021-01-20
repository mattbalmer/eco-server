// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
      using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class LumberStockpileObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Lumber Stockpile"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(LumberStockpileItem); } } 



        protected override void Initialize()
        {


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Lumber Stockpile")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class LumberStockpileItem :
        WorldObjectItem<LumberStockpileObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A heavy duty lumber platform that has been reinforced to allow extra storage for large items. ");

        static LumberStockpileItem()
        {
            
        }

        

    }

    [RequiresSkill(typeof(CarpentrySkill), 4)]     
    public partial class LumberStockpileRecipe :
        RecipeFamily
    {
        public LumberStockpileRecipe()
        {
            var product = new Recipe(
                "LumberStockpile",
                Localizer.DoStr("Lumber Stockpile"),
                new IngredientElement[]
                {
               new IngredientElement("Lumber", 15, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
               new IngredientElement("WoodBoard", 10, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                },
               new CraftingElement<LumberStockpileItem>()
            );
            this.Initialize(Localizer.DoStr("Lumber Stockpile"), typeof(LumberStockpileRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 3;  
            this.LaborInCalories = CreateLaborInCaloriesValue(1000, typeof(CarpentrySkill), typeof(LumberStockpileRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(LumberStockpileRecipe), this.UILink(), 8, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Lumber Stockpile"), typeof(LumberStockpileRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}
