using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayPaymentMethod
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("credit_card")]
        public WepayCreditCardInfo CreditCard { get; set; }

        [JsonProperty("preapproval")]
        public WepayPreapprovalInfo Preapproval { get; set; }
    }
}
