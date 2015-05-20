using Newtonsoft.Json;
using System;
using WePay.Infrastructure;

namespace WePay.Checkout
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#find
    /// </summary>
    public class CheckoutFindArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("preapproval_id")]
        public long PreapprovalId { get; set; }

        [JsonProperty("start_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? StartTime { get; set; }

        [JsonProperty("end_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? EndTime { get; set; }

        [JsonProperty("sort_order")]
        public string SortOrder { get; set; }

        [JsonProperty("shipping_fee")]
        public decimal ShippingFee { get; set; }

        public string BatchUrl() { return "/checkout/find"; }
    }
}
