using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription#create
    /// </summary>
    public class WePaySubscriptionCreate
    {
        [JsonProperty("subscription_id")]
        public long SubscriptionId { get; set; }

        [JsonProperty("subscription_uri")]
        public string SubscriptionUri { get; set; }
    }
}
