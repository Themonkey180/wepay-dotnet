using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.UserMFA
{
    public class UserMFAConfirmArguments
    {
        [JsonProperty("mfa_id")]
        public long? MfaId { get; set; }

        [JsonProperty("challenge")]
        public WepayMFAConfirmChallenge Challenge { get; set; }

        public string BatchUrl() { return "/user/mfa/confirm"; }
    }
}
