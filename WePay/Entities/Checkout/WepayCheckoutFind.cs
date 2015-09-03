using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class WepayCheckoutFind : WepayBatch
    {
        public WePayCheckout[] Checkouts { get; set; }
    }
}

