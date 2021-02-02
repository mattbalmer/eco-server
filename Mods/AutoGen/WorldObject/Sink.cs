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
    [RequireComponent(typeof(LiquidConverterComponent))]        
    public partial class SinkObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Sink"); } } 

        public override TableTextureMode TableTexture => TableTextureMode.Metal; 

        public virtual Type RepresentedItemType { get { return typeof(SinkItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<HousingComponent>().Set(SinkItem.HousingVal);                               

            this.GetComponent<LiquidConverterComponent>().Setup(typeof(WaterItem), typeof(SewageItem), this.NamedOccupancyOffset("WaterInputPort"), this.NamedOccupancyOffset("SewageOutputPort"), 0.3f, 0.9f); 
        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [LocDisplayName("Sink")]
    [Ecopedia("Housing Objects", "Washroom", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                           
    [Tag("Housing", 1)]
    public partial class SinkItem :
        WorldObjectItem<SinkObject> 
    {
        public override LocString DisplayDescription => Localizer.DoStr("An industrial sink.");

        static SinkItem()
        {
            
        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = RoomCategory.Bathroom,
                                                    Val = 5,                                   
                                                    TypeForRoomLimit = "Sink", 
                                                    DiminishingReturnPercent = 0.2f    
        };}}
        

    }

    [RequiresSkill(typeof(MechanicsSkill), 1)]     
    public partial class SinkRecipe :
        RecipeFamily
    {
        public SinkRecipe()
        {
            var product = new Recipe(
                "Sink",
                Localizer.DoStr("Sink"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(SteelBarItem), 8, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)), 
               new IngredientElement(typeof(IronPlateItem), 8, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),    
                },
               new CraftingElement<SinkItem>()
            );
            this.Recipes = new List<Recipe> { product };
            this.ExperienceOnCraft = 5;  
            this.LaborInCalories = CreateLaborInCaloriesValue(180, typeof(MechanicsSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(SinkRecipe), 8, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));     
            this.Initialize(Localizer.DoStr("Sink"), typeof(SinkRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
}
