using System.Collections.Generic;
using System.Linq;
using OX.Tablet.Eths;

namespace OX.Tablet
{
    public static class EthereumTransactionHelper
    {
        public static EthereumTransactionBuilder GetEthereumBuilder()
        {
            List<string> nodes = new List<string>();
            var miningIndex = SecureHelper.BlockIndex.GetSubBlockIndex<MiningBlockIndex>();
            var settings = miningIndex.GetAllInvestSettings();
            var setting = settings.FirstOrDefault(m => Enumerable.SequenceEqual(m.Key, new[] { InvestSettingTypes.EthRPCNode }));
            if (!setting.Equals(new KeyValuePair<byte[], InvestSettingRecord>()))
            {
                if (setting.Value.Value.IsNotNullAndEmpty())
                {
                    foreach (var c in setting.Value.Value.Split(','))
                    {
                        nodes.Add(c);
                    }
                }
            }
            var nodeUrl = nodes.FirstOrDefault();
            if (nodeUrl.IsNullOrEmpty()) return default;
            var privateKey = SecureHelper.ExchangeAccount.Key.GetPrivateKey();
            return new Eths.EthereumTransactionBuilder(privateKey, nodeUrl);
        }
    }
}
