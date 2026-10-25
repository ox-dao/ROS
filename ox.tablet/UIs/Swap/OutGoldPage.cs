using Akka.Actor;
using Akka.IO;
using Nethereum.ABI.CompilationMetadata;
using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.Ledger;
using OX.Mining;
using OX.Mining.OTC;
using OX.Network.P2P;
using OX.Network.P2P.Payloads;
using OX.Tablet;
using OX.Tablet.Config;
using OX.Wallets;
using Sunny.UI;
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
using static QRCoder.PayloadGenerator.SwissQrCode;
using OX.SmartContract;

namespace OX.Tablet.UIs.MarkSix
{
    public partial class OutGoldPage : UIPage, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));

        byte ratio_out = 5;
        byte ratio_in = 5;
        Fixed8 AvailableBalance = Fixed8.Zero;
        public OutGoldPage()
        {
            InitializeComponent();
            this.L1.Text = UIHelper.LocalString("出金参数","Withdrawal Parameters");
            this.L2.Text = UIHelper.LocalString("自动入金参数","Automatic Deposit Parameters");
            this.lb_amount.Text = UIHelper.LocalString("出金额:", "Sale Amount:");
            this.lb_usdt_balance.Text = UIHelper.LocalString("可用余额:", "Available Balance:");
            this.st_state.InActiveText = UIHelper.LocalString(OTCStatus.Redeem.StringValue(), OTCStatus.Redeem.EngStringValue());
            this.st_state.ActiveText = UIHelper.LocalString(OTCStatus.Open.StringValue(), OTCStatus.Open.EngStringValue());
            this.rbg_ratio_out.Text = UIHelper.LocalString($"出金手续费率", "Percentage of withdrawal procedures");
            this.btn_do_sale.Text = UIHelper.LocalString("提交出金状态", "Submit Withdrawal Status");
            this.rbg_ratio_out.SelectedIndex = ratio_out;

            this.st_autoDeposit.InActiveText = UIHelper.LocalString("自动入金已关闭", "Automatic Deposit is Closed");
            this.st_autoDeposit.ActiveText = UIHelper.LocalString("自动入金已开启", "Automatic Deposit is Opened");
            this.rbg_ratio_in.Text = UIHelper.LocalString($"最大自动入金手续费率", "Maximum automatic deposit fee rate");
            this.rbg_ratio_in.SelectedIndex = ratio_in;
            this.lb_max_deposit_amt.Text = UIHelper.LocalString("单次最大入金额:", "Max Deposit Amount:");
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
        public void OnClipboardString(ClipboardMessageType messageType, string msg) { }
        public virtual void MenuPageSelected()
        {
            RefreshState();
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

        bool firstRefreshState = false;

        void RefreshState()
        {
            this.lb_pool_address.Text = string.Empty;
            this.lb_pool_balance.Text = string.Empty;
            this.tb_amount.Text = "0";
            if (SecureHelper.IsAuthenticated)
            {
                var st = SecureHelper.ExchangeAccount.EthAddress.BuildOTCDealerTransaction();
                var sh = st.GetContract().ScriptHash;
                var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
                if (miningIndex.OTCDealers.TryGetValue(sh, out var dealer))
                {
                    this.st_state.Active = dealer.Setting.State == OTCStatus.Open;
                    if (dealer.Setting.State == OTCStatus.Open)
                    {
                        this.rbg_ratio_out.SelectedIndex = dealer.Setting.InRate;
                        NodeConfig.Instance.AutoWithdrawalRatio = dealer.Setting.InRate;
                        NodeConfig.Instance.Save();
                    }
                    else
                    {
                        this.rbg_ratio_out.SelectedIndex = NodeConfig.Instance.AutoWithdrawalRatio;
                    }
                }
                this.lb_pool_address.Text = UIHelper.LocalString($"交易池地址:{sh.ToAddress()}", $"OTC Pool Address:{sh.ToAddress()}");
                var account = Blockchain.Singleton.CurrentSnapshot.Accounts.TryGet(sh);
                if (account.IsNotNull())
                {
                    if (account.Balances.TryGetValue(invest.USDT_Asset, out Fixed8 balance))
                    {
                        this.lb_pool_balance.Text = UIHelper.LocalString($"交易池余额:{balance.ToString()}", $"OTC Pool Balance:{balance.ToString()}");
                    }
                }
                var balanceStates = SecureHelper.GetExchangeBalanceStates();
                if (balanceStates.TryGetValue(invest.USDT_Asset, out var balanceState))
                {
                    AvailableBalance = balanceState.AvailableBalance;
                    this.tb_balance.Text = AvailableBalance.ToString();
                }
                this.rbg_ratio_in.SelectedIndex = NodeConfig.Instance.AutoDepositRatio;
                var autoDepositState = NodeConfig.Instance.AutoDepositState != 0;
                this.st_autoDeposit.Active = autoDepositState;
                this.tb_max_deposit_amt.Text = NodeConfig.Instance.AutoDepositMax.ToString();
            }
            firstRefreshState = true;
        }


        private void OrderHistory_Initialize(object sender, EventArgs e)
        {

        }

        private void btn_do_sale_Click(object sender, EventArgs e)
        {
            if (Fixed8.TryParse(this.tb_amount.Text, out var amt) && amt > Fixed8.Zero && amt <= AvailableBalance)
            {
                OTCStatus state = this.st_state.Active ? OTCStatus.Open : OTCStatus.Redeem;

                OTCSetting setting = new OTCSetting
                {
                    InRate = this.ratio_out,
                    OutRate = 0,
                    EthAsset = 0,
                    State = state
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
                    Value = amt
                });
                var utxos = SecureHelper.BlockIndex.GetExchangeUtxos(invest.USDT_Asset);
                if (utxos.IsNotNullAndEmpty())
                {
                    List<string> excludedUtxoKeys = new List<string>();
                    if (utxos.SortSearch(amt.GetInternalValue(), excludedUtxoKeys, out EthMapUTXO[] selectedUtxos, out long remainder))
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
                                new WaitTxForm(tx, UIHelper.LocalString("等待出金确认...", "Waiting  confirm transaction"), state =>
                                {
                                    if (state)
                                    {
                                        this.RefreshState();
                                    }
                                }).ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void rbg_ratio_ratio_ValueChanged(object sender, int index, string text)
        {
            ratio_out = (byte)index;
        }

        private void uiTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            var v = this.uiTrackBar1.Value;
            var b = (decimal)AvailableBalance;
            var m = v * b / 100;
            this.tb_amount.Text = ((uint)m).ToString();
        }

        private void rbg_ratio_in_ValueChanged(object sender, int index, string text)
        {
            ratio_in = (byte)index;
        }

        private void st_autoDeposit_ValueChanged(object sender, bool value)
        {
            if (firstRefreshState)
            {
                NodeConfig.Instance.AutoWithdrawalRatio = this.rbg_ratio_out.SelectedIndex;
                NodeConfig.Instance.AutoDepositRatio = this.rbg_ratio_in.SelectedIndex;
                NodeConfig.Instance.AutoDepositState = value ? 1 : 0;
                NodeConfig.Instance.AutoDepositMax = int.Parse(this.tb_max_deposit_amt.Text);
                NodeConfig.Instance.Save();
            }
        }
    }
}
