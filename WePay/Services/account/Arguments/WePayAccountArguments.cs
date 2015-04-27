using Newtonsoft.Json;

namespace WePay
{
    public class WePayAccountArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long AccountId { get; set; }
    }
}
