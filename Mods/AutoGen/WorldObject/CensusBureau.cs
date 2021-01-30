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
    [RequireRoomMaterialTier(1)]  
    public partial class CensusBureauObject : 
        CivicObject, 
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Census Bureau"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Paper; 

        public virtual Type RepresentedItemType { get { return typeof(CensusBureauItem); } } 



        protected override void Initialize()
        {
            base.Initialize(); 

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Civics"));                

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Census Bureau")]
    [Ecopedia("Work Stations", "Government", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class CensusBureauItem :
        WorldObjectItem<CensusBureauObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("Demographics are created here using data about the population.");

        static CensusBureauItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    public partial class CensusBureauRecipe :
        RecipeFamily
    {
        public CensusBureauRecipe()
        {
            var product = new Recipe(
                "CensusBureau",
                Localizer.DoStr("Census Bureau"),
                new IngredientElement[]
                {
               new IngredientElement("HewnLog", 30), 
               new IngredientElement("MortaredStone", 30),   
                },
               new CraftingElement<CensusBureauItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(2000); 
            this.CraftMinutes = CreateCraftTimeValue(5);
            this.Initialize(Localizer.DoStr("Census Bureau"), typeof(CensusBureauRecipe));
            CraftingComponent.AddRecipe(typeof(CapitolObject), this);
        }
    }
}
