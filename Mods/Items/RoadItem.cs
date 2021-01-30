// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using Eco.Gameplay.GameActions;
using Eco.Gameplay.Items;
using Eco.Shared.Items;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

[Serialized, ConstructWithoutTool(true)] public abstract class RoadItem<T> : BlockItem<T> { }
