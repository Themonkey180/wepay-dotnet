using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayFeeSchedule
    {
        [JsonProperty("slot")]
        public long? slot { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
