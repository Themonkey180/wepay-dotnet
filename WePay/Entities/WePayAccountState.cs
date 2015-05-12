using Newtonsoft.Json;

namespace WePay.Entities
{
    public class WePayAccountState : WepayBatch
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
