using Newtonsoft.Json;
using System;
using WePay.Entities.Structure;
using WePay.Infrastructure;

namespace WePay.Entities
{
    /// <summary>
    /// https://www.wepay.com/developer/reference/preapproval
    /// </summary>
    public class WePayWithdrawalFind : WepayBatch
    {
        public WePayWithdrawal[] Withdrawals { get; set; }
    }
}

