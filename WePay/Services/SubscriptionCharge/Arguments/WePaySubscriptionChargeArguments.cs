using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge#lookup
    /// </summary>
    public class WePaySubscriptionChargeArguments
    {
        [JsonProperty("subscription_charge_id", Required = Required.Always)]
        public long subscriptionChargeId { get; set; }
    }
}
