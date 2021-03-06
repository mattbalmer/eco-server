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
    public partial class ModernScytheRecipe :
        RecipeFamily
    {
        public ModernScytheRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ModernScythe",
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(FiberglassItem), 10, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), 
               new IngredientElement(typeof(SteelBarItem), 15, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),   
                    },
                new CraftingElement<ModernScytheItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill)); 
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernScytheRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Modern Scythe"), typeof(ModernScytheRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Modern Scythe")]
    [Tier(4)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class ModernScytheItem : ScytheItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(ModernScytheItem), typeof(GatheringToolEfficiencyTalent)), CreateCalorieValue(10, typeof(GatheringSkill), typeof(ModernScytheItem), new ModernScytheItem().UILink()));
        private static IDynamicValue exp = new ConstantValue(0.1f);
        private static IDynamicValue tier = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(4), new TalentModifiedValue(typeof(ModernScytheItem), typeof(GatheringToolStrengthTalent), 0));
        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(15, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency); 
        
        private static Vector2i[] areaBlocks = new Vector2i[]
        {
        new Vector2i(-2, 0), 
        new Vector2i(-1, 0), 
        new Vector2i(-1, 1), 
        new Vector2i(0, 1), 
        new Vector2i(1, 0), 
        new Vector2i(1, 1), 
        new Vector2i(2, 0), 
        };

        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A modern scythe used to harvest crops or cut grass. Has a large AoE with each swing.");    
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override Type ExperienceSkill            => typeof(GatheringSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 2000f;
        public override Item RepairItem                 => Item.Get<SteelBarItem>();
        public override int FullRepairAmount            => 15;
        public override Vector2i[] AreaBlocks           => areaBlocks;
    }
}
