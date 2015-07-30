using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities.Rbits
{
    /// <summary>
    /// https://stage.wepay.com/developer/reference/rbit_types#fundraising_update
    /// </summary>
    public class RbitFundraisingUpdate : WepayRbitBase
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("photo_uris")]
        public string PhotoUris { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
