using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ECommerce.Web.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            var jsonData = JsonSerializer.Serialize(value);
            session.SetString(key, jsonData);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var jsonData = session.GetString(key);

            if (jsonData == null)
                return default;

            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}
