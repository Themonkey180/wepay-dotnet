using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/user-mfa
    /// </summary>
    public class WepayMFACreate : WepayBatch
    {
        [JsonProperty("mfa_id")]
        public long MfaId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("factor_label")]
        public string FactorLabel { get; set; }

        [JsonProperty("challenge_data")]
        public WepayMFAChallengeData ChallengeData { get; set; }
    }
}

