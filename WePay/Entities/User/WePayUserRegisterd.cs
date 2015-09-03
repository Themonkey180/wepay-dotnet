using Newtonsoft.Json;

namespace WePay.Entities
{
    public class WePayUserRegisterd : WepayBatch
    {
        [JsonProperty("user_id")]
        public long UserID { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
    }
}
