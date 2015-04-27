using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay
{
    public class WePayGetUpdateUriAccountArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }
    }
}
