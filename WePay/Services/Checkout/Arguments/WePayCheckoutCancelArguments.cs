using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#cancel
    /// </summary>
    public class WePayCheckoutCancelArguments
    {
        [JsonProperty("checkout_id", Required = Required.Always)]
        public long CheckoutId { get; set; }

        [JsonProperty("cancel_reason", Required = Required.Always)]
        public string CancelReason { get; set; }

        public string BatchUrl() { return "/checkout/cancel"; }
    }
}
