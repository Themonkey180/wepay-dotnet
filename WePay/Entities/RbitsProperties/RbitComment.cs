using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#device_info
    /// </summary>
    public class RbitComment : WepayRbitBase
    {
        [JsonProperty("comment_text")]
        public string CommentText { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
