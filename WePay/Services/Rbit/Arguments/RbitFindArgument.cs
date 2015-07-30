using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.Account
{
    public class RbitFindArgument
    {
        /// <summary>
        /// https://stage.wepay.com/developer/reference/rbit#find
        /// </summary>
        [JsonProperty("associated_object_type")]
        public string AssociatedObjectTtype { get; set; }

        [JsonProperty("associated_object_id")]
        public long? AssociatedObjectId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        public string BatchUrl() { return "/rbit/find"; }
    }
}
