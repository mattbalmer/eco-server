// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Core.Items;
using Eco.Gameplay.GameActions;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.World;
using Eco.World.Blocks;

namespace Eco.Mods.TechTree
{
    [Road(1.2f)] 
    public partial class StoneRoadItem { }

    [Road(1.4f), ConstructWithoutTool(false)] //Asphalt, unlike stone road and dirt road, DOES need a hammer to place, so undo the [ConstructWithoutTool] value set by parents.
    public partial class AsphaltConcreteItem { } 
}

[Serialized]
public abstract class BaseRampObject : WorldObject
{
    // No UI
    public override InteractResult OnActInteract(InteractionContext context)
    {
        return InteractResult.NoOp;
    }
}

[Serialized]
public class DirtRampObject : BaseRampObject
{
    public override LocString DisplayName { get { return Localizer.DoStr("Dirt Ramp"); } }

    private DirtRampObject() { }
}

[Serialized]
[LocDisplayName("Dirt Ramp")]
[ItemGroup("Road Items")]
[Tag("Road")]
[Tag("Constructable")]
[Ecopedia("Blocks", "Roads", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
[Weight(60000)]
public class DirtRampItem : RampItem<DirtRampObject>
{
    public override LocString DisplayDescription  { get { return Localizer.DoStr("4 x 1 Dirt Ramp."); } }

    public override Dictionary<Vector3i, Type[]> BlockTypes { get { return new Dictionary<Vector3i, Type[]>
    {
        {Vector3i.Left,    new[] { typeof(DirtRampABlock), typeof(DirtRampBBlock), typeof(DirtRampCBlock), typeof(DirtRampDBlock) }},
        {Vector3i.Forward, new[] { typeof(DirtRampA90Block), typeof(DirtRampB90Block), typeof(DirtRampC90Block), typeof(DirtRampD90Block) }},
        {Vector3i.Right,   new[] { typeof(DirtRampA180Block), typeof(DirtRampB180Block), typeof(DirtRampC180Block), typeof(DirtRampD180Block) }},
        {Vector3i.Back,    new[] { typeof(DirtRampA270Block), typeof(DirtRampB270Block), typeof(DirtRampC270Block), typeof(DirtRampD270Block) }},
    };}}
}

[Serialized]
public class StoneRampObject : BaseRampObject
{
    public override LocString DisplayName { get { return Localizer.DoStr("Stone Ramp"); } }

    private StoneRampObject() { }
}

[Serialized]
[LocDisplayName("Stone Ramp")]
[ItemGroup("Road Items")]
[Tag("Road")]
[Tag("Constructable")]
[Ecopedia("Blocks", "Roads", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
[Weight(60000)]
public class StoneRampItem : RampItem<StoneRampObject>
{
    public override LocString DisplayDescription  { get { return Localizer.DoStr("4 x 1 Stone Ramp."); } }

    public override Dictionary<Vector3i, Type[]> BlockTypes { get { return new Dictionary<Vector3i, Type[]>
    {
        {Vector3i.Left,    new[] { typeof(StoneRampABlock), typeof(StoneRampBBlock), typeof(StoneRampCBlock), typeof(StoneRampDBlock) }},
        {Vector3i.Forward, new[] { typeof(StoneRampA90Block), typeof(StoneRampB90Block), typeof(StoneRampC90Block), typeof(StoneRampD90Block) }},
        {Vector3i.Right,   new[] { typeof(StoneRampA180Block), typeof(StoneRampB180Block), typeof(StoneRampC180Block), typeof(StoneRampD180Block) }},
        {Vector3i.Back,    new[] { typeof(StoneRampA270Block), typeof(StoneRampB270Block), typeof(StoneRampC270Block), typeof(StoneRampD270Block) }},
    };}}
}

[Serialized]
public class AsphaltConcreteRampObject : BaseRampObject
{
    public override LocString DisplayName => Localizer.DoStr("Asphalt Concrete Ramp");

    private AsphaltConcreteRampObject() { }
}

[Serialized]
[LocDisplayName("Asphalt Concrete Ramp")]
[ItemGroup("Road Items")]
[Tag("Road")]
[Tag("Constructable")]
[Category("Hidden")]
[Weight(60000)]
public class AsphaltConcreteRampItem : RampItem<AsphaltConcreteRampObject>
{
    public override LocString DisplayDescription => Localizer.DoStr("4 x 1 Asphalt Concrete Ramp.");

    public override Dictionary<Vector3i, Type[]> BlockTypes { get { return new Dictionary<Vector3i, Type[]>
    {
        {Vector3i.Left,    new[] { typeof(AsphaltConcreteRampABlock),    typeof(AsphaltConcreteRampBBlock),    typeof(AsphaltConcreteRampCBlock),    typeof(AsphaltConcreteRampDBlock)    }},
        {Vector3i.Forward, new[] { typeof(AsphaltConcreteRampA90Block),  typeof(AsphaltConcreteRampB90Block),  typeof(AsphaltConcreteRampC90Block),  typeof(AsphaltConcreteRampD90Block)  }},
        {Vector3i.Right,   new[] { typeof(AsphaltConcreteRampA180Block), typeof(AsphaltConcreteRampB180Block), typeof(AsphaltConcreteRampC180Block), typeof(AsphaltConcreteRampD180Block) }},
        {Vector3i.Back,    new[] { typeof(AsphaltConcreteRampA270Block), typeof(AsphaltConcreteRampB270Block), typeof(AsphaltConcreteRampC270Block), typeof(AsphaltConcreteRampD270Block) }},
    };}}
}

#region DirtRampBlocks
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampABlock : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampBBlock : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampCBlock : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampDBlock : DirtRoadBlock { }

[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampA90Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampB90Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampC90Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampD90Block : DirtRoadBlock { }

[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampA180Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampB180Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampC180Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampD180Block : DirtRoadBlock { }

[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampA270Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampB270Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampC270Block : DirtRoadBlock { }
[Road(typeof(DirtRoadBlock)), Ramp(typeof(DirtRampItem))]
[Serialized, Solid, Constructed] public partial class DirtRampD270Block : DirtRoadBlock { }
#endregion

#region StoneRampBlocks
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampABlock : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampBBlock : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampCBlock : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampDBlock : StoneRoadBlock { }

[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampA90Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampB90Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampC90Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampD90Block : StoneRoadBlock { }

[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampA180Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampB180Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampC180Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampD180Block : StoneRoadBlock { }

[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampA270Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampB270Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampC270Block : StoneRoadBlock { }
[Road(typeof(StoneRoadBlock)), Ramp(typeof(StoneRampItem))]
[Serialized, Solid, Constructed] public partial class StoneRampD270Block : StoneRoadBlock { }
#endregion
