using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#auto_billing
    /// </summary>
    public class RbitAutoBilling : WepayRbitBase
    {
        [JsonProperty("autobill_setup_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? AutobillSetupTime { get; set; }

        [JsonProperty("payment_number")]
        public int PaymentNumber { get; set; }

        [JsonProperty("total_payments_scheduled")]
        public int TotalPaymentsScheduled { get; set; }

        [JsonProperty("payment_frequency")]
        public string PaymentFrequency { get; set; }

        [JsonProperty("setup_by")]
        public string SetupBy { get; set; }
    }
}
