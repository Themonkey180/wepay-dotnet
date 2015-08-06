using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayAddress
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
