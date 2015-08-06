using Newtonsoft.Json;
using System;
using WePay.Entities.Rbits;
using WePay.Infrastructure;

namespace WePay.Entities.Structure
{
    public class WepayRbitStructure
    {
        [JsonProperty("receive_time", Required = Required.Always)]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? ReceiveTime { get; set; }

        [JsonProperty("source", Required = Required.Always)]
        public string Source { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("properties", Required = Required.Always)]
        public WepayRbitBase Properties { get; set; }

        [JsonProperty("related_rbits")]
        [JsonConverter(typeof(WePayRbitsConverter))]
        public WepayRbitStructure[] RelatedRbits { get; set; }
    }
}
