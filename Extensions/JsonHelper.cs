using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace CaseManagementAPI.Extensions
{
    public static class JsonHelper
    {
        public static string ToJsonString(this object o)
        {
            return JsonSerializer.Serialize(o);
        }

        public static T? JsonDeserialize<T>(this string s)
        {
            return JsonSerializer.Deserialize<T>(s);
        }
    }
}