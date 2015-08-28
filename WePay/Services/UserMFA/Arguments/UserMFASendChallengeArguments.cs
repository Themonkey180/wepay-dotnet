using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.UserMFA
{
    public class UserMFASendChallengeArguments
    {
        [JsonProperty("mfa_id")]
        public long? MfaId { get; set; }

        [JsonProperty("force_voice")]
        public bool? ForceVoice { get; set; }

        public string BatchUrl() { return "/user/mfa/send_challenge"; }
    }
}
