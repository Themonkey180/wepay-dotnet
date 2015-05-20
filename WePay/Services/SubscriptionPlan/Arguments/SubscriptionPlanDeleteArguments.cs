using Newtonsoft.Json;

namespace WePay.SubscriptionPlan
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan#delete
    /// </summary>
    public class SubscriptionPlanDeleteArguments
    {
        [JsonProperty("subscription_plan_id", Required = Required.Always)]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }

        public string BatchUrl() { return "/subscription_plan/delete"; }
    }
}
