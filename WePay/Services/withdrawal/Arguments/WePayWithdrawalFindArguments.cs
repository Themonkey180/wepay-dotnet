using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal#find
    /// </summary>
    public class WePayWithdrawalFindArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long Account_id { get; set; }

        [JsonProperty("limit")]
        public string limit { get; set; }

        [JsonProperty("start")]
        public string start { get; set; }

        [JsonProperty("sort_order")]
        public string sort_order { get; set; }

        [JsonProperty("state")]
        public string state { get; set; }

        public string BatchUrl() { return "/withdrawal/find"; }
    }
}
