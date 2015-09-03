using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayHostedCheckout
    {
        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("fallback_uri")]
        public string FallbackUri { get; set; }

        [JsonProperty("shipping_fee")]
        public decimal? ShippingFee { get; set; }

        [JsonProperty("require_shipping")]
        public bool? RequireShipping { get; set; }

        [JsonProperty("prefill_info")]
        public WepayPaymentsPrefillInfo PrefillInfo { get; set; }

        [JsonProperty("funding_sources")]
        public string[] FundingSources { get; set; }

        [JsonProperty("theme_object")]
        public WepayTheme Theme { get; set; }
    }
}
