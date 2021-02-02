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
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class MortaredSandstoneDoorObject : 
        DoorObject, 
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Mortared Sandstone Door"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Stone; 

        public override Type RepresentedItemType { get { return typeof(MortaredSandstoneDoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 1; } } 


        protected override void Initialize()
        {
            base.Initialize(); 


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Mortared Sandstone Door")]
    [Tier(1)]                                      
    [Ecopedia("Housing Objects", "Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class MortaredSandstoneDoorItem :
        WorldObjectItem<MortaredSandstoneDoorObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A heavy mortared stone door.");

        static MortaredSandstoneDoorItem()
        {
            
        }

        

    }

    [RequiresSkill(typeof(MasonrySkill), 1)]     
    public partial class MortaredSandstoneDoorRecipe :
        Recipe
    {
        public MortaredSandstoneDoorRecipe()
        {
            var product = new Recipe(
                "MortaredSandstoneDoor",
                Localizer.DoStr("Mortared Sandstone Door"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(MortaredSandstoneItem), 6, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),    
                },
               new CraftingElement<MortaredSandstoneDoorItem>()
            );
            CraftingComponent.AddTagProduct(typeof(MasonryTableObject), typeof(MortaredStoneDoorRecipe), product);
        }
    }
}
