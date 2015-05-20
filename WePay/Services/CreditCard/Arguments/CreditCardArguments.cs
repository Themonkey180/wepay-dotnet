using Newtonsoft.Json;
using WePay.Infrastructure;

namespace WePay.CreditCard
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/credit_card#lookup
    /// and
    /// https://www.wepay.com/developer/reference/credit_card#authorize
    /// and
    /// https://www.wepay.com/developer/reference/credit_card#delete
    /// </summary>
    public class CreditCardArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        [JsonProperty("credit_card_id", Required = Required.Always)]
        public long CreditCardId { get; set; }

        public string BatchUrl(BatchUrlType type)
        {
            switch (type)
            {
                case BatchUrlType.Delete:
                    return "/credit_card/delete";
                case BatchUrlType.Authorize:
                    return "/credit_card/authorize";
                default:
                    return "/credit_card";
            }
        }
    }
}
