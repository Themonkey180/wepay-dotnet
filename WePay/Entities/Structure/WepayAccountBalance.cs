using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Entities.Structure
{
    public class WepayAccountBalance
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("incoming_pending_amount")]
        public decimal IncomingPendingAmount { get; set; }

        [JsonProperty("outgoing_pending_amount")]
        public decimal OutgoingPendingAmount { get; set; }

        [JsonProperty("reserved_amount")]
        public decimal ReservedAmount { get; set; }

        [JsonProperty("disputed_amount")]
        public decimal DisputedAmount { get; set; }

        [JsonProperty("withdrawal_period")]
        public string WithdrawalPeriod { get; set; }

        [JsonProperty("withdrawal_type")]
        public string WithdrawalType { get; set; }

        [JsonProperty("withdrawal_next_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? WithdrawalNextTime { get; set; }

        [JsonProperty("withdrawal_bank_name")]
        public string WithdrawalBankName { get; set; }

    }
}
