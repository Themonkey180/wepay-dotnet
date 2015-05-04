using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription#find
    /// </summary>
    public class WePaySubscriptionFindArguments
    {
        [JsonProperty("subscription_plan_id")]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("start")]
        public long start { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("start_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime EndTime { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
    }
}
