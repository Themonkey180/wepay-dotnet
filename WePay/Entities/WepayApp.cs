using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/app#lookup
    /// </summary>
    public class WepayApp : WepayBatch
    {
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }

        [JsonProperty("client_id")]
        public long ClientId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("theme_object")]
        public WepayTheme Theme { get; set; }

        [JsonProperty("gaq_domains")]
        public string[] GoogleAnalyticsIDs { get; set; }
    }
}

