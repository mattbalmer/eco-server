// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Items;
    using Eco.Simulation.Agents;

    public partial class NaturalGathererTalent : Talent
    {
        public override void RegisterTalent(User user)
        {
            base.RegisterTalent(user);
            user.Talentset.OnPlantHarvest += this.ApplyModifier;
        }
        public override void UnRegisterTalent(User user)
        {
            base.UnRegisterTalent(user);
            user.Talentset.OnPlantHarvest -= this.ApplyModifier;
        }

        public ItemStack ApplyModifier(Plant plant, ItemStack item, User user)
        {
            var newQuantity = item.Quantity * (plant.Tended ? 1 : this.Value);
            return new ItemStack(item.Item, (int)newQuantity);
        }
    }
}
