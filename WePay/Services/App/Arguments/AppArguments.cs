using Newtonsoft.Json;

namespace WePay.App
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/app#lookup
    /// </summary>
    public class AppArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        public string BatchUrl() { return "/app"; }
    }
}
