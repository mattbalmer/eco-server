﻿// Copyright (c) Strange Loop Games. All rights reserved.
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
    [RequireComponent(typeof(CustomTextComponent))]             
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class StandingGlassSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Standing Glass Sign"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(StandingGlassSignItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<CustomTextComponent>().Initialize(700);                                       

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Standing Glass Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class StandingGlassSignItem :
        WorldObjectItem<StandingGlassSignObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A large sign framed with a glass plate.");

        static StandingGlassSignItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(GlassworkingSkill), 2)]     
    public partial class StandingGlassSignRecipe :
        RecipeFamily
    {
        public StandingGlassSignRecipe()
        {
            var product = new Recipe(
                "StandingGlassSign",
                Localizer.DoStr("Standing Glass Sign"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(GlassItem), 4, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)), 
               new IngredientElement(typeof(ScrewsItem), 4, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)), 
               new IngredientElement(typeof(SteelBarItem), 2, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),    
               new IngredientElement("WoodBoard", 4, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),    
                },
               new CraftingElement<StandingGlassSignItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(GlassworkingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(StandingGlassSignRecipe), 3, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Standing Glass Sign"), typeof(StandingGlassSignRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}
