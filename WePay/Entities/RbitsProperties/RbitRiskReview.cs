using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#risk_review
    /// </summary>
    public class RbitRiskReview : WepayRbitBase
    {
        [JsonProperty("risk_review_type", Required = Required.Always)]
        public string RiskReviewType { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("risk_score")]
        public long RiskScore { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }

        [JsonProperty("notes")]
        public RbitRiskReviewSteps[] Notes { get; set; }
    }
}
