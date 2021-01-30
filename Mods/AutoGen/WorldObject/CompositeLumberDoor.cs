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
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class CompositeLumberDoorObject : 
        DoorObject, 
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Composite Lumber Door"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public override Type RepresentedItemType { get { return typeof(CompositeLumberDoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 4; } } 


        protected override void Initialize()
        {
            base.Initialize(); 


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Composite Lumber Door")]
    [Tier(4)]                                      
    [Ecopedia("Housing Objects", "Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class CompositeLumberDoorItem :
        WorldObjectItem<CompositeLumberDoorObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A beautiful composite door built by an expert carpenter.");

        static CompositeLumberDoorItem()
        {
            
        }

        

    }

    [RequiresSkill(typeof(CompositesSkill), 1)]     
    public partial class CompositeLumberDoorRecipe :
        RecipeFamily
    {
        public CompositeLumberDoorRecipe()
        {
            var product = new Recipe(
                "CompositeLumberDoor",
                Localizer.DoStr("Composite Lumber Door"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(ScrewsItem), 4, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),    
               new IngredientElement("CompositeLumber", 2, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),    
                },
               new CraftingElement<CompositeLumberDoorItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 2;  
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(CompositesSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CompositeLumberDoorRecipe), 4, typeof(CompositesSkill), typeof(CompositesFocusedSpeedTalent), typeof(CompositesParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Composite Lumber Door"), typeof(CompositeLumberDoorRecipe));
            CraftingComponent.AddRecipe(typeof(AdvancedCarpentryTableObject), this);
        }
    }
}
