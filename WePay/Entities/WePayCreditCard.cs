using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/credit_card#lookup
    /// and
    /// https://www.wepay.com/developer/reference/credit_card#find
    /// </summary>
    public class WePayCreditCard : WepayBatch
    {
        [JsonProperty("credit_card_id")]
        public long CreditCardId { get; set; }

        [JsonProperty("credit_card_name")]
        public string CreditCardName { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("user_name")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
    }
}
