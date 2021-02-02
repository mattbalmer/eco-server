// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;

// default starting player items / skills
public static class PlayerDefaults
{
    public static Dictionary<Type, int> GetDefaultToolbar()
    {        
        return new Dictionary<Type, int>
        {
        };
    }

    public static Dictionary<Type, int> GetDefaultInventory()
    {
        return new Dictionary<Type, int>
        {
            { typeof(StarterCampItem), 1 },
        };
    }
    
    public static Dictionary<Type, int> GetDefaultCampsiteInventory()
    {
        return new Dictionary<Type, int>
        {
            { typeof(PropertyClaimItem), 6 },
            { typeof(PropertyToolItem), 1 },
            { typeof(StoneAxeItem), 1 },
            { typeof(WoodenShovelItem), 1 },
            { typeof(StoneHammerItem), 1 },
            { typeof(StonePickaxeItem), 1 },
            { typeof(TorchItem), 1 },
            { typeof(TorchStandItem), 1 },
            { typeof(TomatoItem), 20 },
            { typeof(RawFishItem), 20 },
        };
    }
    public static IEnumerable<Type> GetDefaultSpecialties()
    {
        return new Type[]
        {
            typeof(SelfImprovementSkill)
        };
    }

    public static IEnumerable<Type> GetDefaultSkills()
    {
        return new Type[]
        {
            typeof(CarpenterSkill),
            typeof(LoggingSkill),
            typeof(MasonSkill),
            typeof(MiningSkill),
            typeof(ChefSkill),
            typeof(FarmerSkill),
            typeof(GatheringSkill),
            typeof(CampfireCookingSkill),
            typeof(HunterSkill),
            typeof(HuntingSkill),
            typeof(SmithSkill),
            typeof(EngineerSkill),
            typeof(SurvivalistSkill),
            typeof(TailorSkill)
        };
    }

    static Dictionary<UserStatType, IDynamicValue> dynamicValuesDictionary = new Dictionary<UserStatType, IDynamicValue>()
    {
        {
            UserStatType.MaxCalories, new MultiDynamicValue(MultiDynamicOps.Sum,
                new MultiDynamicValue(MultiDynamicOps.Multiply,
                    CreateSmv(0f,  new BonusUnitsDecoratorStrategy(SelfImprovementSkill.AdditiveStrategy, "cal", (float val) => val/2f), typeof(SelfImprovementSkill), Localizer.DoStr("stomach capacity"), DynamicValueType.Misc),
                    new ConstantValue(0.5f)),
                new ConstantValue(3000))
        },
        {
            UserStatType.MaxCarryWeight, new MultiDynamicValue(MultiDynamicOps.Sum,
                CreateSmv(0f, new BonusUnitsDecoratorStrategy(SelfImprovementSkill.AdditiveStrategy, "kg", (float val) => val/1000f), typeof(SelfImprovementSkill), Localizer.DoStr("carry weight"), DynamicValueType.Misc),
                new ConstantValue(ToolbarBackpackInventory.DefaultWeightLimit))
        },
        {
            UserStatType.CalorieRate, new MultiDynamicValue(MultiDynamicOps.Sum,
                //CreateSmv(1f, SelfImprovementSkill.MultiplicativeStrategy, typeof(SelfImprovementSkill), Localizer.DoStr("calorie cost"), typeof(Calorie)),
                new ConstantValue(1))
        },
        {
            UserStatType.DetectionRange, new MultiDynamicValue(MultiDynamicOps.Sum,
                CreateSmv(0f, HuntingSkill.AdditiveStrategy, typeof(HuntingSkill), Localizer.DoStr("how close you can approach animals"), DynamicValueType.Misc),
                new ConstantValue(0))
        },
        {
            UserStatType.MovementSpeed, new MultiDynamicValue(MultiDynamicOps.Sum,
                new TalentModifiedValue(typeof(UserStatType), typeof(NatureAdventurerTalent), 0),
                new TalentModifiedValue(typeof(UserStatType), typeof(UrbanTravellerTalent), 0))
        }
    };

    private static SkillModifiedValue CreateSmv(float startValue, ModificationStrategy strategy, Type skillType, LocString benefitsDescription, DynamicValueType valueType)
    {
        var smv = new SkillModifiedValue(startValue, strategy, skillType, benefitsDescription, valueType);
        SkillModifiedValueManager.AddSkillBenefit(skillType, Localizer.DoStr("You"), smv);
        return smv;
    }

    public static Dictionary<UserStatType, IDynamicValue> GetDefaultDynamicValues()
    {
        return dynamicValuesDictionary;
    }

    public static IEnumerable<Type> GetDefaultBodyparts()
    {
        return new Type[]
        {
            typeof(RoundedFaceItem),
            typeof(BlinkyEyelidsItem),
            typeof(FitTorsoItem),
            typeof(HumanLimbsItem),
            typeof(WideHipsItem),
        };
    }

    public static IEnumerable<Type> GetDefaultClothing()
    {
        return new Type[]
        {
            typeof(BasicBackpackItem),
            typeof(TrousersItem),
            typeof(HenleyItem),
            typeof(NormalHairItem),
            typeof(TallBootsItem),
            typeof(SquareBeltItem),
        };
    }
}
