using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.Entities
{
    public class WepayAccountReserveDetails : WepayBatch
    {
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("reserved_amount")]
        public decimal ReservedAmount { get; set; }

        [JsonProperty("withdrawals_schedule")]
        public WithdrawalsSchedule[] WithdrawalSchedule { get; set; }
    }
}
