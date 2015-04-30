using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan#delete
    /// </summary>
    public class WePaySubscriptionPlanDeleteArguments
    {
        [JsonProperty("subscription_plan_id", Required = Required.Always)]
        public long SubscriptionPlanId { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }
    }
}
