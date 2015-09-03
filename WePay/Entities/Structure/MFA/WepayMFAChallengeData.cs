using Newtonsoft.Json;
using System.Collections.Generic;

namespace WePay.Entities.Structure
{
    public class WepayMFAChallengeData
    {
        [JsonProperty("voice")]
        public string Voice { get; set; }

        [JsonProperty("sms")]
        public string SMS { get; set; }

        [JsonProperty("authenticator")]
        public WepayMFAAuthenticator Authenticator { get; set; }

        [JsonProperty("backup")]
        public IList<string> Backup { get; set; }
    }
}
