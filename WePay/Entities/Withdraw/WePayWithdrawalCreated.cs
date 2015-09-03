using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/checkout#create
    /// </summary>
    public class WePayWithdrawalCreated : WepayBatch
    {
        [JsonProperty("withdrawal_id")]
        public long WithdrawalId { get; set; }

        [JsonProperty("withdrawal_uri")]
        public string WithdrawalUri { get; set; }
    }
}
