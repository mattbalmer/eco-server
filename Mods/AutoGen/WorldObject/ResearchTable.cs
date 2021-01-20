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
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]                          
    [RequireRoomMaterialTier(0.5f, typeof(CarpentryLavishReqTalent), typeof(CarpentryFrugalReqTalent))]  
    public partial class ResearchTableObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Research Table"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Paper; 

        public virtual Type RepresentedItemType { get { return typeof(ResearchTableItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Research"));                

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Research Table")]
    [Ecopedia("Work Stations", "Researching", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class ResearchTableItem :
        WorldObjectItem<ResearchTableObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A basic table for researching new technologies and skills.");

        static ResearchTableItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    public partial class ResearchTableRecipe :
        RecipeFamily
    {
        public ResearchTableRecipe()
        {
            var product = new Recipe(
                "ResearchTable",
                Localizer.DoStr("Research Table"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(PlantFibersItem), 30),   
               new IngredientElement("Wood", 30), 
               new IngredientElement("Rock", 40),   
                },
               new CraftingElement<ResearchTableItem>()
            );
            this.Initialize(Localizer.DoStr("Research Table"), typeof(ResearchTableRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(250); 
            this.CraftMinutes = CreateCraftTimeValue(5);
            this.Initialize(Localizer.DoStr("Research Table"), typeof(ResearchTableRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}
