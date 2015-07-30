using Newtonsoft.Json;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#conversation
    /// </summary>
    public class RbitConversation : WepayRbitBase
    {
        [JsonProperty("conversation_type", Required = Required.Always)]
        public string ConversationType { get; set; }

        [JsonProperty("person_making_call_or_visit", Required = Required.Always)]
        public string PersonMakingCallOrVisit { get; set; }

        [JsonProperty("call_notes")]
        public string CallNotes { get; set; }
    }
}
