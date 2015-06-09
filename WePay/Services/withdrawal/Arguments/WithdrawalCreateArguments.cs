using Newtonsoft.Json;

namespace WePay.Withdrawal
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal#create
    /// </summary>
    public class WithdrawalCreateArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long? AccountId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("fallback_uri")]
        public string FallbackUri { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        public string BatchUrl() { return "/withdrawal/create"; }
    }
}
