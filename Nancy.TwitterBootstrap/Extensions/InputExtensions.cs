using Nancy.TwitterBootstrap.Models;
using System.Collections.Generic;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class InputExtensions
    {
        public static string Input(this BootstrapRenderer renderer, string name, object value, string type, object htmlAttributes = null)
        {
            var attributes = new HtmlAttributes(htmlAttributes);
            
            return renderer.Templates.Input.FormatFromDictionary(new Dictionary<string, string>
            {
                { "name", name },
                { "attributes", attributes.ToString() },
                { "type", type },
                { "value", value == null ? string.Empty : value.ToString() }
            });
        }
    }
}