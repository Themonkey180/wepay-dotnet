using Newtonsoft.Json;

namespace WePay.Entities.Structure
{
    public class WepayMembershipAdminContext
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }
    }
}
