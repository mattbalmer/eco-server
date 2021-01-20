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
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(MountComponent))]                  
    public partial class AdornedAshlarLimestoneTableObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Adorned Ashlar Limestone Table"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Stone; 

        public virtual Type RepresentedItemType { get { return typeof(AdornedAshlarLimestoneTableItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(AdornedAshlarLimestoneTableItem.HousingVal);                               
            this.GetComponent<MountComponent>().Initialize(1);                             

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Adorned Ashlar Limestone Table")]
    [Ecopedia("Housing Objects", "Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class AdornedAshlarLimestoneTableItem :
        WorldObjectItem<AdornedAshlarLimestoneTableObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A fancy ashlar stone table that has been adorned with gold");

        static AdornedAshlarLimestoneTableItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 3.5f,                                   
                                                    TypeForRoomLimit = "Table", 
                                                    DiminishingReturnPercent = 0.6f    
        };}}
        

    }

    [RequiresSkill(typeof(AdvancedMasonrySkill), 6)]     
    public partial class AdornedAshlarLimestoneTableRecipe :
        Recipe
    {
        public AdornedAshlarLimestoneTableRecipe()
        {
            var product = new Recipe(
                "AdornedAshlarLimestoneTable",
                Localizer.DoStr("Adorned Ashlar Limestone Table"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(AshlarLimestoneItem), 24, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)), 
               new IngredientElement(typeof(GoldBarItem), 8, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),    
                },
               new CraftingElement<AdornedAshlarLimestoneTableItem>()
            );
            CraftingComponent.AddTagProduct(typeof(AdvancedMasonryTableObject), typeof(AdornedAshlarStoneTableRecipe), product);
        }
    }
}
