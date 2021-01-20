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
    public partial class CompositeCeibaDoorObject : 
        DoorObject, 
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Composite Ceiba Door"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public override Type RepresentedItemType { get { return typeof(CompositeCeibaDoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 4; } } 


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
    [LocDisplayName("Composite Ceiba Door")]
    [Tier(4)]                                      
    [Ecopedia("Housing Objects", "Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class CompositeCeibaDoorItem :
        WorldObjectItem<CompositeCeibaDoorObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A beautiful composite door built by an expert carpenter.");

        static CompositeCeibaDoorItem()
        {
            
        }

        

    }

    [RequiresSkill(typeof(CompositesSkill), 1)]     
    public partial class CompositeCeibaDoorRecipe :
        Recipe
    {
        public CompositeCeibaDoorRecipe()
        {
            var product = new Recipe(
                "CompositeCeibaDoor",
                Localizer.DoStr("Composite Ceiba Door"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(CompositeCeibaLumberItem), 2, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)), 
               new IngredientElement(typeof(ScrewsItem), 4, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),    
                },
               new CraftingElement<CompositeCeibaDoorItem>()
            );
            CraftingComponent.AddTagProduct(typeof(AdvancedCarpentryTableObject), typeof(CompositeLumberDoorRecipe), product);
        }
    }
}
