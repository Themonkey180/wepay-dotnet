using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/credit_card#lookup
    /// </summary>
    public class WePayCreditCardArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        [JsonProperty("credit_card_id", Required = Required.Always)]
        public long CreditCardId { get; set; }
    }
}
