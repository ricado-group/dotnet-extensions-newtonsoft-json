using System;
using Newtonsoft.Json.Linq;

namespace RICADO.Extensions.Newtonsoft.Json
{
    public static class LinqExtensions
    {
        public static bool TrySelectValue<T>(this JToken json, string path, out T value)
        {
            value = default(T);

            if (json.TrySelectValue(path, typeof(T), out object objectValue) == false)
            {
                return false;
            }

            value = (T)objectValue;
            return true;
        }

        public static bool TrySelectValue(this JToken json, string path, Type type, out object value)
        {
            value = null;

            if (json == null || json.Type == JTokenType.None)
            {
                return false;
            }

            JToken jsonToken = json.SelectToken(path);

            if (jsonToken == null || jsonToken.Type == JTokenType.None)
            {
                return false;
            }

            return jsonToken.TryToObject(type, out value);
        }

        public static bool TryToObject<T>(this JToken json, out T value)
        {
            value = default(T);

            if (json.TryToObject(typeof(T), out object objectValue) == false)
            {
                return false;
            }

            value = (T)objectValue;
            return true;
        }

        public static bool TryToObject(this JToken json, Type type, out object value)
        {
            value = null;

            if (json == null || json.Type == JTokenType.None)
            {
                return false;
            }

            try
            {
                value = json.ToObject(type);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
