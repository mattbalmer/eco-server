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
    public partial class CampsiteObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Campsite"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Canvas; 

        public virtual Type RepresentedItemType { get { return typeof(CampsiteItem); } } 



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
    [LocDisplayName("Campsite")]
    [Ecopedia("Work Stations", "Craft Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [StartsDiscovered]                                           
    public partial class CampsiteItem :
        WorldObjectItem<CampsiteObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A campsite");

        static CampsiteItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(TailoringSkill), 0)]     
    public partial class CampsiteRecipe :
        RecipeFamily
    {
        public CampsiteRecipe()
        {
            var product = new Recipe(
                "Campsite",
                Localizer.DoStr("Campsite"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(ClothItem), 24, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),    
               new IngredientElement("Wood", 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),    
                },
               new CraftingElement<CampsiteItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 5;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(TailoringSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CampsiteRecipe), 6, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Campsite"), typeof(CampsiteRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}
