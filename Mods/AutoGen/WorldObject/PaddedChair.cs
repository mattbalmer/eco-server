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
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(MountComponent))]                  
    public partial class PaddedChairObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Padded Chair"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(PaddedChairItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(PaddedChairItem.HousingVal);                               
            this.GetComponent<MountComponent>().Initialize(1);                             

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Padded Chair")]
    [Ecopedia("Housing Objects", "Seating", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class PaddedChairItem :
        WorldObjectItem<PaddedChairObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A comfy chair to rest in.");

        static PaddedChairItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1.5f,                                   
                                                    TypeForRoomLimit = "Seating", 
                                                    DiminishingReturnPercent = 0.8f    
        };}}
        

    }

    [RequiresSkill(typeof(TailoringSkill), 1)]     
    public partial class PaddedChairRecipe :
        RecipeFamily
    {
        public PaddedChairRecipe()
        {
            var product = new Recipe(
                "PaddedChair",
                Localizer.DoStr("Padded Chair"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(ClothItem), 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),    
               new IngredientElement("HewnLog", 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), 
               new IngredientElement("WoodBoard", 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),    
                },
               new CraftingElement<PaddedChairItem>()
            );
            this.Initialize(Localizer.DoStr("Padded Chair"), typeof(PaddedChairRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 4;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(TailoringSkill), typeof(PaddedChairRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaddedChairRecipe), this.UILink(), 8, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Padded Chair"), typeof(PaddedChairRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}
