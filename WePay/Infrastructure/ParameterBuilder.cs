using Newtonsoft.Json;

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
