using Newtonsoft.Json;

namespace WePay.Entities
{
    public class WePayAccountUpdateUri
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
