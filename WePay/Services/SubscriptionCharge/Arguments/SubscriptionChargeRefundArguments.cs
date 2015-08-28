using Newtonsoft.Json;

namespace WePay.SubscriptionCharge
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge#cancel
    /// </summary>
    public class SubscriptionChargeRefundArguments
    {
        [JsonProperty("subscription_charge_id", Required = Required.Always)]
        public long? SubscriptionChargeId { get; set; }

        [JsonProperty("refund_reason")]
        public string Reason { get; set; }

        public string BatchUrl() { return "/subscription_charge/refund"; }
    }
}
