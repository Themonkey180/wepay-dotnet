using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.Account
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account#reserve
    /// </summary>
    public class AccountGetReserveDetailsArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long? AccountId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        public string BatchUrl() { return "/account/get_reserve_details"; }
    }
}
