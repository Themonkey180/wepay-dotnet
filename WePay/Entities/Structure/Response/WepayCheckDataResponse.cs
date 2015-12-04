using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayCheckDataResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
