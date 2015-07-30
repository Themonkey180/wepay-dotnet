using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#partner_service
    /// </summary>
    public class RbitPartnerService : WepayRbitBase
    {
        [JsonProperty("service_name", Required = Required.Always)]
        public string ServiceName { get; set; }

        [JsonProperty("service_monthly_cost")]
        public decimal ServiceMonthlyCost { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
