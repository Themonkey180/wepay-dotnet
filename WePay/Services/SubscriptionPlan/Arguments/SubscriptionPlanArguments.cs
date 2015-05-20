using Newtonsoft.Json;

namespace WePay.SubscriptionPlan
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan#lookup
    /// </summary>
    public class SubscriptionPlanArguments
    {
        [JsonProperty("subscription_plan_id", Required = Required.Always)]
        public long SubscriptionPlanId { get; set; }

        public string BatchUrl() { return "/subscription_plan"; }
    }
}
