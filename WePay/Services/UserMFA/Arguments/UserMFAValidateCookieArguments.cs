using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.UserMFA
{
    public class UserMFAValidateCookieArguments
    {
        [JsonProperty("mfa_id")]
        public long? MfaId { get; set; }

        [JsonProperty("cookie")]
        public string Cookie { get; set; }

        public string BatchUrl() { return "/user/mfa/validate_cookie"; }
    }
}
