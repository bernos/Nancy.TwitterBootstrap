using System.Collections.Generic;
using Nancy.TwitterBootstrap.Models;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class ValidationExtensions
    {
        public static string ValidationMessage(this BootstrapRenderer renderer, string message, object htmlAttributes = null)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "help-block"
            });

            return renderer.Templates.ValidationMessage.FormatFromDictionary(new Dictionary<string, string>
            {
                {"message", message},
                {"attributes", defaultAttributes.Merge(new HtmlAttributes(htmlAttributes)).ToString()}
            });
        }
    }
}