using Newtonsoft.Json;

namespace WePay
{
    public class WePayUserModifyArguments
    {
        [JsonProperty("callback_uri")]
        public long CallbackUri { get; set; }
    }
}
