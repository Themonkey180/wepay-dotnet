using Newtonsoft.Json;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Account
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account#create
    /// </summary>
    public class AccountCreateArgument
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("description", Required = Required.Always)]
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

        [JsonProperty("mcc")]
        public long? mcc { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currencies")]
        public string[] currencies { get; set; }

        [JsonProperty("rbits")]
        [JsonConverter(typeof(WePayRbitsConverter))]
        public WepayRbitStructure[] Rbits { get; set; }

        public string BatchUrl() { return "/account/create"; }
    }
}
