using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge#refund
    /// </summary>
    public class WePaySubscriptionChargeState
    {
        [JsonProperty("subscription_plan_id")]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("subscription_id")]
        public long SubscriptionId { get; set; }

        [JsonProperty("subscription_charge_id")]
        public long SubscriptionChargeId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
