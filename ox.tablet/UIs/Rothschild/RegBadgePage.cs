using Akka.Actor;
using Akka.IO;
using Org.BouncyCastle.Bcpg;
using OX.BMS;
using OX.DirectSales;
using OX.Ledger;
using OX.Mining;
using OX.Network.P2P.Payloads;
using OX.Tablet;
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
using static QRCoder.PayloadGenerator.SwissQrCode;

namespace OX.Tablet.UIs.Rothschild
{
    public partial class RegBadgePage : UIPage, IBlockchainHandler
    {
        public static readonly Color FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));


        public RegBadgePage()
        {
            InitializeComponent();
            this.lb_seedBadge.Text = UIHelper.LocalString("种子徽章见证地址:", "Seed Badge Witness Address:");
            this.cb_rothBadge.Text = UIHelper.LocalString("注册骑士徽章", "Register Knight Badge");
            this.bt_reg.Text = UIHelper.LocalString("注册", "Register");
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

        public virtual void MenuPageSelected()
        {

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

        private void cb_rothBadge_CheckedChanged(object sender, EventArgs e)
        {
            this.tb_seedBadge.ReadOnly = false;
            this.tb_seedBadge.Text = string.Empty;
            if (this.cb_rothBadge.Checked)
            {
                this.tb_seedBadge.ReadOnly = true;
                this.tb_seedBadge.Text = MutualLockMiningHelper.GenesisSeed().ToAddress();
            }
        }

        private void bt_reg_Click(object sender, EventArgs e)
        {
            var tx = BuildTx();
            if (tx.IsNotNull() && tx.Verify(Blockchain.Singleton.CurrentSnapshot, Blockchain.Singleton.MemPool.GetVerifiedTransactions()))
            {
                TabletBlockHandler.Instance.Tell(tx);
                foreach (var coin in tx.Inputs)
                {
                    SecureHelper.BlockIndex.UnconfirmCoins[coin] = Blockchain.Singleton.Height + 100;
                }
                new WaitTxForm(tx, UIHelper.LocalString("等待交易确认...", "Waiting  confirm transaction")).ShowDialog();
            }
        }
        public Transaction BuildTx()
        {
            Transaction tx = default;
            Fixed8 amount = Fixed8.One * 100;
            UInt160 witnessAddress = default;
            try
            {
                witnessAddress = this.tb_seedBadge.Text.ToScriptHash();
            }
            catch
            {
                return default;
            }
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            if (miningIndex.MutualLockNodes.TryGetValue(witnessAddress, out _)|| witnessAddress== MutualLockMiningHelper.GenesisSeed())
            {
                if (amount <= SecureHelper.GetMasterAvailableBalance(Blockchain.OXC))
                {
                    List<CoinReference> inputs = new List<CoinReference>();
                    List<AvatarAccount> avatars = new List<AvatarAccount>();
                    List<TransactionOutput> outputs = new List<TransactionOutput>();
                    TransactionOutput output = new TransactionOutput { AssetId = Blockchain.OXC, ScriptHash = witnessAddress, Value = amount };
                    outputs.Add(output);
                    var utxos = SecureHelper.BlockIndex.GetMasterUtxos(Blockchain.OXC);
                    if (utxos.IsNotNullAndEmpty())
                    {
                        List<string> excludedUtxoKeys = new List<string>();
                        if (utxos.SortSearch(output.Value.GetInternalValue(), excludedUtxoKeys, out MasterUTXO[] selectedUtxos, out long remainder))
                        {
                            if (remainder > 0)
                                outputs.Add(new TransactionOutput { AssetId = Blockchain.OXC, ScriptHash = SecureHelper.MasterAccount.ScriptHash, Value = new Fixed8(remainder) });

                            foreach (var utxo in selectedUtxos)
                            {
                                inputs.Add(new CoinReference { PrevHash = utxo.TxId, PrevIndex = utxo.N });

                                if (utxo.IsLockCoin)
                                {
                                    LockAssetTransaction lat = new LockAssetTransaction { IsTimeLock = utxo.IsTimeLock, LockExpiration = utxo.LockExpirationIndex, Recipient = SecureHelper.MasterAccount.Key.PublicKey };
                                    avatars.Add(LockAssetHelper.CreateAccount(lat.GetContract(), SecureHelper.MasterAccount.Key));
                                }
                                else
                                {
                                    avatars.Add(LockAssetHelper.CreateAccount(SecureHelper.MasterAccount.Contract, SecureHelper.MasterAccount.Key));
                                }
                            }
                            tx = new ContractTransaction
                            {
                                Attributes = new TransactionAttribute[0],
                                Outputs = outputs.ToArray(),
                                Inputs = inputs.ToArray(),
                                Witnesses = new Witness[0]
                            };
                            tx = LockAssetHelper.Build(tx, avatars.ToArray());
                        }
                    }
                }
            }
            return tx;
        }
    }
}
