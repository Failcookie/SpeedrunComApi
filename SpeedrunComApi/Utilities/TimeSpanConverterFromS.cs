using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunComApi.Utilities
{
    public class TimeSpanConverterFromSeconds : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Value<int?>() != null)
            {
                return TimeSpan.FromSeconds(token.Value<int>());
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (long)(((TimeSpan)value).TotalSeconds));
        }
    }
}
