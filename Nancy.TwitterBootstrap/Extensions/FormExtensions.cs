using System.Collections.Generic;
using Nancy.TwitterBootstrap.Models;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class FormExtensions
    {
        public static string BeginFormGroup(this BootstrapRenderer renderer)
        {
            return BeginFormGroup(renderer, null);
        }

        public static string BeginFormGroup(this BootstrapRenderer renderer, object attributes)
        {
            return BeginFormGroup(renderer, new HtmlAttributes(attributes));
        }

        public static string BeginFormGroup(this BootstrapRenderer renderer, HtmlAttributes attributes)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "form-group"
            });


            return renderer.Templates.BeginFormGroup.FormatFromDictionary(new Dictionary<string, string>
            {
                { "attributes", defaultAttributes.Merge(attributes).ToString() }
            });
        }

        public static string EndFormGroup(this BootstrapRenderer renderer)
        {
            return renderer.Templates.EndFormGroup;
        }

    }
}