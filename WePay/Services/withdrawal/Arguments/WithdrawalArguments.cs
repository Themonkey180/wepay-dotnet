using Newtonsoft.Json;

namespace WePay.Withdrawal
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal#lookup
    /// </summary>
    public class WithdrawalArguments
    {
        [JsonProperty("withdrawal_id", Required = Required.Always)]
        public long WithdrawalId { get; set; }

        public string BatchUrl() { return "/withdrawal"; }
    }
}
