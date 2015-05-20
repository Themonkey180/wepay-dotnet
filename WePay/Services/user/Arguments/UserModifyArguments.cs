using Newtonsoft.Json;

namespace WePay.User
{
    public class UserModifyArguments
    {
        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        public string BatchUrl() { return "/user/modify"; }
    }
}
