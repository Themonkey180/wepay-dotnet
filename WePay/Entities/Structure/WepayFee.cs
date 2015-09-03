using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayFee
    {
        [JsonProperty("app_fee")]
        public decimal? AppFee { get; set; }

        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }
    }
}
