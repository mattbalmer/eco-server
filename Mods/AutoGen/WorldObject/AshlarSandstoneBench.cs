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
    [RequireComponent(typeof(MountComponent))]                  
    public partial class AshlarSandstoneBenchObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Ashlar Sandstone Bench"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Stone; 

        public virtual Type RepresentedItemType { get { return typeof(AshlarSandstoneBenchItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(AshlarSandstoneBenchItem.HousingVal);                               
            this.GetComponent<MountComponent>().Initialize(1);                             

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Ashlar Sandstone Bench")]
    [Ecopedia("Housing Objects", "Seating", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class AshlarSandstoneBenchItem :
        WorldObjectItem<AshlarSandstoneBenchObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("An ashlar stone bench. Great for display  though maybe not as comfy as a padded couch.");

        static AshlarSandstoneBenchItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.General,
                                                    Val = 2.5f,                                   
                                                    TypeForRoomLimit = "Seating", 
                                                    DiminishingReturnPercent = 0.5f    
        };}}
        

    }

    [RequiresSkill(typeof(AdvancedMasonrySkill), 4)]     
    public partial class AshlarSandstoneBenchRecipe :
        Recipe
    {
        public AshlarSandstoneBenchRecipe()
        {
            var product = new Recipe(
                "AshlarSandstoneBench",
                Localizer.DoStr("Ashlar Sandstone Bench"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(AshlarSandstoneItem), 12, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),    
                },
               new CraftingElement<AshlarSandstoneBenchItem>()
            );
            CraftingComponent.AddTagProduct(typeof(AdvancedMasonryTableObject), typeof(AshlarStoneBenchRecipe), product);
        }
    }
}
