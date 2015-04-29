using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay
{
    public class WePayAppModifyArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        [JsonProperty("theme_object")]
        public WepayTheme ClientSecret { get; set; }

        [JsonProperty("gaq_domains")]
        public string[] GoogleAnalyticsIDs { get; set; }
    }
}
