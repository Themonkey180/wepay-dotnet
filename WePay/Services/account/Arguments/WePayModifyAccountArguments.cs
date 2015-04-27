using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay
{
    public class WePayModifyAccountArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("image_uri")]
        public string ImageUri { get; set; }

        [JsonProperty("gaq_domains")]
        public string[] GoogleAnalyticsIDs { get; set; }

        [JsonProperty("theme_object")]
        public WepayTheme Theme { get; set; }

        [JsonProperty("callback_uri")]
        public WepayTheme CallbackUri { get; set; }
    }
}
