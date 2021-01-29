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
    public partial class HangingLongSteelSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Hanging Long Steel Sign"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(HangingLongSteelSignItem); } } 



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
    [LocDisplayName("Hanging Long Steel Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class HangingLongSteelSignItem :
        WorldObjectItem<HangingLongSteelSignObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A long steel plate for when you need to display extra large text.");

        static HangingLongSteelSignItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]     
    public partial class HangingLongSteelSignRecipe :
        RecipeFamily
    {
        public HangingLongSteelSignRecipe()
        {
            var product = new Recipe(
                "HangingLongSteelSign",
                Localizer.DoStr("Hanging Long Steel Sign"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelPlateItem), 8, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), 
               new IngredientElement(typeof(RivetItem), 8, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),    
               new IngredientElement("WoodBoard", 2, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),    
                },
               new CraftingElement<HangingLongSteelSignItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(200, typeof(AdvancedSmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(HangingLongSteelSignRecipe), 3, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Hanging Long Steel Sign"), typeof(HangingLongSteelSignRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}