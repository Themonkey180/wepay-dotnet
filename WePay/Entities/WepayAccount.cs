using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class WepayAccount
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("owner_user_id")]
        public long OwnerUserId { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("gaq_domains")]
        public string[] GoogleAnalyticsIDs { get; set; }

        [JsonProperty("theme_object")]
        public WepayTheme Theme { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("create_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime CreateTime { get; set; }

        [JsonProperty("balances")]
        public WepayAccountBalance[] Balances { get; set; }

        [JsonProperty("statuses")]
        public WepayStatuses[] Statuses { get; set; }

        [JsonProperty("action_reasons")]
        public string[] ActionReasons { get; set; }

        [JsonProperty("disabled_reasons")]
        public string[] DisabledReasons { get; set; }

        [JsonProperty("disablement_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime DisablementTime { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currencies")]
        public string[] Currencies { get; set; }
    }
}

