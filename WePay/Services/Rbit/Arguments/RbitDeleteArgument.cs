using Newtonsoft.Json;

namespace WePay.Account
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit#delete
    /// </summary>
    public class RbitDeleteArgument
    {

        [JsonProperty("rbit_id", Required = Required.Always)]
        public long? RbitId { get; set; }

        public string BatchUrl() { return "/rbit/delete"; }
    }
}
