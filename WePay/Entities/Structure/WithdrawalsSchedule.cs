using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Entities.Structure
{
    public class WithdrawalsSchedule
    {
        [JsonProperty("time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? WithdrawalTime { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
