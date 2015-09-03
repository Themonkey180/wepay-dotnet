using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/structures#payer
    /// </summary>
    public class WepayPayerResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("home_address")]
        public string HomeAddress { get; set; }
    }
}
