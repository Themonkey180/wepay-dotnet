using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/credit_card#create
    /// and
    /// https://www.wepay.com/developer/reference/credit_card#authorize
    /// and
    /// https://www.wepay.com/developer/reference/credit_card#delete
    /// </summary>
    public class WePayCreditCardState
    {
        [JsonProperty("credit_card_id")]
        public long CreditCardId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
