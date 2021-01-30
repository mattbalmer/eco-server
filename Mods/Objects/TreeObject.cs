// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Eco.Core.Utils;
using Eco.Core.Utils.AtomicAction;
using Eco.Gameplay.Interactions;
using Eco.Gameplay.Items;
using Eco.Gameplay.Minimap;
using Eco.Gameplay.Plants;
using Eco.Gameplay.Players;
using Eco.Gameplay.Rooms;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared;
using Eco.Shared.Math;
using Eco.Shared.Networking;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Simulation;
using Eco.Simulation.Agents;
using Eco.Simulation.Types;
using Eco.Simulation.WorldLayers;
using Eco.Simulation.WorldLayers.Layers;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.GameActions;
using Eco.Simulation.WorldLayers.Pushers;
using Eco.Gameplay.Systems;
using Eco.Shared.Localization;
using Eco.Gameplay.Systems.Tooltip;
using Eco.Shared.Items;
using Eco.Gameplay.Auth;
using Eco.Core.IoC;
using Eco.Gameplay.UI;

[Serialized]
class TrunkPiece
{
    [Serialized] public Guid ID;
    [Serialized] public float SliceStart;
    [Serialized] public float SliceEnd;

    public double LastUpdateTime;
    [Serialized] public Vector3 Position;
    [Serialized] public Vector3 Velocity;
    [Serialized] public Quaternion Rotation;

    [Serialized] public bool Collected;

    public BSONObject ToUpdateBson()
    {
        var bson = BSONObject.New;
        bson["id"] = this.ID;
        bson["pos"] = this.Position;
        bson["rot"] = this.Rotation;
        bson["v"]   = this.Velocity;
        return bson;
    }

    public BSONObject ToInitialBson()
    {
        var bson = BSONObject.New;
        bson["id"] = this.ID;
        bson["start"] = this.SliceStart;
        bson["end"] = this.SliceEnd;
        bson["pos"] = this.Position;
        bson["rot"] = this.Rotation;
        bson["v"]   = this.Velocity;
        bson["collected"] = this.Collected;
        return bson;
    }
}

// gameplay version of simulations tree
[Serialized]
public class TreeEntity : Tree, IInteractableObject, IDamageable, IMinimapObject
{
    public static float DamageExperienceMultiplier = 1f;
    // This needs to be 5, because 5 is the max yield bonus, and 5+5=10 is the max log stack size
    private const int MaxTrunkPickupSize = 5;
    // Max number of tree debris spawn from the tree
    private const int MaxTreeDebris = 20;

    public string Category { get { return "Trees"; } }

    public int IconID { get { return 0; } }

    [Serialized] public Quaternion Rotation { get; protected set; }

    // the list of all the slices done to this trunk
    [Serialized] readonly ThreadSafeList<TrunkPiece> trunkPieces = new ThreadSafeList<TrunkPiece>();

    public override bool UpRooted => this.stumpHealth <= 0;

    public override float SaplingGrowthPercent => 0.3f;

    // estimated, need to get better measurements w/ and w/o Top branch
    private static readonly float[] GrowthThresholds = new float[7] { 0.20f, 0.28f, 0.38f, 0.48f, 0.57f, 0.78f, 0.95f };
    private int currentGrowthThreshold = 0;
    private int treeDebrisSpawned; // it is runtime variable, it shouldn't spawn from felt trees so should be fine, but even if hacked someway it will produce at max 10 debris after restart

    public double LastUpdateTime { get; private set; }
    float lastKeyframeTime;

    public override IEnumerable<Vector3> TrunkPositions { get { return this.trunkPieces.Where(x=>!x.Collected).Select(x=>x.Position); } }

    private ThreadSafeHashSet<Vector3i> groundHits;

    public override bool Ripe
    {
        get
        {
            if (this.Fallen && this.trunkPieces.All(piece => piece.Collected))
                return false;
            return this.GrowthPercent >= this.SaplingGrowthPercent;
        }
    }

    public override bool GrowthBlocked
    {
        get
        {
            if (this.Fallen || this.GrowthPercent >= 1f)
                return true;
            if ((this.currentGrowthThreshold >= GrowthThresholds.Length) // already at max occupied spaces
                || this.GrowthPercent < GrowthThresholds[this.currentGrowthThreshold])
                return false;
            var block = World.GetBlock(this.Position.XYZi + (Vector3i.Up * (this.currentGrowthThreshold + 1)));
            if (!block.Is<Empty>() && block.GetType() != this.Species.BlockType)
                    return true; // can't grow until obstruction is removed
            return false;
        }
    }

    public override float GrowthPercent
    {
        get => base.GrowthPercent;
        set { base.GrowthPercent = Mathf.Clamp01(value); this.UpdateGrowthOccupancy(); }
    }

    private void UpdateGrowthOccupancy()
    {
        while (this.Species != null && !this.Fallen && this.currentGrowthThreshold < GrowthThresholds.Length && this.GrowthPercent >= GrowthThresholds[this.currentGrowthThreshold])
        {
            var block = World.GetBlock(this.Position.XYZi + (Vector3i.Up * (this.currentGrowthThreshold + 1)));
            if (!block.Is<Empty>() && block.GetType() != this.Species.BlockType)
            {
                base.GrowthPercent = GrowthThresholds[this.currentGrowthThreshold] - 0.01f;
                return; // cap growth at slightly less than threshold, can't grow until obstruction is removed
            }
            this.currentGrowthThreshold++;
            World.SetBlock(this.Species.BlockType, this.Position.XYZi + (Vector3i.Up * this.currentGrowthThreshold));
        }
    }

    private bool CanHarvest => this.branches.None(branch => branch != null && branch.Health > 0f);  // can't harvest if any branches are still alive

    public INetObjectViewer Controller { get; private set; }

    #region IInteractable interface
    public float InteractDistance { get { return 2.0f; } }

    private bool CanPickup(TrunkPiece trunk)
    {
        return this.GetBasePickupSize(trunk) <= MaxTrunkPickupSize;
    }

    private float ResourceMultiplier => (this.Species.ResourceRange.Diff * this.GrowthPercent) + this.Species.ResourceRange.Min;

    private int GetBasePickupSize(TrunkPiece trunk) => Math.Max(Mathf.RoundUpToInt((trunk.SliceEnd - trunk.SliceStart) * this.ResourceMultiplier), 1);

    public InteractResult OnActLeft(InteractionContext context) { return InteractResult.NoOp; }
    public InteractResult OnActRight(InteractionContext context) { return InteractResult.NoOp; }
    public InteractResult OnPreInteractionPass(InteractionContext context) => InteractResult.NoOp;

    public InteractResult OnActInteract(InteractionContext context)
    {
        if (!this.Fallen)
            return InteractResult.NoOp;

        if (context.Parameters != null && context.Parameters.ContainsKey("id"))
        {
            this.PickupLog(context.Player, context.Parameters["id"]);
            return InteractResult.Success;
        }

        return InteractResult.NoOp;
    }

    #endregion

    #region IMinimapObject interface
    public string DisplayName { get { return this.Species.DisplayName; } }

    public float MinimapYaw
    {
        get
        {
            Random rand = new Random(this.ID);
            return (2.0f * Mathf.PI) * ((float)Math.Round(rand.NextDouble() * 4.0f) / 4.0f);
        }
    }
    public string SubTitle { get { return string.Empty; } }
    #endregion

    public TreeEntity(TreeSpecies species, WorldPosition3i position, PlantPack plantPack)
        : base(species, position, plantPack)
    { }

    // needed for serialization
    protected TreeEntity()
    { }

    protected override void Initialize()
    {
        base.Initialize();
        this.UpdateGrowthOccupancy();
        if (!this.Fallen)
            MinimapManager.AddMinimapObject(this);
    }

    void CheckDestroy()
    {
        // destroy the tree if it has fallen, all the trunk pieces are collected, and the stump is removed
        if (this.Fallen && this.stumpHealth <= 0 && this.trunkPieces.All(piece => piece.Collected))
            this.Destroy();
    }

    void PickupLog(Player player, Guid logID)
    {
        lock (this)
        {
            if (!this.CanHarvest)
                player.ErrorLocStr("Log is not ready for harvest.  Remove all branches first.");

            TrunkPiece trunk;
            trunk = this.trunkPieces.FirstOrDefault(p => p.ID == logID);
            if (trunk != null && trunk.Collected == false)
            {
                // check log size, if its too big, it can't be picked up
                if (!this.CanPickup(trunk))
                {
                    player.ErrorLocStr("Log is too large to pick up, slice into smaller pieces first.");
                    return;
                }

                var resourceType = this.Species.ResourceItemType;
                var resource     = Item.Get(resourceType);
                var baseCount    = this.GetBasePickupSize(trunk);
                var yield        = resource.Yield;
                var bonusItems   = yield?.GetCurrentValueInt(player.User.DynamicValueContext, null) ?? 0;
                var numItems     = baseCount + bonusItems;
                var carried      = player.User.Inventory.Carried;

                if (numItems > 0)
                {
                    if (!carried.IsEmpty) // Early tests: neeed to check type mismatch and max quantity.
                    { 
                        if      (carried.Stacks.First().Item.Type != resourceType)                    { player.Error(Localizer.Format("You are already carrying {0:items} and cannot pick up {1:items}.", carried.Stacks.First().Item.UILink(StackLinkType.ShowPlural), resource.UILink(StackLinkType.ShowPlural)));  return; }                        
                        else if (carried.Stacks.First().Quantity + numItems > resource.MaxStackSize)  { player.Error(Localizer.Format("You can't carry {0:n0} more {1:items} ({2} max).", numItems, resource.UILink(numItems != 1 ? StackLinkType.ShowPlural : 0), resource.MaxStackSize));                           return; } 
                    }

                    // Prepare a game action pack.
                    var pack = new GameActionPack();
                        pack.AddPostEffect          (() => { trunk.Collected = true; this.RPC("DestroyLog", logID); this.MarkDirty(); this.CheckDestroy(); });  // Delete the log if succseeded.
                        pack.GetOrCreateChangeSet   (carried, player.User).AddItems(this.Species.ResourceItemType, numItems);                                   // Add items to the changeset.
                        pack.AddGameAction          (new HarvestOrHunt() {   Species            = this.Species.GetType(),                                       // Create a game action.
                                                                             HarvestedStacks    = new ItemStack(Item.Get(this.Species.ResourceItemType), numItems).SingleItemAsEnumerable(),
                                                                             ActionLocation           = this.Position.XYZi,
                                                                             Citizen            = player.User,
                                                                             DamagedOrDestroyed = !this.Ripe ? DamagedOrDestroyed.DestroyingOrganism : DamagedOrDestroyed.NotDestroyingOrganism});                    
                        pack.TryPerform(); // Try to perform the action and apply changes & effects.
                }
            }
        }
    }

    #region RPCs
    [RPC]
    public void DestroyLeaf(int branchID, int leafID)
    {
        TreeBranch branch = this.branches[branchID];
        LeafBunch leaf = branch.Leaves[leafID];

        if (leaf.Health > 0)
        {
            // replicate to all clients
            leaf.Health = 0;
            this.RPC("DestroyLeaves", branchID, leafID);
        }
    }

    [RPC]
    public void DestroyBranch(int branchID)
    {
        TreeBranch branch = this.branches[branchID];

        if (branch.Health > 0)
        {
            // replicate to all clients
            branch.Health = 0;
            this.RPC("DestroyBranch", branchID);
        }

        this.MarkDirty();
    }

    private Result TrySliceTrunk(InteractionContext context)
    {
        lock (this) // prevent threading issues due to multiple choppers
        {
            var player     = context.Player;
            var slicePoint = context.Parameters?["slice"].FloatValue ?? 0f;

            // find the trunk piece this is coming from
            var target = this.trunkPieces.FirstOrDefault(p => p.SliceStart < slicePoint && p.SliceEnd > slicePoint);
            if (target == null) return Result.FailedNoMessage;
            else
            {
                // if this is a tiny slice, clamp to the nearest valid size
                const float minPieceResources = 5f;
                var minPieceSize = minPieceResources / this.ResourceMultiplier;
                var targetSize = target.SliceEnd - target.SliceStart;
                var targetResources = targetSize * this.ResourceMultiplier;
                var newPieceSize = target.SliceEnd - slicePoint;
                var newPieceResources = newPieceSize * this.ResourceMultiplier;
                if (targetResources <= minPieceResources) return Result.FailLocStr("This log cannot be sliced any smaller"); // can't slice, too small

                if (targetResources < (2 * minPieceResources))              // if smaller than 2x the min size, slice directly in half
                    slicePoint = target.SliceStart + (.5f * targetSize);
                else if (newPieceSize < minPieceSize)                       // round down to nearest slice point where the resulting block will be the size of the log
                    slicePoint = target.SliceEnd - minPieceSize;
                else if (slicePoint - target.SliceStart <= minPieceSize)    // round up
                    slicePoint = target.SliceStart + minPieceSize;

                var sourceID = target.ID;
                // slice and assign new IDs (New piece is always the back end of the source piece)
                var newPiece = new TrunkPiece()
                {
                    ID = Guid.NewGuid(),
                    SliceStart = slicePoint,
                    SliceEnd = target.SliceEnd,
                    Position = target.Position,
                    Rotation = target.Rotation,
                };
                this.trunkPieces.Add(newPiece);
                target.ID = Guid.NewGuid();
                target.SliceEnd = slicePoint;

                // ensure the pieces are listed in order
                this.trunkPieces.Sort((a, b) => a.SliceStart.CompareTo(b.SliceStart));

                // reciprocate to clients
                this.RPC("SliceTrunk", slicePoint, sourceID, target.ID, newPiece.ID);

                PlantSimEvents.OnLogChopped.Invoke(player.DisplayName);

                this.MarkDirty();
                return Result.Succeeded;
            }
        }
    }

    [RPC]
    public void CollideWithTerrain(Player player, Vector3i position)
    {
        if (player != this.Controller)
            return;

        lock (this)
        {
            if (this.groundHits == null)
                this.groundHits = new ThreadSafeHashSet<Vector3i>();
        }

        // Prevent spawning more than MaxGroundHits debris for one tree
        if (this.treeDebrisSpawned >= MaxTreeDebris)
            return;

        // destroy plants and spawn dirt within a radius under the hit position
        var radius = 1;
        for (var x = -radius; x <= radius; x++)
            for (var z = -radius; z <= radius; z++)
            {
                var offsetpos = position + new Vector3i(x, -1, z);
                if (!this.groundHits.Add(offsetpos))
                    continue;

                var abovepos = offsetpos + Vector3i.Up;
                var aboveblock = World.GetBlock(abovepos);
                var hitblock = World.GetBlock(offsetpos);
                if (!aboveblock.Is<Solid>())
                {
                    // turn soil into dirt
                    if (hitblock.GetType() == typeof(GrassBlock) || hitblock.GetType() == typeof(ForestSoilBlock))
                    {
                        player.SpawnBlockEffect(offsetpos, typeof(DirtBlock), BlockEffect.Delete);
                        World.SetBlock<DirtBlock>(offsetpos);
                        BiomePusher.AddFrozenColumn(offsetpos.XZ);
                    }

                    // kill any above plants
                    if (aboveblock is PlantBlock)
                    {
                        // make sure there is a plant here, sometimes world/ecosim are out of sync
                        var plant = EcoSim.PlantSim.GetPlant(abovepos);
                        if (plant != null)
                        {
                            player.SpawnBlockEffect(abovepos, aboveblock.GetType(), BlockEffect.Delete);
                            EcoSim.PlantSim.DestroyPlant(plant, DeathType.Logging, true);
                        }
                        else
                            World.DeleteBlock(abovepos);
                    }

                    if (hitblock.Is<Solid>() && World.GetBlock(abovepos).Is<Empty>() && RandomUtil.Value < this.Species.ChanceToSpawnDebris)
                    {
                        World.SetBlock(this.Species.DebrisType, abovepos);
                        player.SpawnBlockEffect(abovepos, this.Species.DebrisType, BlockEffect.Place);
                        RoomData.QueueRoomTest(abovepos);

                        if (Interlocked.Increment(ref this.treeDebrisSpawned) >= MaxTreeDebris)
                            return;
                    }
                }
            }
    }
    #endregion

    ChopTree CreateChopTreeAction(InteractionContext context, bool felled, bool branches = false) => new ChopTree()
    {
        Citizen          = context.Player?.User,
        TreeSpecies      = this.Species.GetType(),
        ActionLocation   = this.Position.XYZi,
        AccessNeeded     = AccessType.ConsumerAccess,
        Felled           = felled,
        BranchesTargeted = branches,
        GrowthPercent    = this.GrowthPercent * 100,
        ToolUsed         = context.SelectedItem
    };

    void FellTree(INetObject killer)
    {
        // create the initial trunk piece
        var trunkPiece = new TrunkPiece() { ID = Guid.NewGuid(), SliceStart = 0f, SliceEnd = 1f,  };

        // clear tree occupancy
        if (this.Species.BlockType != null)
        {
            var treeBlockCheck = this.Position.XYZi + Vector3i.Up;
            while (World.GetBlock(treeBlockCheck).GetType() == this.Species.BlockType)
            {
                World.DeleteBlock(treeBlockCheck);
                treeBlockCheck += Vector3i.Up;
            }
        }

        this.trunkPieces.Add(trunkPiece);

        var player = killer as Player;
        if (player != null)
        {
            this.SetPhysicsController(player);                                   // set the killing player's client as the one in control of the physics of the tree. Handled by "FellTree".
            player.RPC("YellTimber");                                            // Issue sound effect.
        }

        this.RPC("FellTree", trunkPiece.ID, this.ResourceMultiplier);            // Fell the tree
        Animal.AlertNearbyAnimals(this.Position, 15f);                           // Alert nearby animals to aware about falling tree

        // break off any branches that are young
        for (var branchID = 0; branchID < this.branches.Length; branchID++)
        {
            var branch = this.branches[branchID];
            if (branch == null)
                continue;

            var branchAge = Mathf.Clamp01((float)((this.GrowthPercent - branch.SpawnAge) / (branch.MatureAge - branch.SpawnAge)));
            if (branchAge <= .5f)
                this.DestroyBranch(branchID);
        }

        if (player != null)
            PlantSimEvents.OnTreeFelled.Invoke(player.DisplayName);

        this.MarkDirty();
    }

    public Result TryApplyDamage(INetObject damager, float amount, InteractionContext context, Item tool, Type damageDealer = null, float experienceMultiplier = 1f)
    {
        // if the tree is really young, just outright uproot and destroy it.
        if (this.GrowthPercent < this.SaplingGrowthPercent)
            return this.TryKillSapling(damager, amount, context);
        else if (context.Parameters == null)
            return this.TryDamageUnfelledTree(damager, amount, context);
        else if (context.Parameters.ContainsKey("stump"))
            return this.TryDamageStump(damager, amount, context);
        else if (context.Parameters.ContainsKey("branch"))
            return this.TryDamageBranch(damager, amount, context);
        else if (context.Parameters.ContainsKey("slice"))
        {
            // If there are still branches, damage them instead.
            for (var branchID = 0; branchID < this.branches.Length; branchID++)
            {
                var branch = this.branches[branchID];
                if (this.TryDamageBranch(branch, branchID, amount, context)) return Result.Succeeded;
            }

            return this.TrySliceTrunk(context);
        }
        else return Result.FailedNoMessage;
    }

    private Result TryKillSapling(INetObject damager, float amount, InteractionContext context)
    {
        var user = (damager is Player player) ? player.User : null;

        var performResult = this.CreateChopTreeAction(context, true).TryPerform();
        if (!performResult) return performResult;

        EcoSim.PlantSim.DestroyPlant(this, DeathType.Harvesting);
        return performResult;
    }

    private Result TryDamageUnfelledTree(INetObject damager, float amount, InteractionContext context)
    {
        var user = (damager as Player)?.User;
        if (this.health <= 0) return Result.FailedNoMessage;

        var performResult = this.CreateChopTreeAction(context, this.health <= amount).TryPerform();
        if (!performResult) return performResult;

        // damage trunk
        var damageDone = InterlockedUtils.SubMinNonNegative(ref this.health, amount);
        if (damageDone <= 0f) return performResult;

        this.RPC("UpdateHP", this.health / this.Species.TreeHealth);

        if (this.health <= 0)
        {
            this.health = 0;
            this.FellTree(damager);
            EcoSim.PlantSim.KillPlant(this, DeathType.Logging, true);
        }

        if (user != null) (context.SelectedItem as ToolItem)?.AddExperience(user, DamageExperienceMultiplier * damageDone, Localizer.Format("felling a {0}", this.Species.UILink()));

        this.MarkDirty();
        return Result.Succeeded;
    }

    private Result TryDamageStump(INetObject damager, float amount, InteractionContext context)
    {
        if (this.Fallen && this.stumpHealth > 0)
        {
            var player = damager as Player;
            if (player != null)
            {
                var performResult = new ChopStump()
                {
                    Citizen        = player.User,
                    ActionLocation = this.Position.XYZi,
                    Destroyed      = this.stumpHealth <= amount,
                    TreeSpecies    = this.Species.GetType()
                }.TryPerform();
                if (!performResult) return performResult;
            }

            this.stumpHealth = Mathf.Max(0, this.stumpHealth - amount);

            if (this.stumpHealth <= 0)
            {
                if (World.GetBlock(this.Position.XYZi).GetType() == this.Species.BlockType) World.DeleteBlock(this.Position.XYZi);
                this.stumpHealth = 0;
                //give tree resources
                if (player != null)
                {
                    var changes = new InventoryChangeSet(player.User.Inventory, player.User);
                    var trunkResources = this.Species.TrunkResources;
                    if (trunkResources != null) trunkResources.ForEach(x => changes.AddItems(x.Key, x.Value.RandInt));
                    else DebugUtils.Fail("Trunk resources missing for: " + this.Species.Name);
                    changes.TryApply();
                }
                this.RPC("DestroyStump");

                // Let another plant grow here
                EcoSim.PlantSim.UpRootPlant(this);
            }

            this.MarkDirty();
            this.CheckDestroy();
            return Result.Succeeded;
        }
        else
            return Result.FailedNoMessage;
    }

    private Result TryDamageBranch(INetObject damager, float amount, InteractionContext context)
    {
        int branchID = context.Parameters["branch"];
        var branch   = this.branches[branchID];

        if (context.Parameters.ContainsKey("leaf")) // damage leaf
        {
            int leafID = context.Parameters["leaf"];            
            var leaf   = branch.Leaves[leafID];

            if (leaf.Health > 0)
            {
                var performResult = this.CreateChopTreeAction(context, false, true).TryPerform();
                if (!performResult) return performResult;
                if ((leaf.Health = Mathf.Max(0, leaf.Health - amount)) == 0) this.RPC("DestroyLeaves", branchID, leafID);
            }

            this.MarkDirty();
            return Result.Succeeded;
        }
        else return this.TryDamageBranch(branch, branchID, amount, context);
    }

    private Result TryDamageBranch(TreeBranch branch, int branchID, float amount, InteractionContext context)
    {
        if (branch != null && branch.Health > 0)
        {
            var performResult = this.CreateChopTreeAction(context, false, true).TryPerform();
            if (!performResult) return performResult;
            if ((branch.Health = Mathf.Max(0, branch.Health - amount)) == 0) { this.RPC("DestroyBranch", branchID); this.MarkDirty(); }

            return Result.Succeeded;
        }
        else return Result.FailedNoMessage;
    }

    public override void SendInitialState(BSONObject bsonObj, INetObjectViewer viewer)
    {
        base.SendInitialState(bsonObj, viewer);

        // if we have trunk pieces, send those
        var trunkInfo = BSONArray.New;
        if (this.trunkPieces.Count > 0)
        {
            foreach (var trunkPiece in this.trunkPieces)
                trunkInfo.Add(trunkPiece.ToInitialBson());
        }
        bsonObj["trunks"] = trunkInfo;

        if (this.Controller != null && this.Controller is INetObject)
            bsonObj["controller"] = ((INetObject)this.Controller).ID;

        bsonObj["mult"] = this.ResourceMultiplier;
        bsonObj["density"] = this.Species.Density;
    }

    public override void SendUpdate(BSONObject bsonObj, INetObjectViewer viewer)
    {
        base.SendUpdate(bsonObj, viewer);

        if (this.Fallen && this.Controller != viewer)
        {
            var trunkInfo = BSONArray.New;
            foreach (var trunkPiece in this.trunkPieces)
            {
                if (trunkPiece.Position == Vector3.Zero)
                    continue;
                if (trunkPiece.LastUpdateTime < viewer.LastSentUpdateTime)
                    continue;

                trunkInfo.Add(trunkPiece.ToUpdateBson());
            }
            bsonObj["trunks"] = trunkInfo;
            bsonObj["time"] = this.lastKeyframeTime;
        }
    }

    public override void ReceiveUpdate(BSONObject bsonObj)
    {
        bool changed = false;
        if (!bsonObj.ContainsKey("trunks"))
            return;
        BSONArray trunks = bsonObj["trunks"].ArrayValue;
        foreach (BSONObject obj in trunks.list)
        {
            Guid id = obj["id"];
            TrunkPiece piece = this.trunkPieces.FirstOrDefault(p => p.ID == id);

            if (piece != null && (piece.Position != obj["pos"] || piece.Rotation != obj["rot"]))
            {
                piece.Position = obj["pos"];
                piece.Rotation = obj["rot"];
                piece.Velocity = obj["v"];
                piece.LastUpdateTime = TimeUtil.Seconds;
                changed = true;
            }
        }

        if (changed)
        {
            if (this.UpRooted)
                this.Position = this.trunkPieces.First().Position;
            this.lastKeyframeTime = bsonObj["time"];
            this.LastUpdateTime = TimeUtil.Seconds;
        }
    }

    public override void OnChanged()
    {
        this.LastUpdateTime = TimeUtil.Seconds;
    }

    #region mostly copied from NetPhysicsEntity
    public override bool IsRelevant(INetObjectViewer viewer)
    {
        if (viewer is IWorldObserver)
        {
            IWorldObserver observer = viewer as IWorldObserver;
            var closestWrapped = World.ClosestWrappedLocation(observer.Position, this.Position);
            var notVisibleDistance = observer.ViewDistance + Eco.Shared.Voxel.Chunk.Size;
            var v = closestWrapped - observer.Position;
            if (Mathf.Abs(v.x) >= notVisibleDistance || Mathf.Abs(v.z) >= notVisibleDistance)
            {
                if (this.Controller == null)
                    this.SetPhysicsController(viewer);
                return true;
            }
        }
        return false;
    }

    public override bool IsNotRelevant(INetObjectViewer viewer)
    {
        if (viewer is IWorldObserver)
        {
            IWorldObserver observer = viewer as IWorldObserver;
            var closestWrapped = World.ClosestWrappedLocation(observer.Position, this.Position);
            var notVisibleDistance = observer.ViewDistance + Eco.Shared.Voxel.Chunk.Size;
            var v = closestWrapped - observer.Position;
            if (Mathf.Abs(v.x) >= notVisibleDistance || Mathf.Abs(v.z) >= notVisibleDistance)
            {
                if (this.Controller != null && this.Controller.Equals(viewer))
                    this.SetPhysicsController(null);
                return true;
            }
            else
            {
                // Still relevant, Check if viewer would be a better controller
                if (this.Controller == null)
                    this.SetPhysicsController(viewer);
                else if (this.Controller != viewer && Vector2.WrappedDistance(observer.Position.XZ, this.Position.XZ) < 10f)
                {
                    IWorldObserver other = this.Controller as IWorldObserver;
                    if (Vector2.WrappedDistance(other.Position.XZ, this.Position.XZ) > 15f)
                        this.SetPhysicsController(viewer);
                }
            }
        }
        return false;
    }

    public bool SetPhysicsController(INetObjectViewer owner)
    {
        // Trees don't need physics until felled
        if (!this.Fallen)
            return false;

        if (Equals(this.Controller, owner))
            return false;

        this.Controller?.RemoveDestroyAction(this.RemovePhysicsController);

        this.Controller = owner;

        this.Controller?.AddDestroyAction(this.RemovePhysicsController);

        if (owner is INetObject netObject)
            this.NetObj.Controller.RPC("UpdateController", netObject.ID);

        return true;
    }

    void RemovePhysicsController()
    {
        this.SetPhysicsController(null);
    }
    #endregion

    public override bool IsUpdated(INetObjectViewer viewer)
    {
        if (this.LastUpdateTime > viewer.LastSentUpdateTime && SleepManager.Obj.AcceleratingTime) return true;
        return this.Fallen && this.trunkPieces.Any(piece => !piece.Collected) && this.LastUpdateTime > viewer.LastSentUpdateTime;
    }


    public override void Destroy()
    {
        var treeBlockCheck = this.Position.XYZi;
        for (int i = 0; i <= GrowthThresholds.Length; i++)
        {
            var block = World.GetBlock(treeBlockCheck);
            if (block.GetType() == this.Species.BlockType)
                World.DeleteBlock(treeBlockCheck);
            if (block.Is<Solid>())
                break;
            treeBlockCheck += Vector3i.Up;
        }
        if (this.NetObj != null)
            MinimapManager.RemoveMinimapObject(this);
        base.Destroy();
    }
}
