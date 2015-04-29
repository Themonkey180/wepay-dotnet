using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval#lookup
    /// </summary>
    public class WePayPreapproval
    {
        [JsonProperty("preapproval_id")]
        public long PreapprovalId { get; set; }

        [JsonProperty("preapproval_uri")]
        public string PreapprovalUri { get; set; }

        [JsonProperty("manage_uri")]
        public string ManageUri { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("long_description")]
        public string LongDescription { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("app_fee")]
        public decimal AppFee { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("frequency")]
        public long Frequency { get; set; }

        [JsonProperty("start_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime EndTime { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        [JsonProperty("shipping_address")]
        public WepayShippingAddress ShippingAddress { get; set; }

        [JsonProperty("shipping_fee")]
        public decimal ShippingFee { get; set; }

        [JsonProperty("auto_recur")]
        public bool AutoRecur { get; set; }

        [JsonProperty("payer_email")]
        public string PayerEmail { get; set; }

        [JsonProperty("frequency")]
        public long Frequency { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime CreateTime { get; set; }

        [JsonProperty("next_due_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime NextDueTime { get; set; }

        [JsonProperty("last_checkout_id")]
        public long LastCheckoutId { get; set; }

        [JsonProperty("last_checkout_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime LastCheckoutTime { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }
    }
}
