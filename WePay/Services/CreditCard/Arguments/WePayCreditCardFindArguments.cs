using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/credit_card#find
    /// </summary>
    public class WePayCreditCardFindArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("limit")]
        public string limit { get; set; }

        [JsonProperty("start")]
        public string start { get; set; }

        [JsonProperty("sort_order")]
        public string sort_order { get; set; }
    }
}
