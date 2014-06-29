using System.Collections.Generic;
using Nancy.TwitterBootstrap.Models;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class LabelExtensions
    {
        public static string Label(this BootstrapRenderer renderer, string label, string @for = "", object htmlAttributes = null)
        {
            var attributes = new HtmlAttributes(htmlAttributes);

            if (!string.IsNullOrEmpty(@for))
            {
                attributes["for"] = @for;
            }

            return renderer.Templates.Label.FormatFromDictionary(new Dictionary<string, string>
            {
                { "attributes", attributes.ToString() },
                { "label", label }
            });
        }
    }
}