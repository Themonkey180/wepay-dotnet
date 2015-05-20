using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.App
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/app#modify
    /// </summary>
    public class AppModifyArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        [JsonProperty("theme_object")]
        public WepayTheme Theme { get; set; }

        [JsonProperty("gaq_domains")]
        public string[] GoogleAnalyticsIDs { get; set; }

        public string BatchUrl() { return "/app/modify"; }
    }
}
