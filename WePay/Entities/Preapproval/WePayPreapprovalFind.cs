using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval
    /// </summary>
    public class WePayPreapprovalFind : WepayBatch
    {
        public WePayPreapproval[] Preapprovals { get; set; }
    }
}

