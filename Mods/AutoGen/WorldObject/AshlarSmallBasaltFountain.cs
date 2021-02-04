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
    using static Eco.Gameplay.Housing.HousingValue;               

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]                  
    [RequireComponent(typeof(SolidGroundComponent))]            
    [RequireComponent(typeof(MountComponent))]                  
    public partial class AshlarSmallBasaltFountainObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Ashlar Small Basalt Fountain"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Stone; 

        public virtual Type RepresentedItemType { get { return typeof(AshlarSmallBasaltFountainItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(AshlarSmallBasaltFountainItem.HousingVal);                               
            this.GetComponent<MountComponent>().Initialize(1);                             

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Ashlar Small Basalt Fountain")]
    [Ecopedia("Housing Objects", "Decoration", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class AshlarSmallBasaltFountainItem :
        WorldObjectItem<AshlarSmallBasaltFountainObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A beautiful ashlar stone fountain with flowing water that makes a great centerpiece. Small enough to fit indoors.");

        static AshlarSmallBasaltFountainItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.General,
                                                    Val = 1.5f,                                   
                                                    TypeForRoomLimit = "Fountain", 
                                                    DiminishingReturnPercent = 0.1f    
        };}}
        

    }

    [RequiresSkill(typeof(AdvancedMasonrySkill), 2)]     
    public partial class AshlarSmallBasaltFountainRecipe :
        Recipe
    {
        public AshlarSmallBasaltFountainRecipe()
        {
            var product = new Recipe(
                "AshlarSmallBasaltFountain",
                Localizer.DoStr("Ashlar Small Basalt Fountain"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(AshlarBasaltItem), 10, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),    
                },
               new CraftingElement<AshlarSmallBasaltFountainItem>()
            );
            CraftingComponent.AddTagProduct(typeof(AdvancedMasonryTableObject), typeof(AshlarSmallStoneFountainRecipe), product);
        }
    }
}
