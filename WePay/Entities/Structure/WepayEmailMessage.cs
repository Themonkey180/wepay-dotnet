using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayEmailMessage
    {
        [JsonProperty("to_payer")]
        public string ToPayer { get; set; }

        [JsonProperty("to_payee")]
        public string ToPayee { get; set; }
    }
}
