using System.Collections.Generic;
using System.Text;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class StringExtensions
    {
        public static string FormatFromDictionary(this string formatString, Dictionary<string, string> values)
        {
            var newFormatStringBuilder = new StringBuilder(formatString);
            var newValues = new List<object>();

            foreach (var value in values)
            {
                newValues.Add(value.Value);
                newFormatStringBuilder.Replace("{" + value.Key + "}", "{" + (newValues.Count - 1) + "}");
            }

            return string.Format(newFormatStringBuilder.ToString(), newValues.ToArray());
        }
    }
}