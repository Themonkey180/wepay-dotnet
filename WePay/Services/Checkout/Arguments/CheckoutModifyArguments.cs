using Newtonsoft.Json;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Checkout
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#modify
    /// </summary>
    public class CheckoutModifyArguments
    {
        [JsonProperty("checkout_id", Required = Required.Always)]
        public long? CheckoutId { get; set; }

        [JsonProperty("callback_uri")]
        public long? CallbackUri { get; set; }

        [JsonProperty("transaction_rbits")]
        [JsonConverter(typeof(WePayRbitsConverter))]
        public WepayRbitStructure[] TransactionRbits { get; set; }

        [JsonProperty("payer_rbits")]
        [JsonConverter(typeof(WePayRbitsConverter))]
        public WepayRbitStructure[] PayerRbits { get; set; }

        public string BatchUrl() { return "/checkout/modify"; }
    }
}
