using Newtonsoft.Json;

namespace WePay.Account
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account-membership#Remove
    /// </summary>
    public class AccountMembershipRemoveArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long? AccountId { get; set; }

        [JsonProperty("user_id", Required = Required.Always)]
        public string UserId { get; set; }

        public string BatchUrl() { return "/account/membership/remove"; }
    }
}
