// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.Linq;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Items.SearchAndSelect;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Serialization;
    using Eco.Gameplay.DynamicValues;
    using Eco.Shared.Localization;
    using Eco.Gameplay.UI;

    public partial class EckoTheDolphinItem : ToolItem
    {
        [Serialized]
        private string wantedItem = string.Empty;
        private static readonly IDynamicValue SkilledRepairCostValue = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return SkilledRepairCostValue; } }
        public override InteractResult OnActRight(InteractionContext context)
        {
            if (string.IsNullOrEmpty(this.wantedItem))
                this.wantedItem = DiscoveryManager.Obj.GetRandomDiscoveredNotCarriedItem().DisplayName;

            var itemStack = context.Player.User.Inventory.NonEmptyStacks.Where(stack => stack.Item.DisplayName == this.wantedItem).FirstOrDefault();
            if (itemStack != null)
            {
                var gift = AllItems.Where(x => !(x is Skill) && x.Group != "Actionbar Items").Shuffle().First();
                var result = context.Player.User.Inventory.TryModify(changeSet =>
                {
                    changeSet.RemoveItem(itemStack.Item.Type);
                    changeSet.AddItem(gift.Type);
                }, context.Player.User);

                if (result.Success)
                {                    
                    context.Player.Msg(Localizer.Format("Ecko accepts your tribute of {0:wanted} and grants you {1:given} for your devotion.", this.wantedItem, gift.DisplayName));
                    this.wantedItem = DiscoveryManager.Obj.GetRandomDiscoveredNotCarriedItem().DisplayName;
                }
            }
            else
                context.Player.Msg(Localizer.Format("Ecko demands {0}!", this.wantedItem));

            return base.OnActLeft(context);
        }
    }
}
