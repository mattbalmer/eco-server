// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Objects;
    using Eco.Shared.Serialization;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Civics;
    using Eco.Gameplay.Civics.Elections;
    using System;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Civics.Titles;
    using Eco.Gameplay.Civics.Laws;
    using Eco.Gameplay.Civics.Demographics;
    using Eco.Gameplay.Civics.Districts;
    using Eco.Gameplay.Civics.Misc;
    using Eco.Core.Plugins.Interfaces;
    using Eco.Gameplay.Civics.Laws.ExecutiveActions;
    using Eco.Gameplay.Civics.Constitutional;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Shared.Items;

    //A component for performing specific civic actions
    public partial class BallotBoxItem : WorldObjectItem<BallotBoxObject> { }

    [RequireComponent(typeof(PerformCivicActionComponent))]
    public partial class BallotBoxObject : CivicObject
    {
        public override Type[] AvailableCivicActions => new[]
        {
            typeof(CivicAction_Vote),
            typeof(CivicAction_Veto),
            typeof(CivicAction_StartElection),
            typeof(CivicAction_EnterElection),
            typeof(CivicAction_WithdrawFromElection),
        };
    }

    [RequireComponent(typeof(NameDataTrackerComponent))]
    [RequireComponent(typeof(AuthDataTrackerComponent))]
    [RequireComponent(typeof(ConstitutionComponent))] 
    public partial class CapitolObject : WorldObject, IPersistentData
    {
        public override LocString PickupConfirmation => Localizer.Do($"You are attempting to pickup {this.MarkedUpName}, this will disable {this.GetComponent<ConstitutionComponent>().Constitution?.MarkedUpName ?? Localizer.DoStr("Constitution")} after a timer expires. Do you wish to proceed?");
       
        protected override void OnCreate()
        {
            base.OnCreate();
            this.GetComponent<PropertyAuthComponent>().SetPublic();
        }

        public             object PersistentData { get; set; }
    }

    [RequireComponent(typeof(PerformCivicActionComponent))]
    public partial class ExecutiveOfficeObject : CivicObject
    {
        public override Type[] AvailableCivicActions => new[] { typeof(CivicAction_PerformExecutiveAction) };
    }

    [RequireComponent(typeof(CivicObjectComponent))]
    [RequireComponent(typeof(PerformCivicActionComponent))]
    public partial class GovernmentOfficeObject : CivicObject 
    { 
        public override Type[] CivicSlotTypes        => new[] { typeof(ElectedTitle) } ;
        public override Type[] AvailableCivicActions => new[] { typeof(CivicAction_ResignFromOffice), typeof(CivicAction_RemoveFromOffice) };
    }
    
    [RequireComponent(typeof(CivicObjectComponent))] public partial class CensusBureauObject     : CivicObject { public override Type[] CivicSlotTypes => new[] { typeof(Demographic) }; }
    [RequireComponent(typeof(CivicObjectComponent))] public partial class CourtObject            : CivicObject { public override Type[] CivicSlotTypes => new[] { typeof(Law) }; }
    [RequireComponent(typeof(CivicObjectComponent))] public partial class BoardOfElectionsObject : CivicObject { public override Type[] CivicSlotTypes => new[] { typeof(ElectionProcess) }; }
    [RequireComponent(typeof(CivicObjectComponent))] public partial class ZoningOfficeObject     : CivicObject { public override Type[] CivicSlotTypes => new[] { typeof(DistrictMap) }; }
    [RequireComponent(typeof(CivicObjectComponent))] public partial class AmendmentsObject       : CivicObject { public override Type[] CivicSlotTypes => new[] { typeof(ConstitutionalAmendment) }; }

    [LocDescription("Allows the creation of Demographics, which specify groups of citizens automatically based on criteria you define.")]                            public partial class CensusBureauItem       : WorldObjectItem<CensusBureauObject>     { }
    [LocDescription("Allows the creation of Elected Titles, which can be given special privileges.")]                                                                public partial class GovernmentOfficeItem   : WorldObjectItem<GovernmentOfficeObject> { }
    [LocDescription("Allows the creation of Laws, which can perform many types of regulations, restrictions, taxations, incentives, and more.")]                     public partial class CourtItem              : WorldObjectItem<CourtObject>            { }
    [LocDescription("Allows the creation of Election Processes, which are different kinds of elections with different settings (who can vote, who can veto, etc).")] public partial class BoardOfElectionsItem   : WorldObjectItem<BoardOfElectionsObject> { }
    [LocDescription("Allows the creation of District Maps, which define a set of districts.  Districts can then be specified in laws and other civic actions.")]     public partial class ZoningOfficeItem       : WorldObjectItem<ZoningOfficeObject>     { }
    [LocDescription("Allows the creation of the government, allowing all other civic objects to be created.")]                                                       public partial class CapitolItem            : WorldObjectItem<CapitolObject>          { }
    [LocDescription("Allows the modification of the constitution. ")]                                                                                                public partial class AmendmentsItem         : WorldObjectItem<AmendmentsObject>       { }
    [LocDescription("Allows the creation of Executive Actions. ")]                                                                                                   public partial class ExecutiveOfficeItem    : WorldObjectItem<ExecutiveOfficeObject> { }

    public class CivicItemUtil : IModInit
    {
        //Tie civic types to the item that makes them.
        public static void Initialize()
        {
            Register(typeof(Demographic),                        typeof(CensusBureauItem));
            Register(typeof(ElectedTitle),                       typeof(GovernmentOfficeItem));
            Register(typeof(Law),                                typeof(CourtItem));
            Register(typeof(ElectionProcess),                    typeof(BoardOfElectionsItem));
            Register(typeof(DistrictMap),                        typeof(ZoningOfficeItem));
            Register(typeof(Constitution),                       typeof(CapitolItem));
            Register(typeof(ConstitutionalAmendment),            typeof(AmendmentsItem));
            Register(typeof(CivicAction_PerformExecutiveAction), typeof(ExecutiveOfficeItem));

            CivicsUtils.BallotBoxItem = typeof(BallotBoxItem);
        }

        private static void Register(Type civicType, Type item) => CivicsUtils.CivicTypeToItems.AddToList(civicType, item);
    }

    /// <summary>
    /// An object that can have civic slots and/or civic actions.
    /// </summary>
    [Serialized]
    [RequireComponent(typeof(NameDataTrackerComponent))]
    [RequireComponent(typeof(AuthDataTrackerComponent))]
    public abstract class CivicObject : WorldObject
    {
        public virtual Type[] CivicSlotTypes        => null;
        public virtual Type[] AvailableCivicActions => null;
        public virtual int SlotCount => 3;
        public override LocString PickupConfirmation {get 
        {
            if (this.CivicSlotTypes == null) return LocString.Empty; // Don't show confirmation popup if slots type is null

            var result      = new LocStringBuilder();

            //Get active proposables and ones that are in an election, and make them considered orphaned. The rest (drafts) we let destroy.
            var activeSlots = 
                    CivicsUtils.GetHostedProposables(this.CivicSlotTypes, this).Where(x=>x.State == ProposableState.Active || 
                                                                                         ElectionUtils.ElectionsConcerningProposables(x).Any())
                    .Select(x => x.MarkedUpName)
                    .CommaList(); 

            result.AppendLineLoc($"You are attempting to pickup {this.MarkedUpName}.");
            if (activeSlots?.Count() > 0) result.AppendLineLoc($"This will disable all active and in-election {this.CivicSlotTypes?.FirstOrDefault()?.GetLocDisplayName().Pluralize()} on it after a timer expires. This includes: {activeSlots}"); 
            result.AppendLineLocStr("Do you wish to proceed?");

            return result.ToLocString();
        }}

        protected override void Initialize()
        {
            if (this.CivicSlotTypes != null)
                foreach(var type in this.CivicSlotTypes)
                    this.GetOrCreateComponent<CivicObjectComponent>().Setup(type, this.SlotCount);
            if (this.AvailableCivicActions != null) this.GetOrCreateComponent<PerformCivicActionComponent>().AvailableTypes = this.AvailableCivicActions;
            base.Initialize();
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            this.GetComponent<PropertyAuthComponent>().SetPublic();
        }
    }
}
