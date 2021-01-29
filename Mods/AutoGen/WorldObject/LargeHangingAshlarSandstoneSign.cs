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
    [RequireComponent(typeof(CustomTextComponent))]             
    public partial class LargeHangingAshlarSandstoneSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Hanging Ashlar Sandstone Sign"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Stone; 

        public virtual Type RepresentedItemType { get { return typeof(LargeHangingAshlarSandstoneSignItem); } } 



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
    [LocDisplayName("Large Hanging Ashlar Sandstone Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class LargeHangingAshlarSandstoneSignItem :
        WorldObjectItem<LargeHangingAshlarSandstoneSignObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A large sign for all your large text needs!");

        static LargeHangingAshlarSandstoneSignItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(AdvancedMasonrySkill), 2)]     
    public partial class LargeHangingAshlarSandstoneSignRecipe :
        Recipe
    {
        public LargeHangingAshlarSandstoneSignRecipe()
        {
            var product = new Recipe(
                "LargeHangingAshlarSandstoneSign",
                Localizer.DoStr("Large Hanging Ashlar Sandstone Sign"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(AshlarSandstoneItem), 12, typeof(AdvancedMasonrySkill), typeof(AdvancedMasonryLavishResourcesTalent)),    
                },
               new CraftingElement<LargeHangingAshlarSandstoneSignItem>()
            );
            CraftingComponent.AddTagProduct(typeof(AdvancedMasonryTableObject), typeof(LargeHangingAshlarStoneSignRecipe), product);
        }
    }
}
