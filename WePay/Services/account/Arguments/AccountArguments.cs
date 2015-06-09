using Newtonsoft.Json;

namespace WePay.Account
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account#lookup
    /// </summary>
    public class AccountArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long? AccountId { get; set; }

        public string BatchUrl() { return "/account"; }
    }
}
