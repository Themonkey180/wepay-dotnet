using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class WePaySubscriptionPlanFind : WepayBatch
    {
        public WePaySubscriptionPlan[] SubscriptionPlans { get; set; }
    }
}

