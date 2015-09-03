using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan#delete
    /// </summary>
    public class WePaySubscriptionPlanState : WepayBatch
    {
        [JsonProperty("subscription_plan_id")]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
