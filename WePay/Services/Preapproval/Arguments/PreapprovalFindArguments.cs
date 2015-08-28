using Newtonsoft.Json;

namespace WePay.Preapproval
{
    public class PreapprovalFindArguments
    {
        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("state")]
        public long? State { get; set; }

        [JsonProperty("reference_id")]
        public long? ReferenceId { get; set; }

        [JsonProperty("start")]
        public long? Start { get; set; }

        [JsonProperty("limit")]
        public long? Limit { get; set; }

        [JsonProperty("sort_order")]
        public long? SortOrder { get; set; }

        [JsonProperty("last_checkout_id")]
        public long? LastCheckoutId { get; set; }

        [JsonProperty("shipping_fee")]
        public long? ShippingFee { get; set; }

        public string BatchUrl() { return "/preapproval/find"; }
    }
}
