using Akka.Actor;
using Akka.IO;
using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.DirectSales;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using OX.Tablet.Config;
using OX.Wallets;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OX.Mining;
using OX.Mining.StakingMining;
namespace OX.Tablet.UIs.Rothschild
{
    public partial class WitnessPage : UIPage, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));


        public WitnessPage()
        {
            InitializeComponent();
            this.tv_witnessRecord.MouseDown += Tv_witnessRecord_MouseDown;
        }

        private void Tv_witnessRecord_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                UIContextMenuStrip menu = new UIContextMenuStrip();

                var node = this.tv_witnessRecord.SelectedNode;

                var tag = node.Tag;
                if (tag is MutualLockSnapshotData)
                {
                    var sm = new ToolStripMenuItem(UIHelper.LocalString("时空量快照", "Space-Time volume snapshot"));
                    sm.Tag = node.Tag;
                    sm.Click += Sm_Click;
                    menu.Items.Add(sm);
                }
                if (menu.Items.Count > 0)
                    menu.Show(this.tv_witnessRecord, e.Location);
            }
        }

        private void Sm_Click(object? sender, EventArgs e)
        {
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            MutualLockSnapshotData snapshotData = ToolStripMenuItem.Tag as MutualLockSnapshotData;
            new SpaceTimeSnapshot(snapshotData).ShowDialog();
        }

        public void HeartBeat(HeartBeatContext beatContext)
        {

        }
        public void BeforeBlock(Block block)
        {

        }
        public void OnBlock(Block block)
        {

        }
        public void AfterBlock(Block block)
        {

        }
        public void OnFlashMessage(FlashMessage message)
        {

        }
        public void OnClipboardString(ClipboardMessageType messageType, string msg)
        {

        }
        MutualLockMiningAssetReply Last;
        void showAsset()
        {
            this.tv_asset.Nodes.Clear();
            var act = SecureHelper.MasterAccount;
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var lockMiningAssets = miningIndex.GetAll<MutualLockMiningAssetKey, MutualLockMiningAssetReply>(InvestBizPersistencePrefixes.MutualLockMiningAssetReply);
            if (lockMiningAssets.IsNotNullAndEmpty())
            {

                foreach (var p in lockMiningAssets.GroupBy(m => m.Key.AssetId))
                {

                    var assetState = Blockchain.Singleton.Store.GetAssets().TryGet(p.Key);
                    var cap = assetState.Amount == -Fixed8.Satoshi ? "+\u221e" : assetState.Amount.ToString();
                    var havecap = assetState.Available.ToString();

                    var node = new TreeNode(UIHelper.LocalString($"资产Id:{p.Key.ToString()}", $"Asset Id:{p.Key.ToString()}"));
                    //node.NodeType = 1;
                    node.Tag = p.Key;
                    var subNode = new TreeNode(UIHelper.LocalString($"资产名:{assetState.GetName()}", $"Asset Name:{assetState.GetName()}"));
                    //subNode.NodeType = 2;
                    subNode.Tag = p.Key;
                    node.Nodes.Add(subNode);
                    subNode = new TreeNode(UIHelper.LocalString($"最大发行量:{cap}", $"Issue Cap:{cap}"));
                    //subNode.NodeType = 2;
                    subNode.Tag = p.Key;
                    node.Nodes.Add(subNode);
                    subNode = new TreeNode(UIHelper.LocalString($"已发行量:{havecap}", $"Issued:{havecap}"));
                    //subNode.NodeType = 2;
                    subNode.Tag = p.Key;
                    node.Nodes.Add(subNode);

                    foreach (var l in p.OrderByDescending(m => m.Key.IssueIndex))
                    {
                        if (Last.IsNull()) Last = l.Value;
                        subNode = new TreeNode(UIHelper.LocalString($"参数发布区块:{l.Key.IssueIndex}", $"Parameter issue height:{l.Key.IssueIndex}"));
                        //subNode.NodeType = 2;
                        subNode.Tag = p.Key;
                        node.Nodes.Add(subNode);

                        var subsubNode = new TreeNode(UIHelper.LocalString($"最少锁仓量:{l.Value.MinAmount}", $"Min Lock:{l.Value.MinAmount}"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = new TreeNode(UIHelper.LocalString($"最大锁仓量:{l.Value.MaxAmount}", $"Max Lock:{l.Value.MaxAmount}"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = new TreeNode(UIHelper.LocalString($"互证收益率:{l.Value.AirdropAmount}/100*100000", $"Dynamic Income Ratio:{l.Value.AirdropAmount}/100*100000"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = new TreeNode(UIHelper.LocalString($"100000区块利率:{l.Value.Interest_100000}/1000", $"100000 blocks ratio:{l.Value.Interest_100000}/1000"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = new TreeNode(UIHelper.LocalString($"500000区块利率:{l.Value.Interest_500000}/1000", $"500000 blocks ratio:{l.Value.Interest_500000}/1000"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = new TreeNode(UIHelper.LocalString($"1000000区块利率:{l.Value.Interest_1000000}/1000", $"1000000 blocks ratio:{l.Value.Interest_1000000}/1000"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = new TreeNode(UIHelper.LocalString($"2000000区块利率:{l.Value.Interest_2000000}/1000", $"2000000 blocks ratio:{l.Value.Interest_2000000}/1000"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = new TreeNode(UIHelper.LocalString($"4000000区块利率:{l.Value.Interest_4000000}/1000", $"4000000 blocks ratio:{l.Value.Interest_4000000}/1000"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                        subsubNode = new TreeNode(UIHelper.LocalString($"6000000区块利率:{l.Value.Interest_6000000}/1000", $"6000000 blocks ratio:{l.Value.Interest_6000000}/1000"));
                        //subsubNode.NodeType = 2;
                        subsubNode.Tag = p.Key;
                        subNode.Nodes.Add(subsubNode);
                    }
                    Fixed8 total = Fixed8.Zero;
                    var acts = Blockchain.Singleton.CurrentSnapshot.Accounts.GetAndChange(act.ScriptHash, () => null);
                    if (acts.IsNotNull())
                    {
                        total += acts.GetBalance(p.Key);
                    }

                    subNode = new TreeNode(UIHelper.LocalString($"私钥账户余额:{total}", $"Private Account Balance:{total}"));
                    //subNode.NodeType = 2;
                    subNode.Tag = p.Key;
                    node.Nodes.Add(subNode);
                    this.tv_asset.Nodes.Add(node);
                }

            }
        }
        void showLockRecords()
        {
            this.tv_witnessRecord.Nodes.Clear();
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var ps = miningIndex.GetAll<MutualLockKey, MutualLockValue>(InvestBizPersistencePrefixes.MutualLockRecords);
            if (ps.IsNotNullAndEmpty())
            {
                foreach (var g in ps.GroupBy(m => m.Key.AssetId))
                {
                    if (miningIndex.MutualLockAssets.TryGetValue(g.Key, out MutualLockMiningAssetReply mar))
                    {
                        var assetState = Blockchain.Singleton.Store.GetAssets().TryGet(g.Key);
                        var cap = assetState.Amount == -Fixed8.Satoshi ? "+\u221e" : assetState.Amount.ToString();
                        var havecap = assetState.Available.ToString();
                        var node = new TreeNode(UIHelper.LocalString($"资产Id:{g.Key.ToString()}", $"Asset Id:{g.Key.ToString()}"));
                        //node.NodeType = 1;
                        node.Tag = g.Key;
                        var subNode = new TreeNode(UIHelper.LocalString($"资产名:{assetState.GetName()}", $"Asset Name:{assetState.GetName()}"));
                        //subNode.NodeType = 1;
                        subNode.Tag = g.Key;
                        node.Nodes.Add(subNode);
                        subNode = new TreeNode(UIHelper.LocalString($"最大发行量:{cap}", $"Issue Cap:{cap}"));
                        //subNode.NodeType = 1;
                        subNode.Tag = g.Key;
                        node.Nodes.Add(subNode);
                        subNode = new TreeNode(UIHelper.LocalString($"已发行量:{havecap}", $"Issued:{havecap}"));
                        //subNode.NodeType = 1;
                        subNode.Tag = g.Key;
                        node.Nodes.Add(subNode);
                        subNode = new TreeNode(UIHelper.LocalString("时空见证记录", "Space-time Witness Records"));
                        //subNode.NodeType = 1;
                        subNode.Tag = g.Key;
                        node.Nodes.Add(subNode);
                        var act = SecureHelper.MasterAccount;
                        if (miningIndex.MutualLockNodes.TryGetValue(act.ScriptHash.GetMutualLockSeed(), out MutualNode mn))
                        {
                            var subNode2 = new TreeNode(act.Address);
                            //subNode2.NodeType = 2;
                            subNode.Nodes.Add(subNode2);
                            var gs = g.Where(m => m.Key.Owner.Equals(act.ScriptHash));
                            var gs2 = g.Where(m => m.Key.ParentOwner.Equals(act.ScriptHash));
                            IEnumerable<MutualLockKey> self = default;
                            IEnumerable<MutualLockKey> leaf = default;
                            TreeNode n3 = default;
                            if (gs.IsNotNullAndEmpty())
                            {
                                self = gs.Select(m => m.Key);
                                n3 = new TreeNode(UIHelper.LocalString($"本徽章见证记录", $"Current Badge Witness Records"));
                                //n3.NodeType = 3;
                                n3.Tag = act.ScriptHash;
                                subNode2.Nodes.Add(n3);
                                foreach (var r in gs.OrderByDescending(m => m.Key.Timestamp))
                                {
                                    var n4 = new TreeNode(UIHelper.LocalString($"锁仓数:{r.Key.Amount.ToString()}", $"Lock Volume:{r.Key.Amount.ToString()}"));
                                    //n4.NodeType = 4;
                                    n4.Tag = act.ScriptHash;
                                    var n5 = new TreeNode(UIHelper.LocalString($"锁仓时间:{r.Key.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}", $"Lock Time:{r.Key.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n5 = new TreeNode(UIHelper.LocalString($"锁仓高度:{r.Key.StartIndex}", $"Lock Height:{r.Key.StartIndex}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n5 = new TreeNode(UIHelper.LocalString($"锁仓地址:{r.Key.LockAddress.ToAddress()}", $"Lock Address:{r.Key.LockAddress.ToAddress()}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n5 = new TreeNode(UIHelper.LocalString($"解锁高度:{r.Key.EndIndex}", $"Unlock Height:{r.Key.EndIndex}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n3.Nodes.Add(n4);
                                }
                            }
                            if (gs2.IsNotNullAndEmpty())
                            {
                                leaf = gs2.Select(m => m.Key);
                                n3 = new TreeNode(UIHelper.LocalString($"叶子徽章见证记录", $"Leaf Badge Witness Records"));
                                //n3.NodeType = 3;
                                n3.Tag = act.ScriptHash;
                                subNode2.Nodes.Add(n3);
                                foreach (var r in gs2.OrderByDescending(m => m.Key.Timestamp))
                                {
                                    var n4 = new TreeNode(UIHelper.LocalString($"锁仓数:{r.Key.Amount.ToString()}", $"Lock Volume:{r.Key.Amount.ToString()}"));
                                    //n4.NodeType = 4;
                                    n4.Tag = act.ScriptHash;
                                    var n5 = new TreeNode(UIHelper.LocalString($"锁仓时间:{r.Key.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}", $"Lock Time:{r.Key.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n5 = new TreeNode(UIHelper.LocalString($"锁仓高度:{r.Key.StartIndex}", $"Lock Height:{r.Key.StartIndex}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n5 = new TreeNode(UIHelper.LocalString($"锁仓地址:{r.Key.LockAddress.ToAddress()}", $"Lock Address:{r.Key.LockAddress.ToAddress()}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n5 = new TreeNode(UIHelper.LocalString($"解锁地址:{r.Key.Owner.ToAddress()}", $"Unlock Address:{r.Key.Owner.ToAddress()}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n5 = new TreeNode(UIHelper.LocalString($"解锁高度:{r.Key.EndIndex}", $"Unlock Height:{r.Key.EndIndex}"));
                                    //n5.NodeType = 5;
                                    n5.Tag = act.ScriptHash;
                                    n4.Nodes.Add(n5);
                                    n3.Nodes.Add(n4);
                                }
                            }

                            subNode2.Tag = new MutualLockSnapshotData { MutualLockMiningAssetReply = mar, Node = mn, Self = self, Leaf = leaf };
                        }

                        this.tv_witnessRecord.Nodes.Add(node);
                    }
                }
            }
        }
        void showSelfWitnessRecords()
        {
            this.tv_selfWitnessRecords.Nodes.Clear();
            var act = SecureHelper.MasterAccount;
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var ps = miningIndex.GetAll<SelfLockKey, LockMiningRecordMerge>(InvestBizPersistencePrefixes.LockMiningInterestRecords);
            if (ps.IsNotNullAndEmpty())
            {
                foreach (var g in ps.Where(m => act.ScriptHash == m.Key.Holder).GroupBy(m => m.Value.AssetId))
                {

                    this.DoInvoke(() =>
                    {

                        var assetState = Blockchain.Singleton.Store.GetAssets().TryGet(g.Key);
                        var cap = assetState.Amount == -Fixed8.Satoshi ? "+\u221e" : assetState.Amount.ToString();
                        var havecap = assetState.Available.ToString();

                        var node = new TreeNode(UIHelper.LocalString($"资产Id:{g.Key.ToString()}", $"Asset Id:{g.Key.ToString()}"));
                        //node.NodeType = 1;
                        node.Tag = g.Key;
                        var subNode = new TreeNode(UIHelper.LocalString($"资产名:{assetState.GetName()}", $"Asset Name:{assetState.GetName()}"));
                        //subNode.NodeType = 1;
                        subNode.Tag = g.Key;
                        node.Nodes.Add(subNode);
                        subNode = new TreeNode(UIHelper.LocalString($"最大发行量:{cap}", $"Issue Cap:{cap}"));
                        //subNode.NodeType = 1;
                        subNode.Tag = g.Key;
                        node.Nodes.Add(subNode);
                        subNode = new TreeNode(UIHelper.LocalString($"已发行量:{havecap}", $"Issued:{havecap}"));
                        //subNode.NodeType = 1;
                        subNode.Tag = g.Key;
                        node.Nodes.Add(subNode);
                        subNode = new TreeNode(UIHelper.LocalString($"自证收益记录", $"Income Records"));
                        //subNode.NodeType = 1;
                        subNode.Tag = g.Key;
                        node.Nodes.Add(subNode);

                        var subNodeHolder = new TreeNode(act.Address);
                        //subNodeHolder.NodeType = 3;
                        subNodeHolder.Tag = act.ScriptHash;
                        subNode.Nodes.Add(subNodeHolder);
                        var gs = g.Where(m => m.Key.Holder.Equals(act.ScriptHash));
                        foreach (var p in gs.OrderByDescending(m => m.Value.Timestamp))
                        {
                            TransactionOutput output = p.Value.Output;
                            var subNode2 = new TreeNode(UIHelper.LocalString($"收益额:{output.Value}", $"Income Volume:{output.Value}"));
                            //subNode2.NodeType = 2;
                            subNode2.Tag = p.Value;
                            subNodeHolder.Nodes.Add(subNode2);
                            var subsubNode = new TreeNode(UIHelper.LocalString($"收益时间:{p.Value.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}", $"Income Time:{p.Value.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}"));
                            //subsubNode.NodeType = 1;
                            subsubNode.Tag = g.Key;
                            subNode2.Nodes.Add(subsubNode);

                            subsubNode = new TreeNode(UIHelper.LocalString($"收益地址:{output.ScriptHash.ToAddress()}", $"Income Address:{output.ScriptHash.ToAddress()}"));
                            //subsubNode.NodeType = 2;
                            subsubNode.Tag = p.Value;
                            subNode2.Nodes.Add(subsubNode);

                            subsubNode = new TreeNode(UIHelper.LocalString($"解锁高度:{p.Value.LockExpiration}", $"Unlock Height:{p.Value.LockExpiration}"));
                            //subsubNode.NodeType = 2;
                            subsubNode.Tag = p.Value;
                            subNode2.Nodes.Add(subsubNode);
                        }

                        this.tv_selfWitnessRecords.Nodes.Add(node);
                    });
                }
            }
        }
        void showMutualWitnessRecords()
        {
            this.tv_mutualWitnessRecords.Nodes.Clear();
            var act = SecureHelper.MasterAccount;
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var ps = miningIndex.GetAll<MutualLockInterestKey, MutualLockValue>(InvestBizPersistencePrefixes.MutualLockInterestRecords);
            if (ps.IsNotNullAndEmpty())
            {
                foreach (var g in ps.GroupBy(m => m.Key.AssetId))
                {

                    var assetState = Blockchain.Singleton.Store.GetAssets().TryGet(g.Key);
                    var cap = assetState.Amount == -Fixed8.Satoshi ? "+\u221e" : assetState.Amount.ToString();
                    var havecap = assetState.Available.ToString();

                    var node = new TreeNode(UIHelper.LocalString($"资产Id:{g.Key.ToString()}", $"Asset Id:{g.Key.ToString()}"));
                    //node.NodeType = 1;
                    node.Tag = g.Key;
                    var subNode = new TreeNode(UIHelper.LocalString($"资产名:{assetState.GetName()}", $"Asset Name:{assetState.GetName()}"));
                    //subNode.NodeType = 1;
                    subNode.Tag = g.Key;
                    node.Nodes.Add(subNode);
                    subNode = new TreeNode(UIHelper.LocalString($"最大发行量:{cap}", $"Issue Cap:{cap}"));
                    //subNode.NodeType = 1;
                    subNode.Tag = g.Key;
                    node.Nodes.Add(subNode);
                    subNode = new TreeNode(UIHelper.LocalString($"已发行量:{havecap}", $"Issued:{havecap}"));
                    //subNode.NodeType = 1;
                    subNode.Tag = g.Key;
                    node.Nodes.Add(subNode);
                    subNode = new TreeNode(UIHelper.LocalString($"互证收益记录", $"Interest Records"));
                    //subNode.NodeType = 1;
                    subNode.Tag = g.Key;
                    node.Nodes.Add(subNode);

                    var subNode2 = new TreeNode(act.Address);
                    //subNode2.NodeType = 2;
                    subNode2.Tag = act.ScriptHash;
                    subNode.Nodes.Add(subNode2);
                    var gs = g.Where(m => m.Key.Owner.Equals(act.ScriptHash));
                    TreeNode n3 = default;
                    if (gs.IsNotNullAndEmpty())
                    {
                        n3 = new TreeNode(UIHelper.LocalString($"本徽章收益记录", $"Current Badge Income Records"));
                        //n3.NodeType = 3;
                        n3.Tag = act.ScriptHash;
                        subNode2.Nodes.Add(n3);
                        foreach (var r in gs.OrderByDescending(m => m.Key.Timestamp))
                        {

                            var n4 = new TreeNode(UIHelper.LocalString($"收益数:{r.Key.Amount.ToString()}", $"Income Volume:{r.Key.Amount.ToString()}"));
                            //n4.NodeType = 4;
                            n4.Tag = act.ScriptHash;
                            var n5 = new TreeNode(UIHelper.LocalString($"收益时间:{r.Key.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}", $"Income Time:{r.Key.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}"));
                            //n5.NodeType = 5;
                            n5.Tag = act.ScriptHash;
                            n4.Nodes.Add(n5);
                            n3.Nodes.Add(n4);
                        }
                    }
                    gs = g.Where(m => m.Key.ParentOwner.Equals(act.ScriptHash));
                    if (gs.IsNotNullAndEmpty())
                    {
                        n3 = new TreeNode(UIHelper.LocalString($"叶子徽章收益记录", $"Leaf Badge Income Records"));
                        //n3.NodeType = 3;
                        n3.Tag = act.ScriptHash;
                        subNode2.Nodes.Add(n3);
                        foreach (var r in gs.OrderByDescending(m => m.Key.Timestamp))
                        {
                            var n4 = new TreeNode(UIHelper.LocalString($"收益数:{r.Key.Amount.ToString()}", $"Income Volume:{r.Key.Amount.ToString()}"));
                            //n4.NodeType = 4;
                            n4.Tag = act.ScriptHash;
                            var n5 = new TreeNode(UIHelper.LocalString($"收益时间:{r.Key.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}", $"Income Time:{r.Key.Timestamp.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss")}"));
                            //n5.NodeType = 5;
                            n5.Tag = act.ScriptHash;
                            n4.Nodes.Add(n5);
                            n5 = new TreeNode(UIHelper.LocalString($"收益地址:{r.Key.Owner.ToAddress()}", $"Income Address:{r.Key.Owner.ToAddress()}"));
                            //n5.NodeType = 5;
                            n5.Tag = act.ScriptHash;
                            n4.Nodes.Add(n5);
                            n3.Nodes.Add(n4);
                        }
                    }

                    this.tv_mutualWitnessRecords.Nodes.Add(node);
                }
            }
        }
        void showMutualLockMingingAssets()
        {
            this.tv_asset.Nodes.Clear();
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var lockMiningAssets = miningIndex.GetAll<MutualLockMiningAssetKey, MutualLockMiningAssetReply>(InvestBizPersistencePrefixes.MutualLockMiningAssetReply);
            if (lockMiningAssets.IsNotNullAndEmpty())
            {

                this.DoInvoke(() =>
                {
                    foreach (var p in lockMiningAssets.GroupBy(m => m.Key.AssetId))
                    {

                        var assetState = Blockchain.Singleton.Store.GetAssets().TryGet(p.Key);
                        var cap = assetState.Amount == -Fixed8.Satoshi ? "+\u221e" : assetState.Amount.ToString();
                        var havecap = assetState.Available.ToString();

                        var node = new TreeNode(UIHelper.LocalString($"资产Id:{p.Key.ToString()}", $"Asset Id:{p.Key.ToString()}"));
                        node.Tag = p.Key;
                        var subNode = new TreeNode(UIHelper.LocalString($"资产名:{assetState.GetName()}", $"Asset Name:{assetState.GetName()}"));
                        subNode.Tag = p.Key;
                        node.Nodes.Add(subNode);
                        subNode = new TreeNode(UIHelper.LocalString($"最大发行量:{cap}", $"Issue Cap:{cap}"));
                        subNode.Tag = p.Key;
                        node.Nodes.Add(subNode);
                        subNode = new TreeNode(UIHelper.LocalString($"已发行量:{havecap}", $"Issued:{havecap}"));
                        subNode.Tag = p.Key;
                        node.Nodes.Add(subNode);

                        foreach (var l in p.OrderByDescending(m => m.Key.IssueIndex))
                        {
                            if (Last.IsNull()) Last = l.Value;
                            subNode = new TreeNode(UIHelper.LocalString($"参数发布区块:{l.Key.IssueIndex}", $"Parameter issue height:{l.Key.IssueIndex}"));
                            subNode.Tag = p.Key;
                            node.Nodes.Add(subNode);

                            var subsubNode = new TreeNode(UIHelper.LocalString($"最少锁仓量:{l.Value.MinAmount}", $"Min Lock:{l.Value.MinAmount}"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                            subsubNode = new TreeNode(UIHelper.LocalString($"最大锁仓量:{l.Value.MaxAmount}", $"Max Lock:{l.Value.MaxAmount}"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                            subsubNode = new TreeNode(UIHelper.LocalString($"互证收益率:{l.Value.AirdropAmount}/100*100000", $"Dynamic Income Ratio:{l.Value.AirdropAmount}/100*100000"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                            subsubNode = new TreeNode(UIHelper.LocalString($"100000区块利率:{l.Value.Interest_100000}/1000", $"100000 blocks ratio:{l.Value.Interest_100000}/1000"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                            subsubNode = new TreeNode(UIHelper.LocalString($"500000区块利率:{l.Value.Interest_500000}/1000", $"500000 blocks ratio:{l.Value.Interest_500000}/1000"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                            subsubNode = new TreeNode(UIHelper.LocalString($"1000000区块利率:{l.Value.Interest_1000000}/1000", $"1000000 blocks ratio:{l.Value.Interest_1000000}/1000"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                            subsubNode = new TreeNode(UIHelper.LocalString($"2000000区块利率:{l.Value.Interest_2000000}/1000", $"2000000 blocks ratio:{l.Value.Interest_2000000}/1000"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                            subsubNode = new TreeNode(UIHelper.LocalString($"4000000区块利率:{l.Value.Interest_4000000}/1000", $"4000000 blocks ratio:{l.Value.Interest_4000000}/1000"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                            subsubNode = new TreeNode(UIHelper.LocalString($"6000000区块利率:{l.Value.Interest_6000000}/1000", $"6000000 blocks ratio:{l.Value.Interest_6000000}/1000"));
                            subsubNode.Tag = p.Key;
                            subNode.Nodes.Add(subsubNode);
                        }
                        node.Nodes.Add(subNode);
                        this.tv_asset.Nodes.Add(node);
                    }
                });

            }
        }
        public virtual void MenuPageSelected()
        {
            showMutualLockMingingAssets();
            showLockRecords();
            showSelfWitnessRecords();
            showMutualWitnessRecords();
        }

        void setColor(UIButton control, Color color)
        {
            control.FillColor = color;
            control.FillColor2 = color;
            control.FillHoverColor = color;
            control.FillPressColor = color;
            control.FillSelectedColor = color;
            control.RectColor = color;
            control.RectHoverColor = color;
            control.RectPressColor = color;
            control.RectSelectedColor = color;
        }



        private void OrderHistory_Initialize(object sender, EventArgs e)
        {

        }


    }
}
