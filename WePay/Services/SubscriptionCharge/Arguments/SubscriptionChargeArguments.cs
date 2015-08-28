using Newtonsoft.Json;

namespace WePay.SubscriptionCharge
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge#lookup
    /// </summary>
    public class SubscriptionChargeArguments
    {
        [JsonProperty("subscription_charge_id", Required = Required.Always)]
        public long? subscriptionChargeId { get; set; }

        public string BatchUrl() { return "/subscription_charge"; }
    }
}
