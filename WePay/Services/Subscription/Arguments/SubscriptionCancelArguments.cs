using Newtonsoft.Json;

namespace WePay.Subscription
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription#cancel
    /// </summary>
    public class SubscriptionCancelArguments
    {
        [JsonProperty("subscription_id", Required = Required.Always)]
        public long? SubscriptionId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        public string BatchUrl() { return "/subscription/cancel"; }
    }
}
