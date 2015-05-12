using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/app#modify
    /// </summary>
    public class WepayAppModify : WepayBatch
    {
        [JsonProperty("client_id")]
        public long ClientId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("theme_object")]
        public WepayTheme Theme { get; set; }

        [JsonProperty("gaq_domains")]
        public string[] GoogleAnalyticsIDs { get; set; }
    }
}

