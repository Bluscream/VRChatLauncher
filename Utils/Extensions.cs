using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VRChatLauncher.Utils
{
    static class Extensions
    {
        public static object ToJson(this object obj) {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
        }
        public static string Ext(this string text, string extension)
        {
            return text + "." + extension;
        }
        public static string Quote(this string text)
        {
            return SurroundWith(text, "\"");
        }
        public static string Enclose(this string text)
        {
            return SurroundWith(text, "(",")");
        }
        public static string SurroundWith(this string text, string surrounds)
        {
            return surrounds + text + surrounds;
        }
        public static string SurroundWith(this string text, string starts, string ends)
        {
            return starts + text + ends;
        }
        public static T PopAt<T>(this List<T> list, int index)
        {
            T r = list[index];
            list.RemoveAt(index);
            return r;
        }
        private static readonly Regex QueryRegex = new Regex(@"[?&](\w[\w.]*)=([^?&]+)");
        public static IReadOnlyDictionary<string, string> ParseQueryString(this Uri uri)
        {
            var match = QueryRegex.Match(uri.PathAndQuery);
            var paramaters = new Dictionary<string, string>();
            while (match.Success)
            {
                paramaters.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }
            return paramaters;
        }
        public static void AppendLine(this FileInfo file, string line)
        {
            if (!file.Exists) file.Create();
            File.AppendAllLines(file.FullName, new string[] { line });
        }
    }
}
