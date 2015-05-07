using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge#cancel
    /// </summary>
    public class WePaySubscriptionChargeRefundlArguments
    {
        [JsonProperty("subscription_charge_id", Required = Required.Always)]
        public long SubscriptionChargeId { get; set; }

        [JsonProperty("refund_reason")]
        public string Reason { get; set; }

        public string BatchUrl() { return "/subscription_charge/refund"; }
    }
}
