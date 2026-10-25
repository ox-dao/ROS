using OX.IO.Json;

namespace OX.Tablet.Config
{
    public class AccountNode
    {
        public string Address;
        public string CipherPriKey;
        public AccountNode(string address, string cipherPriKey)
        {
            this.Address = address;
            this.CipherPriKey = cipherPriKey;
        }
        public override bool Equals(object obj)
        {
            if (obj is AccountNode pn)
            {
                return pn.Address == this.Address;
            }
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return this.Address;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public static AccountNode FromJson(JObject json)
        {
            return new AccountNode(json["address"].AsString(), json["cipherprikey"]?.AsString());
        }
        public JObject ToJson()
        {
            JObject account = new JObject();
            account["address"] = this.Address;
            account["cipherprikey"] = this.CipherPriKey;
            return account;
        }
    }
}
