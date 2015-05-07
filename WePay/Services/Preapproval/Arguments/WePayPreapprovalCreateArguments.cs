using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval#create
    /// </summary>
    public class WePayPreapprovalCreateArguments
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("short_description", Required = Required.Always)]
        public string ShortDescription { get; set; }

        [JsonProperty("period", Required = Required.Always)]
        public string Period { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("fallback_uri")]
        public string FallbackUri { get; set; }

        [JsonProperty("require_shipping")]
        public bool RequireShipping { get; set; }

        [JsonProperty("shipping_fee")]
        public decimal ShippingFee { get; set; }

        [JsonProperty("payer_email_message")]
        public string PayerEmailMessage { get; set; }

        [JsonProperty("long_description")]
        public string LongDescription { get; set; }

        [JsonProperty("frequency")]
        public long Frequency { get; set; }

        [JsonProperty("start_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? StartTime { get; set; }

        [JsonProperty("end_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? EndTime { get; set; }

        [JsonProperty("auto_capture")]
        public bool AutoCapture { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("prefill_info")]
        public WepayPrefillInfo PrefillInfo { get; set; }

        [JsonProperty("funding_sources")]
        public string FundingSources { get; set; }

        [JsonProperty("payment_method_id")]
        public long PaymentMethodId { get; set; }

        [JsonProperty("payment_method_type")]
        public string PaymentMethodType { get; set; }

        public string BatchUrl() { return "/preapproval/create"; }
    }
}
