using System.Text.Json;
using System.Collections.Generic;

public static class JsonExtensions
{
    public static string ToJsonString<T>(this List<T> list) where T : class
    {
        if (list == null || list.Count == 0)
            return string.Empty;

        return JsonSerializer.Serialize(list);
    }
}
