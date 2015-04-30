using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal#lookup
    /// </summary>
    public class WePayWithdrawalArguments
    {
        [JsonProperty("withdrawal_id", Required = Required.Always)]
        public long WithdrawalId { get; set; }
    }
}
