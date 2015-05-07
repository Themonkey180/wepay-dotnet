using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge#lookup
    /// </summary>
    public class WePaySubscriptionCharge
    {
        [JsonProperty("subscription_charge_id")]
        public long SubscriptionChargeId { get; set; }

        [JsonProperty("subscription_plan_id")]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("subscription_id")]
        public long SubscriptionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("gross")]
        public decimal Gross { get; set; }

        [JsonProperty("amount_refunded")]
        public decimal AmountRefunded { get; set; }

        [JsonProperty("amount_charged_back")]
        public decimal AmountChargedBack { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("end_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? EndTime { get; set; }

        [JsonProperty("prorate_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? ProrateTime { get; set; }
    }
}
