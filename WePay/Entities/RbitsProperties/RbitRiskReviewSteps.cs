using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#risk_review_steps
    /// </summary>
    public class RbitRiskReviewSteps : WepayRbitBase
    {
        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("person_creating", Required = Required.Always)]
        public string PersonCreating { get; set; }

        [JsonProperty("note", Required = Required.Always)]
        public string Note { get; set; }
    }
}
