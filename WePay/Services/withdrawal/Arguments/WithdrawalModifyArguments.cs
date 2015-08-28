using Newtonsoft.Json;

namespace WePay.Withdrawal
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal#modify
    /// </summary>
    public class WithdrawalModifyArguments
    {
        [JsonProperty("withdrawal_id", Required = Required.Always)]
        public long? WithdrawalId { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        public string BatchUrl() { return "/withdrawal/modify"; }
    }
}
