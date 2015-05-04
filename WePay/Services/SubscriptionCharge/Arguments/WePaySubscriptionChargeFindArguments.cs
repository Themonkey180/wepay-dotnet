using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge#find
    /// </summary>
    public class WePaySubscriptionChargeFindArguments
    {
        [JsonProperty("subscription_id", Required = Required.Always)]
        public long SubscriptionId { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("start_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime EndTime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
