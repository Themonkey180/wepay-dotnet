﻿using Newtonsoft.Json;

namespace WePay
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval#lookup
    /// and
    /// https://www.wepay.com/developer/reference/preapproval#cancel
    /// </summary>
    public class WePayPreapprovalArguments
    {
        [JsonProperty("preapproval_id", Required = Required.Always)]
        public long PreapprovalId { get; set; }
    }
}