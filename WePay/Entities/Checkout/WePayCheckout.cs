using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#lookup
    /// and used in 
    /// https://www.wepay.com/developer/reference/checkout#find
    /// https://www.wepay.com/developer/reference/checkout#create
    /// https://www.wepay.com/developer/reference/checkout#modify
    /// </summary>
    public class WePayCheckout : WepayBatch
    {
        [JsonProperty("checkout_id")]
        public long? CheckoutId { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("long_description")]
        public string LongDescription { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        [JsonProperty("fee")]
        public WepayFeeResponse Fee { get; set; }

        [JsonProperty("gross")]
        public decimal? Gross { get; set; }

        [JsonProperty("auto_capture")]
        public bool? AutoCapture { get; set; }

        [JsonProperty("chargeback")]
        public WepayChargebackResponse Chargeback { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("refund")]
        public WepayRefundResponse Refund { get; set; }

        [JsonProperty("payment_method")]
        public WepayPaymentMethod PaymentMethod { get; set; }

        [JsonProperty("hosted_checkout")]
        public WepayHostedCheckoutResponse HostedCheckout { get; set; }

        [JsonProperty("payer")]
        public WepayPayerResponse Payer { get; set; }

        [JsonProperty("delivery_type")]
        public string DeliveryType { get; set; }
    }
}
