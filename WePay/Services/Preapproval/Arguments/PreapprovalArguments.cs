using Newtonsoft.Json;
using WePay.Infrastructure;

namespace WePay.Preapproval
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval#lookup
    /// and
    /// https://www.wepay.com/developer/reference/preapproval#cancel
    /// </summary>
    public class PreapprovalArguments
    {
        [JsonProperty("preapproval_id", Required = Required.Always)]
        public long? PreapprovalId { get; set; }

        public string BatchUrl(BatchUrlType type)
        {
            switch (type)
            {
                case BatchUrlType.Cancel:
                    return "/preapproval/cancel";
                default:
                    return "/preapproval";
            }
        }
    }
}
