using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#website_uri
    /// </summary>
    public class RbitWebsiteUri : WepayRbitBase
    {
        [JsonProperty("uri", Required = Required.Always)]
        public string Uri { get; set; }

    }
}
