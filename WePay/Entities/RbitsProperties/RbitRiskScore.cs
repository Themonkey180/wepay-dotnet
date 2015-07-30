using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#device_info
    /// </summary>
    public class RbitRiskScore : WepayRbitBase
    {
        [JsonProperty("score_int")]
        public long ScoreInt { get; set; }

        [JsonProperty("score_float")]
        public double ScoreFloat { get; set; }

        [JsonProperty("score_string")]
        public string ScoreString { get; set; }

        [JsonProperty("lowest_risk_score")]
        public string LowestRiskScore { get; set; }
    }
}
