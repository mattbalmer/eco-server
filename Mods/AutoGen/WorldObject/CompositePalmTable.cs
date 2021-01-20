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
    public partial class CompositePalmTableObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Composite Palm Table"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public virtual Type RepresentedItemType { get { return typeof(CompositePalmTableItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(CompositePalmTableItem.HousingVal);                               

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Composite Palm Table")]
    [Ecopedia("Housing Objects", "Tables", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class CompositePalmTableItem :
        WorldObjectItem<CompositePalmTableObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A large composite table for eating meals or getting some work done.");

        static CompositePalmTableItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 3,                                   
                                                    TypeForRoomLimit = "Table", 
                                                    DiminishingReturnPercent = 0.6f    
        };}}
        

    }

    [RequiresSkill(typeof(CompositesSkill), 3)]     
    public partial class CompositePalmTableRecipe :
        Recipe
    {
        public CompositePalmTableRecipe()
        {
            var product = new Recipe(
                "CompositePalmTable",
                Localizer.DoStr("Composite Palm Table"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(CompositePalmLumberItem), 6, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)), 
               new IngredientElement(typeof(ScrewsItem), 10, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),    
                },
               new CraftingElement<CompositePalmTableItem>()
            );
            CraftingComponent.AddTagProduct(typeof(AdvancedCarpentryTableObject), typeof(CompositeLumberTableRecipe), product);
        }
    }
}
