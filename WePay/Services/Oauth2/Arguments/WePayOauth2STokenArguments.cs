using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/oauth2#token
    /// </summary>
    public class WePayOauth2STokenArguments
    {
        [JsonProperty("client_id", Required = Required.Always)]
        public long? ClientId { get; set; }

        [JsonProperty("redirect_uri", Required = Required.Always)]
        public string RedirectUri { get; set; }

        [JsonProperty("client_secret", Required = Required.Always)]
        public string ClientSecret { get; set; }

        [JsonProperty("code", Required = Required.Always)]
        public string Code { get; set; }

        [JsonProperty("callback_uri")]
        public string CallbackUri { get; set; }
    }
}
