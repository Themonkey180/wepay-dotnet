using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/account-membership
    /// </summary>
    public class WepayAccountMembership : WepayBatch
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("user_id")]
        public string user_id { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }
    }
}

