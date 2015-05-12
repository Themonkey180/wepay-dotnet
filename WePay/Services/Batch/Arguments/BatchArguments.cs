using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/batch#create
    /// </summary>
    public class BatchArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        [JsonProperty("calls", Required = Required.Always)]
        public BatchCallsArguments[] Calls { get; set; }
    }
}
