using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayChargebackResponse
    {
        [JsonProperty("amount_charged_back")]
        public decimal? AmountChargedBack { get; set; }

        [JsonProperty("dispute_uri")]
        public string DisputeUri { get; set; }
    }
}
