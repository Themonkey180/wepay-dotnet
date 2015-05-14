using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/withdrawal#find
    /// </summary>
    public class WePayWithdrawalFindArguments
    {
        [JsonProperty("account_id", Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("limit")]
        public string Limit { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("sort_order")]
        public string SortOrder { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        public string BatchUrl() { return "/withdrawal/find"; }
    }
}
