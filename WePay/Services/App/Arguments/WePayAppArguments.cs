using Newtonsoft.Json;

namespace WePay
{
    public class WePayAppArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }
    }
}
