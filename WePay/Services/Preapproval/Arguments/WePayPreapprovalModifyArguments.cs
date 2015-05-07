using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval#modify
    /// </summary>
    public class WePayPreapprovalModifyArguments
    {
        [JsonProperty("preapproval_id", Required = Required.Always)]
        public long PreapprovalId { get; set; }

        [JsonProperty("callback_uri")]
        public string callback_uri { get; set; }

        public string BatchUrl() { return "/preapproval/modify"; }
    }
}
