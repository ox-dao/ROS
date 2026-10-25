using OX;
using OX.IO.Json;
using OX.Ledger;
using OX.Network.P2P.Payloads;
using OX.SmartContract;
using OX.Wallets.NEP6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace OX.Tablet.Config
{
    public class NodeConfig
    {
        static NodeConfig _instance;
        public static NodeConfig Instance
        {
            get
            {
                if (_instance.IsNull())
                    _instance = new NodeConfig();
                return _instance;
            }
        }
        const string basepath = "c:\\ox_rothschild\\";
        const string path = basepath + "rothschild.json";

        protected JObject Node;
        public string DefaultAccount = string.Empty;
        public string RunMode = string.Empty;
        public string Contacts = string.Empty;
        public string Email = string.Empty;
        public string MarkAutoCut = string.Empty;
        public int AutoDepositState = 0;
        public int AutoDepositRatio = 0;
        public int AutoWithdrawalRatio = 0;
        public int AutoDepositMax = 1000;
        public List<string> EthereumRPCNodes = new List<string>();
        public List<AccountNode> AccountNodes = new List<AccountNode>();
        public List<PeerNode> ExtSeedPeers = new List<PeerNode>();
        public List<PeerNode> CollectPeers = new List<PeerNode>();
        public List<AgentFeeNode> AgentFees = new List<AgentFeeNode>();
        public List<MarkPredictNode> MarkPredicts = new List<MarkPredictNode>();
        NodeConfig()
        {
            if (!System.IO.Directory.Exists(basepath))
                System.IO.Directory.CreateDirectory(basepath);
            if (!File.Exists(path))
            {
                Save();
            }
            Init();
        }
        void Init()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                Node = JObject.Parse(reader);
            }
            this.DefaultAccount = Node["defaultaccount"]?.AsString();
            this.RunMode = Node["runmode"]?.AsString();
            this.Contacts = Node["contacts"]?.AsString();
            this.Email = Node["email"]?.AsString();
            this.MarkAutoCut = Node["markautocut"]?.AsString();
           var strAutoDepositState= Node["autodepositstate"];
            if (strAutoDepositState.IsNotNull())
            {
                this.AutoDepositState = int.Parse(strAutoDepositState.AsString());
            }
            var strAutoDepositRatio = Node["autodepositratio"];
            if (strAutoDepositRatio.IsNotNull())
            {
                this.AutoDepositRatio = int.Parse(strAutoDepositRatio.AsString());
            }
            var strAutoWithdrawalRatio = Node["autowithdrawalratio"];
            if (strAutoWithdrawalRatio.IsNotNull())
            {
                this.AutoWithdrawalRatio = int.Parse(strAutoWithdrawalRatio.AsString());
            }
            var strAutoDepositMax = Node["autodepositmax"];
            if (strAutoDepositMax.IsNotNull())
            {
                this.AutoDepositMax = int.Parse(strAutoDepositMax.AsString());
            }
            var jAcounts = Node["accounts"];
            if (jAcounts != default)
            {
                this.AccountNodes = ((JArray)jAcounts).Select(p => AccountNode.FromJson(p)).ToList();
            }
            var jEthereumRPCNodes = Node["ethereumrpcnodes"];
            if (jEthereumRPCNodes != default)
            {
                this.EthereumRPCNodes = ((JArray)jEthereumRPCNodes).Select(p => p.AsString()).ToList();
            }
            
            var jExtSeedPeers = Node["extseedpeers"];
            if (jExtSeedPeers != default)
            {
                this.ExtSeedPeers = ((JArray)jExtSeedPeers).Select(p => PeerNode.FromJson(p)).ToList();
            }
            var jCollectPeers = Node["collectpeers"];
            if (jCollectPeers != default)
            {
                this.CollectPeers = ((JArray)jCollectPeers).Select(p => PeerNode.FromJson(p)).ToList();
            }
            var jAgentFees = Node["agentfees"];
            if (jAgentFees != default)
            {
                this.AgentFees = ((JArray)jAgentFees).Select(p => AgentFeeNode.FromJson(p)).ToList();
            }
            var jMarkPredicts = Node["markpredicts"];
            if (jMarkPredicts != default)
            {
                this.MarkPredicts = ((JArray)jMarkPredicts).Select(p => MarkPredictNode.FromJson(p)).ToList();
            }
            if (!this.EthereumRPCNodes.Any())
            {
                this.EthereumRPCNodes.Add("https://ethereum-rpc.publicnode.com");
                this.Save();
            }
        }

        public bool AutoCutMarkBet => this.MarkAutoCut?.ToLower() == "true";

        public virtual void Save()
        {
            Node = new JObject();
            Node["defaultaccount"] = this.DefaultAccount;
            Node["accounts"] = new JArray(AccountNodes.Select(p => p.ToJson()));
            Node["runmode"] = this.RunMode;
            Node["contacts"] = this.Contacts;
            Node["email"] = this.Email;
            Node["markautocut"] = this.MarkAutoCut;
            Node["autodepositstate"] = this.AutoDepositState.ToString();
            Node["autodepositratio"] = this.AutoDepositRatio.ToString();
            Node["autowithdrawalratio"] = this.AutoWithdrawalRatio.ToString();
            Node["autodepositmax"] = this.AutoDepositMax.ToString();
            Node["extseedpeers"] = new JArray(ExtSeedPeers.Select(p => p.ToJson()));
            Node["collectpeers"] = new JArray(CollectPeers.Select(p => p.ToJson()));
            Node["agentfees"] = new JArray(AgentFees.Select(p => p.ToJson()));
            Node["markpredicts"] = new JArray(MarkPredicts.Select(p => p.ToJson()));
            Node["ethereumrpcnodes"] = new JArray(EthereumRPCNodes.Select(p => (JObject)p));
            File.WriteAllText(path, Node.ToString());
        }

    }
}
