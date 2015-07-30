using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#social_media_shares
    /// </summary>
    public class RbitSocialMediaShares : WepayRbitBase
    {
        [JsonProperty("facebook_shares")]
        public int facebook_shares { get; set; }

        [JsonProperty("twitter_shares")]
        public int twitter_shares { get; set; }
    }
}
