using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace WePay.Infrastructure
{
    class ParameterBuilder
    {
        public static string ApplyParameters(object obj)
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
            settings.NullValueHandling = NullValueHandling.Ignore;
            var data = JsonConvert.SerializeObject(obj, Formatting.None, settings);

            return data;
        }
    }
}
