using Newtonsoft.Json;

namespace WePay.Batch
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/batch#create
    /// </summary>
    public class BatchCallsArguments
    {
        [JsonProperty("call", Required = Required.Always)]
        public string Call { get; set; }

        [JsonProperty("authorization")]
        public string Authorization { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("parameters")]
        public object Parameters { get; set; }
    }
}
