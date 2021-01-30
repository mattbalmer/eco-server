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
    using static Eco.Gameplay.Housing.HousingValue;               

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class MortaredGraniteTableObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Mortared Granite Table"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Stone; 

        public virtual Type RepresentedItemType { get { return typeof(MortaredGraniteTableItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(MortaredGraniteTableItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Mortared Granite Table")]
    [Ecopedia("Housing Objects", "Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class MortaredGraniteTableItem :
        WorldObjectItem<MortaredGraniteTableObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("An early stone table. Not much to look at but it does the job.");

        static MortaredGraniteTableItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.General,
                                                    Val = 1,                                   
                                                    TypeForRoomLimit = "Table", 
                                                    DiminishingReturnPercent = 0.6f    
        };}}
        

    }

    [RequiresSkill(typeof(MasonrySkill), 2)]     
    public partial class MortaredGraniteTableRecipe :
        Recipe
    {
        public MortaredGraniteTableRecipe()
        {
            var product = new Recipe(
                "MortaredGraniteTable",
                Localizer.DoStr("Mortared Granite Table"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(MortaredGraniteItem), 22, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),    
                },
               new CraftingElement<MortaredGraniteTableItem>()
            );
            CraftingComponent.AddTagProduct(typeof(MasonryTableObject), typeof(MortaredStoneTableRecipe), product);
        }
    }
}
