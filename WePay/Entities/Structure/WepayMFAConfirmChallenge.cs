using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayMFAConfirmChallenge
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("keep_session")]
        public bool KeepSession { get; set; }

        [JsonProperty("cookie_domain")]
        public string CookieDomain { get; set; }
    }
}
