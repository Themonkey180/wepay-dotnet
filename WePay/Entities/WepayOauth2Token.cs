using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/oauth2
    /// </summary>
    public class WepayOauth2Token : WepayBatch
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
    }
}

