using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#cancel
    /// and
    /// https://www.wepay.com/developer/reference/checkout#refund
    /// and
    /// https://www.wepay.com/developer/reference/checkout#capture
    /// </summary>
    public class WePayCheckoutState : WepayBatch
    {
        [JsonProperty("checkout_id")]
        public long CheckoutId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
