﻿namespace Invoices.Extensions
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public static class JsonSerializationExtension
    {
        public static string SerializeToJson<T>(this T obj)
        {
            JsonSerializerSettings settings = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                Converters = new List<JsonConverter>()
                {
                    new StringEnumConverter()
                }
            };

            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T DeserializeFromJson<T>(this string jsonString)
        {
            JsonSerializerSettings settings = new()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }
    }
}
