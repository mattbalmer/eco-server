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
    public partial class HangingSteelFramedSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Hanging Steel Framed Sign"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(HangingSteelFramedSignItem); } } 



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
    [LocDisplayName("Hanging Steel Framed Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class HangingSteelFramedSignItem :
        WorldObjectItem<HangingSteelFramedSignObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A large wooden sign framed with steel.");

        static HangingSteelFramedSignItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]     
    public partial class HangingSteelFramedSignRecipe :
        RecipeFamily
    {
        public HangingSteelFramedSignRecipe()
        {
            var product = new Recipe(
                "HangingSteelFramedSign",
                Localizer.DoStr("Hanging Steel Framed Sign"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelBarItem), 2, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), 
               new IngredientElement(typeof(RivetItem), 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),    
               new IngredientElement("WoodBoard", 6, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),    
                },
               new CraftingElement<HangingSteelFramedSignItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(AdvancedSmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(HangingSteelFramedSignRecipe), 3, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Hanging Steel Framed Sign"), typeof(HangingSteelFramedSignRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}
