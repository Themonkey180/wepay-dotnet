using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay
{
    public class WePayGetReserveDetailsAccountArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
