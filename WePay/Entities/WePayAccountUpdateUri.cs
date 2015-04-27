using Newtonsoft.Json;

namespace WePay.Entities
{
    public class WePayDeletedAccount
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
