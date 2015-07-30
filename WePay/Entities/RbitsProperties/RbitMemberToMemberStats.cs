using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#member_to_member_stats
    /// </summary>
    public class RbitMemberToMemberStats : WepayRbitBase
    {
        [JsonProperty("inbound_messages")]
        public int InboundMessages { get; set; }

        [JsonProperty("inbound_messages_to_txn_ratio")]
        public float InboundMessagesToTxnRatio { get; set; }

        [JsonProperty("outbound_messages")]
        public int OutboundMessages { get; set; }

        [JsonProperty("outbound_messages_to_txn_ratio")]
        public float OutboundMessagesToTxnRatio { get; set; }
    }
}
