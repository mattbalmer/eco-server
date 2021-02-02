// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.World;
    using Eco.World.Blocks;

    [Serialized]
    [LocDisplayName("Drill")]
    [Weight(0)]
    [Ecopedia("Items", "Tools")]
    [Category("Hidden")]
    public partial class DrillItem : ToolItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A useful tool for prospecting blocks."); } }

        // Some const values for drilling logic
        public const float TimeForBlockInSeconds = 1f;
        public const float BlockHardnessModifier = 0.5f;

        public virtual float ProspectSpeed => 1f;
        public virtual int DrillDepth => 3;

        public override float InteractDistance  { get { return DefaultInteractDistance.Default; } }

        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(20, typeof(SelfImprovementSkill), typeof(DrillItem), new DrillItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

        public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.None; } }
        public override LocString LeftActionDescription { get { return Localizer.DoStr("Prospect"); } }

        static IDynamicValue tier = new ConstantValue(0);
        public override IDynamicValue Tier { get { return tier; } }

        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override int FullRepairAmount { get { return 1; } }

        public override int MaxTake { get { return 1; } }

        public override bool ShouldHighlight(Type block) => Block.Is<Diggable>(block) || Block.Is<Constructed>(block) || Block.Is<Minable>(block);

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock)
            {
                var prospectResult = AtomicActions.UseToolNow(this.CreateMultiblockContext(context));
                if (prospectResult.Success) context.Player.OpenUI(this.GetProspectData(context), "ProspectingUI");

                return (InteractResult)prospectResult;
            }

            return base.OnActLeft(context);
        }

        public ProspectData GetProspectData(InteractionContext context)
        {
            // On errors, or plant entities we have zero normal, that will broke dig results,
            // we need to replace dir with offset of 1 to start prospect from next block downside
            var rawDirection = context.Normal ?? Vector3i.Zero;
            var direction = rawDirection == Vector3i.Zero ? Vector3i.Up : rawDirection;
            
            // Apply offset for starting pos by 1 in case we have unusual normal values
            var startingPos = context.BlockPosition.Value;
            if (rawDirection == Vector3i.Zero) startingPos -= direction;
            
            var result = new ProspectData(this, direction, this.DrillDepth);
            for (var i = 0; i < this.DrillDepth; i++)
            {
                if (this.CanProspect(context.Player, i + 1))
                {
                    var data = this.ProspectBlock(startingPos - (direction * i));
                    result.Items.Add(data);

                    // if we hit core, no need to drill further, exit
                    if (data.ItemTypeId == -2)
                    {
                        result.MaxBlocksCanProspect = i + 1;
                        break;
                    }
                } else
                {
                    // Clamp max blocks on failed cycle iteration for client-side checks (errors sync)
                    result.MaxBlocksCanProspect = i;
                    break;
                }
            }

            if (result.MaxBlocksCanProspect < 0) result.MaxBlocksCanProspect = this.DrillDepth;

            return result;
        }

        // Parses all required block data to send to client
        private ProspectItemData ProspectBlock(Vector3i position)
        {
            // Unpack block from position, block position won't be null
            var block = World.GetBlock(position);

            // Get resulting item from block
            var typeId = -1;
            if (block is IRepresentsItem item) typeId = Item.Get(item)?.TypeID ?? -1;
            if (typeId == -1)                  typeId = BlockItem.CreatingItem(block.GetType())?.TypeID ?? -1;
            if (World.GetBlock(position).Is<Impenetrable>() || position.y <= 0) typeId = -2;

            // Calculate prospect speed, based on skills, and hardness (gives 0.5s by default)
            var blockProspectSpeed = (block.Get<Minable>()?.Hardness ?? 1 * BlockHardnessModifier) / this.ProspectSpeed;
            
            var res = new ProspectItemData()
            {
                ItemTypeId = typeId,
                Position = position,
                ProspectSeconds = blockProspectSpeed,
            };

            return res;
        }

        // All checks for block availability to prospect
        private bool CanProspect(Player player, int count)
        {
            // Check if calories will allow us to prospect on this depth
            var calories = this.NeededCalories(player, count);
            return !(calories > player.User.Stomach.Calories);
        }
    }
}
