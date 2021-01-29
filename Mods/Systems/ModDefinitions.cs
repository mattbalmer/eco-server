// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Housing;
    using Eco.Core.Items;
    using Eco.Core.Plugins.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Housing.Internal;

    public class ModDefinitions : IModInit
    {
        public static void Initialize()
        {   
            //We set a housing-points penalty for multiple people in a property based on the follow table:
            //Number of residents on a property:     0    1    2    3    4     5    6    7    <more>
            HousingCalculation.SetOccupancyPenalties(0f,  0f, .1f, .5f, .75f, .85f, .9f, .95f, .99f);

            //Set the limits for housing points based on each tier of material.  After the 'softcap' is reached, returns are diminised at the percent given, with 'hardcap' being the infinite limit.
            HousingCalculation.SetHousingTiers(new[]
            {
                new HousingTier { TierVal = 0, SoftCap = 2f,  HardCap = 4f,  DiminishingReturnPercent = .5f },
                new HousingTier { TierVal = 1, SoftCap = 5f,  HardCap = 10f, DiminishingReturnPercent = .5f },
                new HousingTier { TierVal = 2, SoftCap = 10f, HardCap = 20f, DiminishingReturnPercent = .5f },
                new HousingTier { TierVal = 3, SoftCap = 15f, HardCap = 30f, DiminishingReturnPercent = .5f },
                new HousingTier { TierVal = 4, SoftCap = 20f, HardCap = 40f, DiminishingReturnPercent = .5f }
            });
        }

        //refactor todo: move out of mods
        public static void PostInitialize()
        {
            var categoryToTags = TagAttribute.CategoryToTags ?? new Dictionary<string, string[]>();
            var tiers = new HashSet<float> { 0 };
            foreach (var item in Item.AllItems)
            {
                if (item.Hidden) continue;
                var itemTier = ItemAttribute.Get<TierAttribute>(item.Type);
                if (itemTier != null)
                    tiers.Add(itemTier.Tier);
            }

            categoryToTags["Tiers"] = tiers.OrderBy(x => x).Select(x => $"Tier {x}").ToArray();
            TagAttribute.CategoryToTags = categoryToTags;
        }
    }
}
