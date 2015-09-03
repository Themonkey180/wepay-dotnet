using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Checkout
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#create
    /// </summary>
    public class CheckoutCreateArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long? AccountId { get; set; }

        [JsonProperty("short_description", Required = Required.Always)]
        public string ShortDescription { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("amount", Required = Required.Always)]
        public decimal? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("long_description")]
        public string LongDescription { get; set; }

        [JsonProperty("email_message")]
        public WepayEmailMessage EmailMessage { get; set; }

        [JsonProperty("fee")]
        public WepayFee Fee { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("auto_capture")]
        public bool? AutoCapture { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("unique_id")]
        public string UniqueId { get; set; }

        [JsonProperty("hosted_checkout")]
        public WepayHostedCheckout HostedCheckout { get; set; }

        [JsonProperty("payment_method")]
        public WepayPaymentMethod PaymentMethod { get; set; }

        [JsonProperty("delivery_type")]
        public string DeliveryType { get; set; }

        [JsonProperty("transaction_rbits")]
        [JsonConverter(typeof(WePayRbitsConverter))]
        public WepayRbitStructure[] TransactionRbits { get; set; }

        [JsonProperty("payer_rbits")]
        [JsonConverter(typeof(WePayRbitsConverter))]
        public WepayRbitStructure[] PayerRbits { get; set; }

        public string BatchUrl() { return "/checkout/create"; }
    }
}
