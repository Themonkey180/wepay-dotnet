using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.Account
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit#lookup
    /// </summary>
    public class RbitGetArgument
    {
        [JsonProperty("rbit_id", Required = Required.Always)]
        public long? RbitId { get; set; }

        public string BatchUrl() { return "/account/membership/create"; }
    }
}
