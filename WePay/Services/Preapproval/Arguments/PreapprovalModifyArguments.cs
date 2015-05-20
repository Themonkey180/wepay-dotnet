using Newtonsoft.Json;

namespace WePay.Preapproval
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval#modify
    /// </summary>
    public class PreapprovalModifyArguments
    {
        [JsonProperty("preapproval_id", Required = Required.Always)]
        public long PreapprovalId { get; set; }

        [JsonProperty("callback_uri")]
        public string callback_uri { get; set; }

        public string BatchUrl() { return "/preapproval/modify"; }
    }
}
