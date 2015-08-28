using Newtonsoft.Json;

namespace WePay.Subscription
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription#lookup
    /// </summary>
    public class SubscriptionArguments
    {
        [JsonProperty("subscription_id", Required = Required.Always)]
        public long? SubscriptionId { get; set; }

        public string BatchUrl() { return "/subscription"; }
    }
}
