using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#create
    /// </summary>
    public class WePayPreapprovalCreate
    {
        [JsonProperty("preapproval_id")]
        public long PreapprovalId { get; set; }

        [JsonProperty("preapproval_uri")]
        public string PreapprovalUri { get; set; }
    }
}
