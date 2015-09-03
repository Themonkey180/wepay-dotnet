using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayHostedCheckoutResponse
    {
        [JsonProperty("checkout_uri")]
        public string CheckoutUri { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("shipping_fee")]
        public decimal? ShippingFee { get; set; }

        [JsonProperty("require_shipping")]
        public bool? RequireShipping { get; set; }

        [JsonProperty("shipping_address")]
        public WepayShippingAddress ShippingAddress { get; set; }

        [JsonProperty("theme_object")]
        public WepayTheme Theme { get; set; }
    }
}
