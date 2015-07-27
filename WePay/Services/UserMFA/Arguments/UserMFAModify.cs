using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.UserMFA
{
    public class UserMFAModify
    {
        [JsonProperty("mfa_id")]
        public long? MfaId { get; set; }

        public string BatchUrl() { return "/user/mfa/confirm"; }
    }
}
