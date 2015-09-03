using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayFeeResponse
    {
        [JsonProperty("app_fee")]
        public decimal? AppFee { get; set; }

        [JsonProperty("processing_fee")]
        public decimal? ProcessingFee { get; set; }

        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }
    }
}
