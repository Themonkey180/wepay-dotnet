using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePay.Infrastructure
{
    public enum WepayPermissions
    {
        manage_accounts = 0,
        collect_payments = 1,
        view_user = 2,
        preapprove_payments = 3,
        manage_subscriptions = 4,
        send_money = 5
    }
}
