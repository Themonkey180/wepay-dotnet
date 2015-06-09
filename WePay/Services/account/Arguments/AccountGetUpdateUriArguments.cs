using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.Account
{
    public class AccountGetUpdateUriArguments
    {
        /// <summary>
        /// https://www.wepay.com/developer/reference/account#update_uri
        /// </summary>
        [JsonProperty("account_id", Required = Required.Always)]
        public long? AccountId { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        public string BatchUrl() { return "/account/get_update_uri"; }
    }
}
