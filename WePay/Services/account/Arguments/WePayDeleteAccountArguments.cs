using Newtonsoft.Json;

namespace WePay
{
    public class WePayDeleteAccountArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
