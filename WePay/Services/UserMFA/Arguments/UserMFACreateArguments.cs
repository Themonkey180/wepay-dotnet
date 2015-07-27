using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.UserMFA
{
    public class UserMFACreateArguments
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("setup_data")]
        public WepayMFASetupData SetupData { get; set; }

        [JsonProperty("cookie")]
        public string Cookie { get; set; }

        public string BatchUrl() { return "/user/mfa/create"; }
    }
}
