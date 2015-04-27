using Newtonsoft.Json;
using System;

namespace WePay
{
    public class WePayFindAccountArguments
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("sort_order")]
        public string SortOrder { get; set; }
    }
}
