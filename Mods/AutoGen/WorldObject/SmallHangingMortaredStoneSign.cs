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
    public partial class SmallHangingMortaredStoneSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Small Hanging Mortared Stone Sign"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Stone; 

        public virtual Type RepresentedItemType { get { return typeof(SmallHangingMortaredStoneSignItem); } } 



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
    [LocDisplayName("Small Hanging Mortared Stone Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    public partial class SmallHangingMortaredStoneSignItem :
        WorldObjectItem<SmallHangingMortaredStoneSignObject> 
        ,IPersistentData 
    {
        public override LocString DisplayDescription => Localizer.DoStr("A small sign for all of your smaller text needs!");

        static SmallHangingMortaredStoneSignItem()
        {
            
        }

        

        [Serialized, TooltipChildren] public object PersistentData { get; set; } 
    }

    [RequiresSkill(typeof(MasonrySkill), 1)]     
    public partial class SmallHangingMortaredStoneSignRecipe :
        RecipeFamily
    {
        public SmallHangingMortaredStoneSignRecipe()
        {
            var product = new Recipe(
                "SmallHangingMortaredStoneSign",
                Localizer.DoStr("Small Hanging Mortared Stone Sign"),
                new IngredientElement[]
                {
               new IngredientElement("MortaredStone", 6, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),    
                },
               new CraftingElement<SmallHangingMortaredStoneSignItem>()
            );
            this.Initialize(Localizer.DoStr("Small Hanging Mortared Stone Sign"), typeof(SmallHangingMortaredStoneSignRecipe));
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(MasonrySkill), typeof(SmallHangingMortaredStoneSignRecipe), this.UILink()); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmallHangingMortaredStoneSignRecipe), this.UILink(), 5, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Small Hanging Mortared Stone Sign"), typeof(SmallHangingMortaredStoneSignRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
}
