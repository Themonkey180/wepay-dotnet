using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/user-mfa
    /// </summary>
    public class WepayMFAFind : WepayBatch
    {
        [JsonProperty("mfa")]
        public WepayMFA[] MFA { get; set; }
    }
}

