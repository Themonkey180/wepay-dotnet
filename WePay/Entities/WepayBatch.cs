using Newtonsoft.Json;

namespace WePay.Entities
{
    public class WepayBatch
    {
        [JsonProperty("call")]
        public string BatchCall { get; set; }

        [JsonProperty("reference_id")]
        public string BatchReferenceId { get; set; }
    }
}
