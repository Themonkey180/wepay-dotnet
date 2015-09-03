using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/user-mfa
    /// </summary>
    public class WepayMFAValidateCookie : WepayBatch
    {
        [JsonProperty("challenge_required")]
        public bool ChallengeRequired { get; set; }
    }
}

