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
    public class WePayCheckout
    {
        [JsonProperty("checkout_id")]
        public long CheckoutId { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("preapproval_id")]
        public long PreapprovalId { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime CreateTime { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("long_description")]
        public string LongDescription { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("shipping_fee")]
        public decimal ShippingFee { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("gross")]
        public decimal Gross { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("amount_refunded")]
        public decimal AmountRefunded { get; set; }

        [JsonProperty("amount_charged_back")]
        public decimal AmountChargedBack { get; set; }

        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("dispute_uri")]
        public string DisputeUri { get; set; }

        [JsonProperty("payer_email")]
        public string PayerEmail { get; set; }

        [JsonProperty("payer_name")]
        public string PayerName { get; set; }

        [JsonProperty("cancel_reason")]
        public string CancelReason { get; set; }

        [JsonProperty("refund_reason")]
        public string RefundReason { get; set; }

        [JsonProperty("auto_capture")]
        public bool AutoCapture { get; set; }

        [JsonProperty("require_shipping")]
        public bool RequireShipping { get; set; }

        [JsonProperty("shipping_address")]
        public WepayShippingAddress ShippingAddress { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }
    }
}
