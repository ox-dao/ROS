using OX.IO.Json;
using Sunny.UI;
using System;

namespace OX.Tablet.Config
{
    public class MarkPredictNode
    {
        public string PredictId;
        public string LatestDate;
        public MarkPredictNode(string predictid,string LatestDate)
        {
            this.PredictId = predictid;
            this.LatestDate = LatestDate;
        }
        public override bool Equals(object obj)
        {
            if (obj is MarkPredictNode pn)
            {
                return pn.PredictId == this.PredictId;
            }
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"{PredictId}:{LatestDate}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public static MarkPredictNode FromJson(JObject json)
        {
            return new MarkPredictNode(json["predictid"].AsString(), json["latestdate"]?.AsString());
        }
        public JObject ToJson()
        {
            JObject account = new JObject();
            account["predictid"] = this.PredictId;
            account["latestdate"] = this.LatestDate;
            return account;
        }
    }
}
