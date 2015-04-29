using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#lookup
    /// and
    /// https://www.wepay.com/developer/reference/checkout#capture
    /// </summary>
    public class WePayCheckoutArguments
    {
        [JsonProperty("checkout_id", Required = Required.Always)]
        public long CheckoutId { get; set; }
    }
}
