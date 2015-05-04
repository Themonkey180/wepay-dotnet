using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/credit_card#create
    /// </summary>
    public class WePayCreditCardCreateArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("cc_number", Required = Required.Always)]
        public string CCnumber { get; set; }

        [JsonProperty("cvv", Required = Required.Always)]
        public int CVV { get; set; }

        [JsonProperty("expiration_month", Required = Required.Always)]
        public int ExpirationMonth { get; set; }

        [JsonProperty("expiration_year", Required = Required.Always)]
        public int ExpirationYear { get; set; }

        [JsonProperty("user_name", Required = Required.Always)]
        public string FullName { get; set; }

        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty("address", Required = Required.Always)]
        public WepayAddress Address { get; set; }

        [JsonProperty("original_ip")]
        public string OriginalIp { get; set; }

        [JsonProperty("original_device")]
        public string OriginalDevice { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
    }
}
