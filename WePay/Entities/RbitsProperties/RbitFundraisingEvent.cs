using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#project
    /// </summary>
    public class RbitFundraisingEvent : WepayRbitBase
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("event_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? EventTime { get; set; }

        [JsonProperty("giving_deadline")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? GivingDeadline { get; set; }

        [JsonProperty("fundraising_goal")]
        public float FundraisingGoal { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
