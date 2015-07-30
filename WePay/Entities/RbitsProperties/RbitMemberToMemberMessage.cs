using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#member_to_member_message
    /// </summary>
    public class RbitMemberToMemberMessage : WepayRbitBase
    {
        [JsonProperty("message_direction", Required = Required.Always)]
        public string MessageDirection { get; set; }

        [JsonProperty("message_subject")]
        public string MessageSubject { get; set; }

        [JsonProperty("message_text")]
        public string MessageText { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
