using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#revenue
    /// </summary>
    public class RbitRevenue : WepayRbitBase
    {
        [JsonProperty("revenue", Required = Required.Always)]
        public long? revenue { get; set; }

        [JsonProperty("currency", Required = Required.Always)]
        public string currency { get; set; }

        [JsonProperty("start_time", Required = Required.Always)]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? start_time { get; set; }

        [JsonProperty("end_time", Required = Required.Always)]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? end_time { get; set; }

        [JsonProperty("revenue_fraction")]
        public string revenue_fraction { get; set; }
    }
}
