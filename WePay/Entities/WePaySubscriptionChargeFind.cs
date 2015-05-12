using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/subscription_charge
    /// </summary>
    public class WePaySubscriptionChargeFind : WepayBatch
    {
        public WePaySubscriptionCharge[] SubscriptionCharges { get; set; }
    }
}

