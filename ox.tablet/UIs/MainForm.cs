using Akka.Actor;
using Nethereum.Hex.HexConvertors.Extensions;
using OX.Ledger;
using OX.Mining;
using OX.Mining.OTC;
using OX.Network.P2P;
using OX.Network.P2P.Payloads;
using OX.Persistence;
using OX.SmartContract;
using OX.Tablet.Config;
using OX.Tablet.FlashMessages;
using OX.Tablet.UIs.OutChain;
using OX.Tablet.UIs.Rothschild;
using OX.Tablet.UIs.Setting;
using OX.Wallets;
using Sunny.UI;
using System.Data;
using System.Runtime.InteropServices;
namespace OX.Tablet
{
    public partial class MainForm : UIForm2
    {
        private uint PreBlockTime = 0;
        private uint LastIndexTimeStamp = 0;
        SyncLockForm SyncLockForm;
        public bool IsNormalSync
        {
            get
            {
                var stamp = ProtocolSettings.Default.SecondsPerBlock * 10 + 10;
                return PreBlockTime + stamp > DateTime.Now.ToTimestamp();
            }
        }


        BaseContentPage CurrentPage;
        public bool NeedExit = false;
        uint BalanceChangedLastIndex = 0;
        uint LastAutoDepositIndex = 0;
        static MainForm _instance;
        public static MainForm Instance
        {
            get
            {
                if (_instance.IsNull())
                    _instance = new MainForm();
                return _instance;
            }
        }
        PageTreeNode<FlashMessagePage> flashMessagePage = default;
        public MainForm()
        {
            InitializeComponent();
            InitIcon();
            TabletBlockHandler.BlockCompleted += TabletBlockHandler_BlockCompleted;
            TabletBlockHandler.SyncBlocksCompleted += TabletBlockHandler_SyncBlocksCompleted;
            TabletBlockHandler.FlashMessageCaptured += TabletBlockHandler_FlashMessageCaptured;
            AddClipboardFormatListener(this.Handle);
            this.SyncLockForm = new SyncLockForm(this);
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            BlockIndex.BlockIndexed += BlockIndex_BlockIndexed;
            this.Text = UIHelper.LocalString($"OX-DAO   {VersionHelper.Version}", $"OX-DAO   {VersionHelper.Version}");
            this.lb_msg.Text = UIHelper.LocalString("状态消息", "state message");
            TabletPluginHelper.LoadModules();
            TabletPluginHelper.LoadPlugins();
        }
        #region icon
        ImageList _treeImageList;
        int redIndex = 0;
        int grayIndex = 0;
        int orangeIndex = 0;
        void InitIcon()
        {
            // 1. 实例化ImageList
            _treeImageList = new ImageList
            {
                ImageSize = new Size(16, 16),       // TreeNode标准图标大小
                ColorDepth = ColorDepth.Depth32Bit  // 支持透明PNG/绘制的透明位图
            };

            // 2. 把ImageList绑定到TreeView（必须！不绑定图标不显示）
            this.MainMenu.ImageList = _treeImageList;

            // 3. 动态绘制图标，添加进ImageList
            grayIndex = AddCircleIcon(Color.Gray);    // 普通节点：灰圆
            redIndex = AddCircleIcon(Color.Red);      // 新消息：红圆点
            orangeIndex = AddCircleIcon(Color.Orange);  // 告警：橙圆
        }
        /// <summary>
        /// 绘制16x16透明背景圆点图标，添加到ImageList，返回索引
        /// </summary>
        private int AddCircleIcon(Color fillColor)
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using SolidBrush brush = new SolidBrush(fillColor);
                g.FillEllipse(brush, 4, 4, 8, 8);
            }
            // 添加图片到ImageList，返回图片索引
            return _treeImageList.Images.AddStrip(bmp);
        }

        /// <summary>
        /// 【核心方法】动态修改已有节点图标
        /// </summary>
        /// <param name="node">目标节点</param>
        /// <param name="imgIndex">ImageList内图片索引</param>
        private void SetNodeIcon(TreeNode node, int imageIndex)
        {
            if (node == null) return;
            //if(key.IsNullOrEmpty())
            //{
            //    node.im
            //}
            node.ImageIndex = imageIndex;
            node.SelectedImageIndex = imageIndex;
            ;
        }

        #endregion
        private void TabletBlockHandler_BlockCompleted(Block block)
        {
            if (IsDisposed) return;
            //PreBlockTime = block.Timestamp;
            foreach (var module in PageTreeNode.Modules.Values)
            {
                this.DoInvoke(() =>
                {
                    module.BeforeBlock(block);
                });
            }
            foreach (var module in PageTreeNode.Modules.Values)
            {
                this.DoInvoke(() =>
                {
                    module.OnBlock(block);
                });
            }
            foreach (var module in PageTreeNode.Modules.Values)
            {
                this.DoInvoke(() =>
                {
                    module.AfterBlock(block);
                });
            }
        }

        private void TabletBlockHandler_SyncBlocksCompleted(Block block)
        {
            PreBlockTime = block.Timestamp;
            if (SecureHelper.IsAuthenticated && NodeConfig.Instance.AutoDepositState != 0)
            {
                if (block.Index > LastAutoDepositIndex + 4 * 60)//最快1小时执行一次自动入金
                {

                    LastAutoDepositIndex = block.Index;
                }
            }
        }

        private void TabletBlockHandler_FlashMessageCaptured(FlashMessage message)
        {
            this.DoInvoke(() =>
            {
                var flashIndex = SecureHelper.BlockIndex.GetSubBlockIndex<FlashBlockIndex>();
                if (flashIndex.OnFlashMessage(message))
                {
                    if (this.flashMessagePage.IsNotNull())
                        this.SetNodeIcon(this.flashMessagePage, redIndex);
                }
            });

            foreach (var module in PageTreeNode.Modules.Values)
            {
                this.DoInvoke(() =>
                {
                    module.OnFlashMessage(message);
                });
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
        const int WM_CLIPBOARDUPDATE = 0x031D;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_CLIPBOARDUPDATE:
                    IDataObject iData = Clipboard.GetDataObject();
                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        var str = (string)iData.GetData(DataFormats.Text);
                        //new TextInput { Text = str, FromName = string.Empty }.TextHandle();
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void BlockIndex_BlockIndexed(uint Index, Block block)
        {
            var ts = System.DateTime.Now.ToTimestamp();
            if (ts > LastIndexTimeStamp + 5)
            {
                LastIndexTimeStamp = ts;
                this.DoInvoke(() =>
                {
                    this.doOnceDeposit();
                    this.lb_accountIndex.Text = Index.ToString();
                });
            }
        }

        private void uiTableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        void RefreshStatus(HeartBeatContext context)
        {
            this.DoInvoke(() =>
            {
                if (context.TimeStamp % 2 == 0 && !NeedExit)
                {
                    var msg = $"  {Blockchain.Singleton.Height}/{Blockchain.Singleton.HeaderHeight}";
                    var nodes = "  " + LocalNode.Singleton.GetRemoteNodes().Count().ToString() + UIHelper.LocalString(" 节点", " Nodes");
                    this.lb_blockchain_state.Text = msg;
                    this.lb_blockchain_nodes.Text = nodes;
                    if (context.IsNormalSync)
                    {
                        if (SyncLockForm.Visible)
                        {
                            SyncLockForm.Hide();
                            if (SecureHelper.NeedExit)
                            {
                                SyncLockForm.allowClose = true;
                                Application.Exit();
                            }
                        }
                    }
                    else
                    {
                        if (!SyncLockForm.Visible)
                            SyncLockForm.ShowDialog();
                        if (SyncLockForm.Visible)
                            SyncLockForm.SetProgress(msg);
                    }
                }
                if (context.Is10Minutes)
                {
                    var setting = NodeConfig.Instance;
                    List<PeerNode> collectSeeds = new List<PeerNode>();
                    foreach (var node in LocalNode.Singleton.GetRemoteNodes())
                    {
                        if (node.Listener.Port == Settings.Default.P2P.Port)
                        {
                            collectSeeds.Add(new PeerNode(node.Listener.Address.ToString(), node.Listener.Port.ToString()));
                        }
                    }
                    if (setting.CollectPeers.IsNotNullAndEmpty())
                    {
                        foreach (var seed in setting.CollectPeers)
                        {
                            if (!collectSeeds.Contains(seed))
                            {
                                collectSeeds.Add(seed);
                            }
                        }
                    }
                    setting.CollectPeers = collectSeeds.Take(20).ToList();
                    setting.Save();
                }
            });
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadOnePage();
            if (!SecureHelper.IsAuthenticated)
            {
                if (!SyncLockForm.Visible)
                {
                    var accounts = NodeConfig.Instance.AccountNodes;
                    if (accounts.IsNotNullAndEmpty())
                    {
                        new UnlockAccountForm(accounts, NodeConfig.Instance.DefaultAccount, () => ReloadPages()).ShowDialog();
                    }
                    else
                    {
                        new NewAccountForm().ShowDialog();
                    }
                }
            }
            var dmbs = FlashMessageHelper.GetDomain(SecureHelper.MasterAccount.ScriptHash);
            if (dmbs.IsNotNullAndEmpty())
            {
                this.Text = $" {UIHelper.LocalString("OX-DAO", "OX-DAO")} ({System.Text.Encoding.UTF8.GetString(dmbs)})   {VersionHelper.Version}";
            }
        }
        void ReloadOnePage()
        {
            this.MainMenu.Nodes.Clear();
            var settingNode = new PageTreeNode<SettingPage>(UIHelper.LocalString("设置", "Setting"));
            SecureHelper.RunModeChanged += Instance_RunModeChanged;
            this.MainMenu.Nodes.Add(settingNode);
        }
        void ReloadPages()
        {
            this.MainMenu.Nodes.Clear();
            //var flashMessagePage = new PageTreeNode<FlashSupportPage>(UIHelper.LocalString("闪信", "Flash"));
            //this.MainMenu.Nodes.Add(flashMessagePage);
            flashMessagePage = new PageTreeNode<FlashMessagePage>(UIHelper.LocalString("闪信", "Flash"));
            this.MainMenu.Nodes.Add(flashMessagePage);
            flashMessagePage.FocusPage(false);
          

            if (SecureHelper.IsSeniorRunMode)
            {
                var rothschildNode = new PageTreeNode<RothschildPage>(UIHelper.LocalString("玫瑰共识", "ROS consensus"));
                this.MainMenu.Nodes.Add(rothschildNode);
                var exchangeNode = new PageTreeNode<InChainPage>(UIHelper.LocalString("链内交易", "In Chain Swap"));
                this.MainMenu.Nodes.Add(exchangeNode);
                var crossSwap = new PageTreeNode<CrossChainPage>(UIHelper.LocalString("跨链兑换", "Cross Chain Swap"));
                this.MainMenu.Nodes.Add(crossSwap);
                var directSale = new PageTreeNode<DirectSale>(UIHelper.LocalString("链外买卖", "Out Chain Swap"));
                this.MainMenu.Nodes.Add(directSale);
                var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
                var validScope = miningIndex.GetValidScope();
                if (validScope.IsNotNullAndEmpty() && validScope != "0")
                {
                    var BitMarkSixNode = new PageTreeNode<MarkSixMainPage>(UIHelper.LocalString("六合彩", "Mark Six"));
                    this.MainMenu.Nodes.Add(BitMarkSixNode);
                }
                var EatSmallNode = new PageTreeNode<EatSmallMainPage>(UIHelper.LocalString("大吃小", "Eat Small"));
                this.MainMenu.Nodes.Add(EatSmallNode);
                var BuryNode = new PageTreeNode<BuryMainPage>(UIHelper.LocalString("爆雷", "Bury"));
                this.MainMenu.Nodes.Add(BuryNode);
               
            }
          

            var AssetNode = new PageTreeNode<AssetManagePage>(UIHelper.LocalString("资产", "Assets"));
            this.MainMenu.Nodes.Add(AssetNode);
            var settingNode = new PageTreeNode<SettingPage>(UIHelper.LocalString("设置", "Setting"));
            this.MainMenu.Nodes.Add(settingNode);
            foreach (var module in TabletModule.Modules)
            {
                var moduleUI = module.Value.Build();
                this.MainMenu.Nodes.Add(moduleUI);
                moduleUI.FocusPage(false);
            }
            SecureHelper.RunModeChanged += Instance_RunModeChanged;
        }

        private void Instance_RunModeChanged()
        {
            this.ReloadPages();
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void MainMenu_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (node is PageTreeNode ptn)
            {
                if (ptn is PageTreeNode<FlashMessagePage> flashNode)
                {
                    this.SetNodeIcon(flashNode,-1);
                }
                try
                {
                    CurrentPage = ptn.FocusPage(false);
                    this.ContentPanel.Controls.Clear();
                    this.ContentPanel.Controls.Add(CurrentPage);
                    CurrentPage.MenuPageSelected();
                    this.Invalidate();
                }
                catch
                {
                    CurrentPage = ptn.FocusPage(true);
                    this.ContentPanel.Controls.Clear();
                    this.ContentPanel.Controls.Add(CurrentPage);
                    CurrentPage.MenuPageSelected();
                    this.Invalidate();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HeartBeatContext context = new HeartBeatContext() { IsNormalSync = IsNormalSync };
            context.BalanceChangedLastIndex = SecureHelper.BalanceChangedLastIndex;
            if (SecureHelper.BalanceChangedLastIndex > this.BalanceChangedLastIndex)
            {
                this.BalanceChangedLastIndex = SecureHelper.BalanceChangedLastIndex;
                context.BalanceChanged = true;
            }
            RefreshStatus(context);
            foreach (var module in PageTreeNode.Modules.Values)
                module.HeartBeat(context);
            NoticeForm.Instance.HeartBeat(context);
        }


        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            NoticeForm.Instance.Hide();
        }
        #region 自动出入金
        void doOnceDeposit()
        {
            var usdtBalance = SecureHelper.GetExchangeAvailableBalance(OX.Mining.invest.USDT_Asset);
            if (usdtBalance >= Fixed8.One * 200)
            {
                var amt = usdtBalance - Fixed8.One * 100;
                this.doSale(amt);
            }
            this.doBuy();
        }
        async void doBuy()
        {
            var builder = EthereumTransactionHelper.GetEthereumBuilder();
            if (builder.IsNull()) return;
            var balanceResult = await builder.GetEthAndUSDTBalance();
            if (balanceResult.result)
            {
                var ether_balance = balanceResult.ether_balance;
                var usdt_balance = balanceResult.usdt_balance;
                if (SecureHelper.BlockIndex.IsNotNull() && ether_balance >= 0.01m && usdt_balance >= 100m)//少于0.01Ether，不入金，因为可能GAS费不够
                {
                    var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
                    foreach (var r in miningIndex.OTCDealers.Select(m => m.Value).Where(m => m.Setting.State == OTCStatus.Open && m.Setting.InRate <= NodeConfig.Instance.AutoDepositRatio).OrderBy(m => m.Setting.InRate))
                    {
                        var account = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(r.InPoolAddress);
                        if (account.IsNotNull() && account.Balances.TryGetValue(invest.USDT_Asset, out Fixed8 OTCDealerOXPoolBalance) && OTCDealerOXPoolBalance >= Fixed8.One * 100)
                        {
                            var poolBalance = (decimal)OTCDealerOXPoolBalance;
                            var AutoDepositMax = NodeConfig.Instance.AutoDepositMax;
                            var depositAmount = Math.Min((int)poolBalance, AutoDepositMax);
                            depositAmount = Math.Min((int)usdt_balance, depositAmount);
                            var remainder = depositAmount % 100;
                            depositAmount = depositAmount - remainder;
                            if (depositAmount > 0)
                            {
                                doOnceBuy(r, Fixed8.One * depositAmount);
                                break;
                            }
                        }
                    }
                }
            }
        }
        async void doOnceBuy(OTCDealerMerge dealerMerge, Fixed8 amt)
        {
            var st = dealerMerge.EthAddress.BuildOTCDealerTransaction();
            var OTCDealerOXPoolScriptHash = st.GetContract().ScriptHash;
            var ts = DateTime.Now.ToTimestamp();
            string stringToSign = $"{OTCDealerOXPoolScriptHash.ToAddress()}--{ts}";
            var marks = System.Text.Encoding.UTF8.GetBytes(stringToSign);
            var transferUsdtResult = await EthereumTransactionHelper.GetEthereumBuilder().TransferUSDTWithMark(dealerMerge.EthAddress, (decimal)amt, marks);
            if (transferUsdtResult.result)
            {
                var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
                miningIndex.SaveInGoldRecord(new InGoldRecord()
                {
                    EthTxId = UInt256.Parse(transferUsdtResult.txid),
                    State = InOutGoldStatus.Inited,
                    TimeStamp = DateTime.Now.ToTimestamp(),
                });
                if (OTCDealerHelper.DoSimpleDeposit(transferUsdtResult.txid, out var tx) && tx.IsNotNull())
                {
                    TabletBlockHandler.Instance.Tell(tx);
                    foreach (var coin in tx.Inputs)
                    {
                        SecureHelper.BlockIndex.UnconfirmCoins[coin] = Blockchain.Singleton.Height + 100;
                    }
                }
            }
        }
        void doSale(Fixed8 amount)
        {

            OTCSetting setting = new OTCSetting
            {
                InRate = (byte)NodeConfig.Instance.AutoWithdrawalRatio,
                OutRate = 0,
                EthAsset = 0,
                State = OTCStatus.Open
            };
            var tx = SecureHelper.ExchangeAccount.EthAddress.BuildOTCDealerTransaction(setting);
            var sh = tx.GetContract().ScriptHash;

            List<CoinReference> inputs = new List<CoinReference>();
            Dictionary<UInt160, Contract> contracts = new Dictionary<UInt160, Contract>();
            List<AvatarAccount> avatars = new List<AvatarAccount>();
            List<TransactionOutput> outputs = new List<TransactionOutput>();

            outputs.Add(new TransactionOutput
            {
                ScriptHash = sh,
                AssetId = invest.USDT_Asset,
                Value = amount
            });
            var utxos = SecureHelper.BlockIndex.GetExchangeUtxos(invest.USDT_Asset);
            if (utxos.IsNotNullAndEmpty())
            {
                List<string> excludedUtxoKeys = new List<string>();
                if (utxos.SortSearch(amount.GetInternalValue(), excludedUtxoKeys, out EthMapUTXO[] selectedUtxos, out long remainder))
                {
                    if (remainder > 0)
                        outputs.Add(new TransactionOutput { AssetId = invest.USDT_Asset, ScriptHash = SecureHelper.ExchangeAccount.MapAddress, Value = new Fixed8(remainder) });

                    foreach (var utxo in selectedUtxos)
                    {
                        inputs.Add(new CoinReference { PrevHash = utxo.TxId, PrevIndex = utxo.N });
                        EthereumMapTransaction emt = new EthereumMapTransaction { EthereumAddress = utxo.EthAddress, LockExpirationIndex = utxo.LockExpirationIndex };
                        var c = emt.GetContract();
                        var esh = c.ScriptHash;
                        if (!contracts.ContainsKey(esh))
                            contracts[esh] = c;
                    }

                    tx.Outputs = outputs.ToArray();
                    tx.Inputs = inputs.ToArray();
                    var stringToSign = tx.InputOutputHash.ToArray().ToHexString();
                    var signer = new Nethereum.Signer.EthereumMessageSigner();
                    var signatureData = signer.EncodeUTF8AndSign(tx.InputOutputHash.ToArray().ToHexString(), SecureHelper.ExchangeAccount.Key);
                    tx.Attributes = new TransactionAttribute[] { new TransactionAttribute { Usage = TransactionAttributeUsage.EthSignature, Data = System.Text.Encoding.UTF8.GetBytes(signatureData) },
                                                new TransactionAttribute { Usage = TransactionAttributeUsage.EthSignature, Data = signatureData.HexToByteArray() } };
                    foreach (var c in contracts)
                    {
                        avatars.Add(LockAssetHelper.CreateAccount(c.Value, SecureHelper.MasterAccount.Key));
                    }
                    tx = LockAssetHelper.Build(tx, avatars.ToArray());
                    if (tx.IsNotNull())
                    {
                        if (tx.Verify(Blockchain.Singleton.CurrentSnapshot, Blockchain.Singleton.MemPool.GetVerifiedTransactions()))
                        {
                            TabletBlockHandler.Instance.Tell(tx);
                            foreach (var coin in tx.Inputs)
                            {
                                SecureHelper.BlockIndex.UnconfirmCoins[coin] = Blockchain.Singleton.Height + 100;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
