using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#project
    /// </summary>
    public class RbitProject : WepayRbitBase
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("project_description")]
        public string ProjectDescription { get; set; }

        [JsonProperty("project_completion_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? ProjectCompletionTime { get; set; }

        [JsonProperty("billing_method")]
        public string BillingMethod { get; set; }

        [JsonProperty("project_hourly_estimate")]
        public float ProjectHourlyEstimate { get; set; }

        [JsonProperty("project_flat_amount_estimate")]
        public decimal ProjectFlatAmountEstimate { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
