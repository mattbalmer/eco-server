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
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Shared.Math;

    [RequiresSkill(typeof(SmeltingSkill), 1)]   
    [RepairRequiresSkill(typeof(SmeltingSkill), 1)] 
    public partial class IronShovelRecipe :
        RecipeFamily
    {
        public IronShovelRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "IronShovel",
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(IronBarItem), 4, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),   
               new IngredientElement("WoodBoard", 4, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),   
                    },
                new CraftingElement<IronShovelItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronShovelRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Iron Shovel"), typeof(IronShovelRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Iron Shovel")]
    [Tier(2)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class IronShovelItem : ShovelItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(IronShovelItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(17, typeof(SelfImprovementSkill), typeof(IronShovelItem), new IronShovelItem().UILink()));
        private static IDynamicValue tier = new ConstantValue(2);
        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency); 
        

        // Tool overrides

        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 4;
    }
}
