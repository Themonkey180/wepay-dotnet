using Newtonsoft.Json;
using System;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account#find
    /// </summary>
    public class WePayFindAccountArguments
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("sort_order")]
        public string SortOrder { get; set; }

        public string BatchUrl() { return "/account/find"; }
    }
}
