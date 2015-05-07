using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#modify
    /// </summary>
    public class WePayCheckoutModifyArguments
    {
        [JsonProperty("checkout_id", Required = Required.Always)]
        public long CheckoutId { get; set; }

        [JsonProperty("callback_uri")]
        public long CallbackUri { get; set; }

        public string BatchUrl() { return "/checkout/modify"; }
    }
}
