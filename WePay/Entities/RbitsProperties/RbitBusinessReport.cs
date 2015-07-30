using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#business_report
    /// </summary>
    public class RbitBusinessReport : WepayRbitBase
    {
        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        [JsonProperty("report_uri")]
        public string ReportUri { get; set; }
    }
}
