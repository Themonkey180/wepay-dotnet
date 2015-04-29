using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval#cancel
    /// </summary>
    public class WePayPreapprovalState
    {
        [JsonProperty("preapproval_id")]
        public long PreapprovalId { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
