using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace omg.TopologicalSorting.Utiles
{
    public static class JsonSerializationExtension
    {
        public static T DeserializeFromString<T>(this string objData)
        {
            if (objData == null)
            {
                return (T)Convert.ChangeType(null, typeof(T));
            }

            try
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                    NullValueHandling = NullValueHandling.Ignore
                };
                return JsonConvert.DeserializeObject<T>(objData, serializerSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeserializeFromString error: {typeof(T)}: {ex.Message}", ex, "StringExtensions.DeserializeFromString");
            }

            return (T)Convert.ChangeType(null, typeof(T));
        }

        public static string SerializeObject<T>(this T obj, JsonSerializerSettings settings = null)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            try
            {
                return JsonConvert.SerializeObject(obj,
                    settings ?? new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore,
                        StringEscapeHandling = StringEscapeHandling.EscapeHtml
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SerializeObject error: {typeof(T)}: {ex.Message}", ex, "StringExtensions.SerializeObject");
            }

            return string.Empty;
        }

        public static string SerializeToJson<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            try
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new NullToEmptyStringResolver()
                };
                return JsonConvert.SerializeObject(value, serializerSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SerializeToJson error: {typeof(T)}: {ex.Message}", ex, "StringExtensions.SerializeToJson");
            }

            return string.Empty;
        }
    }
}
