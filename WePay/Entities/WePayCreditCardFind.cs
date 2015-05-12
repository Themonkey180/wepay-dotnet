using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/credit_card
    /// </summary>
    public class WePayCreditCardFind : WepayBatch
    {
        public WePayCreditCard[] CreditCards { get; set; }
    }
}

