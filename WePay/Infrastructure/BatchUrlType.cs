using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WePay.Infrastructure
{
    public enum BatchUrlType
    {
        Get = 0,
        Delete = 1,
        Cancel = 2,
        Authorize = 3,
        Capture = 4
    }
}
