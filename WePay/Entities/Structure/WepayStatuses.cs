using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayStatuses
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("incoming_payments_status")]
        public string IncomingPaymentsStatus { get; set; }

        [JsonProperty("outgoing_payments_status")]
        public string OutgoingPaymentsStatus { get; set; }
    }
}
