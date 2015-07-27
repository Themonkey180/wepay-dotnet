using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.UserMFA
{
    public class UserMFAFind
    {
        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        public string BatchUrl() { return "/user/mfa/confirm"; }
    }
}
