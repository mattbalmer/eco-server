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

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 2)]   
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 2)] 
    public partial class CompositeBowRecipe :
        RecipeFamily
    {
        public CompositeBowRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "CompositeBow",
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(FiberglassItem), 10, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), 
               new IngredientElement(typeof(SteelBarItem), 15, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),   
                    },
                new CraftingElement<CompositeBowItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(CompositeBowRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Composite Bow"), typeof(CompositeBowRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Composite Bow")]
    [Tier(4)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class CompositeBowItem : BowItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(CompositeBowItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(10, typeof(HuntingSkill), typeof(CompositeBowItem), new CompositeBowItem().UILink()));
        private static IDynamicValue damage = CreateDamageValue(1.5f, typeof(HuntingSkill), typeof(CompositeBowItem), new CompositeBowItem().UILink()); 
        private static IDynamicValue exp = new ConstantValue(1);
        private static IDynamicValue tier = new ConstantValue(4);
        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(15, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency); 
        

        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A modern composite bow made with fiberglass that makes hunting a breeze. Requires arrows to fire.");    
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override IDynamicValue Damage            => damage; 
        public override Type ExperienceSkill            => typeof(HuntingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 2000f;
        public override Item RepairItem                 => Item.Get<SteelBarItem>();
        public override int FullRepairAmount            => 15;
    }
}
