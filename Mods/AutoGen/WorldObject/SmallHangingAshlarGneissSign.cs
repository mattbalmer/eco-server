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
    [RequireComponent(typeof(CustomTextComponent))]             
    public partial class SmallHangingAshlarGneissSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Small Hanging Ashlar Gneiss Sign"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Stone; 

        public virtual Type RepresentedItemType { get { return typeof(SmallHangingAshlarGneissSignItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<CustomTextComponent>().Initialize(700);                                       

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Small Hanging Ashlar Gneiss Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class SmallHangingAshlarGneissSignItem :
        WorldObjectItem<SmallHangingAshlarGneissSignObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A small sign for all of your smaller text needs!");

        static SmallHangingAshlarGneissSignItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(AdvancedMasonrySkill), 1)]     
    public partial class SmallHangingAshlarGneissSignRecipe :
        Recipe
    {
        public SmallHangingAshlarGneissSignRecipe()
        {
            var product = new Recipe(
                "SmallHangingAshlarGneissSign",
                Localizer.DoStr("Small Hanging Ashlar Gneiss Sign"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(AshlarGneissItem), 8, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),    
                },
               new CraftingElement<SmallHangingAshlarGneissSignItem>()
            );
            CraftingComponent.AddTagProduct(typeof(AdvancedMasonryTableObject), typeof(SmallHangingAshlarStoneSignRecipe), product);
        }
    }
}
