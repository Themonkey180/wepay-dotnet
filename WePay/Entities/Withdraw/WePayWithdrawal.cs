using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal#lookup
    /// </summary>
    public class WePayWithdrawal : WepayBatch
    {
        [JsonProperty("withdrawal_id")]
        public long WithdrawalId { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("bank_data")]
        public WepayBankDataResponse BankData { get; set; }

        [JsonProperty("check_data")]
        public WepayBankDataResponse CheckData { get; set; }

        [JsonProperty("withdrawal_data")]
        public WepayBankDataResponse WithdrawalData { get; set; }
    }
}
