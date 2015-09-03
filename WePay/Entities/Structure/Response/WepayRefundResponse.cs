using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayRefundResponse
    {
        [JsonProperty("amount_refunded")]
        public decimal? AmountRefunded { get; set; }

        [JsonProperty("refund_reason")]
        public string RefundReason { get; set; }
    }
}
