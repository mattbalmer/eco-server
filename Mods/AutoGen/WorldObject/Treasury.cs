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
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(45)]                          
    [RequireRoomMaterialTier(1.8f)]  
    public partial class TreasuryObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Treasury"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(TreasuryItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Economy"));                

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Treasury")]
    [Ecopedia("Work Stations", "Government", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class TreasuryItem :
        WorldObjectItem<TreasuryObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Allows the setting of taxes.");

        static TreasuryItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(SmeltingSkill), 1)]     
    public partial class TreasuryRecipe :
        RecipeFamily
    {
        public TreasuryRecipe()
        {
            var product = new Recipe(
                "Treasury",
                Localizer.DoStr("Treasury"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(BrickItem), 16, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)), 
               new IngredientElement(typeof(GoldBarItem), 12, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),    
               new IngredientElement("Lumber", 60, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),    
                },
               new CraftingElement<TreasuryItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 20;  
            this.LaborInCalories = CreateLaborInCaloriesValue(2500, typeof(SmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(TreasuryRecipe), 25, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Treasury"), typeof(TreasuryRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}
