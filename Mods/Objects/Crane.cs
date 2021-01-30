// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.GameActions;
    using Eco.Core.Items;
    using Eco.Shared.Math;

    [Tag("Construction")]
    public partial class CraneItem : WorldObjectItem<CraneObject> { }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))] 
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(CraneToolComponent))]
    [RequireComponent(typeof(PhysicsValueSyncComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [ObjectCanMakeBlockForm(new[] { typeof(WallFormType), typeof(FloorFormType), typeof(RoofFormType), typeof(StairsFormType), typeof(WindowFormType), typeof(FenceFormType), typeof(AqueductFormType), typeof(CubeFormType), typeof(ColumnFormType), typeof(FullWallFormType), typeof(FlatRoofFormType), typeof(ChimneyFormType), typeof(DoubleWindowFormType), typeof(UnderPeakSetFormType), typeof(PeakSetFormType), typeof(RoofPeakSetFormType), typeof(RoofCubeFormType), typeof(RampAFormType), typeof(RampBFormType), typeof(RampCFormType), typeof(RampDFormType), typeof(LadderFormType), typeof(UnderStairsFormType), typeof(FloatStairsFormType), typeof(BraceFormType), typeof(UnderBraceFormType), typeof(SideBraceFormType), typeof(BasicSlopeSideFormType), typeof(BasicSlopeCornerFormType), typeof(BasicSlopeTurnFormType), typeof(BasicSlopePointFormType), typeof(FloatStairsCornerFormType), typeof(FloatStairsTurnFormType), typeof(StairsCornerFormType), typeof(StairsTurnFormType), typeof(UnderBraceCornerFormType), typeof(BraceCornerFormType), typeof(UnderSlopeSideFormType), typeof(UnderSlopeCornerFormType), typeof(UnderSlopeTurnFormType), typeof(UnderSlopePeakFormType), typeof(RoofSideFormType), typeof(RoofTurnFormType), typeof(RoofCornerFormType), typeof(RoofPeakFormType), typeof(UnderInnerPeakFormType), typeof(WindowGrillesFormType), typeof(ThinColumnFormType), typeof(WallTrimFormType), typeof(CladWallFormType) })]
    public class CraneObject : PhysicsWorldObject
    {
        protected CraneObject() { }
        public override LocString DisplayName                     { get { return Localizer.DoStr("Crane"); } }

        private static string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private Player Driver { get { return this.GetComponent<VehicleComponent>().Driver; } }
        protected override void Initialize()
        {
            base.Initialize();
            
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(50);
            this.GetComponent<AirPollutionComponent>().Initialize(0.2f);
            this.GetComponent<VehicleComponent>().Initialize(30, 1, 1);
            this.GetComponent<CraneToolComponent>().Initialize(200, 150);
        }
    }
}
