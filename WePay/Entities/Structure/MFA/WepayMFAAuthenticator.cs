using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayMFAAuthenticator
    {
        [JsonProperty("@1x")]
        public string X1 { get; set; }

        [JsonProperty("@2x")]
        public string X2 { get; set; }

        [JsonProperty("svg")]
        public string SVG { get; set; }

        [JsonProperty("shared_secret")]
        public string SharedSecret { get; set; }
    }
}
