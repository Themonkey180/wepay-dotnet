using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#business_legal
    /// </summary>
    public class RbitBusinessLegal : WepayRbitBase
    {
        [JsonProperty("business_type", Required = Required.Always)]
        public string BusinessType { get; set; }

        [JsonProperty("country_of_incorporation")]
        public string CountryOfIncorporation { get; set; }

        [JsonProperty("state_of_incorporation")]
        public string StateOfIncorporation { get; set; }

        [JsonProperty("incorporation_uris")]
        public RbitWebsiteUri[] IncorporationUris { get; set; }
    }
}
