using Newtonsoft.Json;

namespace WePay.Entities
{
    class WePayError : WepayBatch
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error_code")]
        public long ErrorCode { get; set; }
    }
}
