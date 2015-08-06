using Newtonsoft.Json;
using System;
using WePay.Entities.Rbits;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit
    /// </summary>
    public class WepayRbit : WepayBatch
    {
        [JsonProperty("rbit_id")]
        public long RbitId { get; set; }

        [JsonProperty("associated_object_type")]
        public string AssociatedObjectType { get; set; }

        [JsonProperty("associated_object_id")]
        public string AssociatedObjectId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public WepayRbitBase Properties { get; set; }

        [JsonProperty("receive_time")]
        [JsonConverter(typeof(WePayDateTimeConverter))]
        public DateTime? ReceiveTime { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("related_rbits")]
        [JsonConverter(typeof(WePayRbitsConverter))]
        public WepayRbitStructure[] RelatedRbits { get; set; }
    }
}

