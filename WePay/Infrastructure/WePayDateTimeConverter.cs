using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace WePay.Infrastructure
{
    public class WePayDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(EpochTime.ConvertDateTimeToEpoch((DateTime)value).ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return null;

            if (reader.TokenType == JsonToken.Integer)
                return EpochTime.ConvertEpochToDateTime((long)reader.Value);

            return DateTime.Parse(reader.Value.ToString());
        }
    }
}
