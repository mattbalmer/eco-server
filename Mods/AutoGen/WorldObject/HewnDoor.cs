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
    public partial class HewnDoorObject : 
        DoorObject, 
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Hewn Door"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Wood; 

        public override Type RepresentedItemType { get { return typeof(HewnDoorItem); } } 

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
    [LocDisplayName("Hewn Door")]
    [Tier(1)]                                      
    [Ecopedia("Housing Objects", "Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class HewnDoorItem :
        WorldObjectItem<HewnDoorObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A door made from roughly hewn logs.");

        static HewnDoorItem()
        {
            
        }

        

    }

    [RequiresSkill(typeof(CarpentrySkill), 1)]     
    public partial class HewnDoorRecipe :
        RecipeFamily
    {
        public HewnDoorRecipe()
        {
            var product = new Recipe(
                "HewnDoor",
                Localizer.DoStr("Hewn Door"),
                new IngredientElement[]
                {
               new IngredientElement("HewnLog", 6, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),    
                },
               new CraftingElement<HewnDoorItem>()
            );
            this.Initialize(Localizer.DoStr("Hewn Door"), typeof(HewnDoorRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CarpentrySkill), typeof(HewnDoorRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(HewnDoorRecipe), this.UILink(), 1, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Hewn Door"), typeof(HewnDoorRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}
