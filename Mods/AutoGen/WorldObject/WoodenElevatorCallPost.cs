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
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class WoodenElevatorCallPostObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Wooden Elevator Call Post"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(WoodenElevatorCallPostItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Misc"));                

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Wooden Elevator Call Post")]
    [Ecopedia("Crafted Objects", "Specialty", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class WoodenElevatorCallPostItem :
        WorldObjectItem<WoodenElevatorCallPostObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Used to call a nearby WoodenElevator.");

        static WoodenElevatorCallPostItem()
        {
            
        }

        

    }

    [RequiresSkill(typeof(CarpentrySkill), 5)]     
    public partial class WoodenElevatorCallPostRecipe :
        RecipeFamily
    {
        public WoodenElevatorCallPostRecipe()
        {
            var product = new Recipe(
                "WoodenElevatorCallPost",
                Localizer.DoStr("Wooden Elevator Call Post"),
                new IngredientElement[]
                {
               new IngredientElement("Lumber", 8, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), 
               new IngredientElement("WoodBoard", 6, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                },
               new CraftingElement<WoodenElevatorCallPostItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 2;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(CarpentrySkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodenElevatorCallPostRecipe), 5, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Wooden Elevator Call Post"), typeof(WoodenElevatorCallPostRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}
