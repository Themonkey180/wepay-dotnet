using Newtonsoft.Json;

namespace WePay
{
    public class WePayUserModifyArguments
    {
        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }

        public string BatchUrl() { return "/user/modify"; }
    }
}
