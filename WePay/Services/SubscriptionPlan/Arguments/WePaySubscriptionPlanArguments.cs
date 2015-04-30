using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_plan#lookup
    /// </summary>
    public class WePaySubscriptionPlanArguments
    {
        [JsonProperty("subscription_plan_id", Required = Required.Always)]
        public long SubscriptionPlanId { get; set; }
    }
}
