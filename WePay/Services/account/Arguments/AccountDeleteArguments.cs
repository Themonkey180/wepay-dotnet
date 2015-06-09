using Newtonsoft.Json;

namespace WePay.Account
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account#delete
    /// </summary>
    public class AccountDeleteArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long? AccountId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        public string BatchUrl() { return "/account/delete"; }
    }
}
