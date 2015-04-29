using Newtonsoft.Json;

namespace WePay
{
    public class WePayPreapprovalFindArguments
    {
        [JsonProperty("account_id")]
        public long account_id { get; set; }

        [JsonProperty("state")]
        public long state { get; set; }

        [JsonProperty("reference_id")]
        public long reference_id { get; set; }

        [JsonProperty("start")]
        public long start { get; set; }

        [JsonProperty("limit")]
        public long limit { get; set; }

        [JsonProperty("sort_order")]
        public long sort_order { get; set; }

        [JsonProperty("last_checkout_id")]
        public long last_checkout_id { get; set; }

        [JsonProperty("shipping_fee")]
        public long shipping_fee { get; set; }
    }
}
