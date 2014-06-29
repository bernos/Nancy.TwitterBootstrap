using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.TwitterBootstrap.Models;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class SelectListExtensions
    {
        public static string SelectList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options, object htmlAttributes = null)
        {
            return SelectList(renderer, name, options, o => false, false, htmlAttributes);
        }

        public static string SelectList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options,
            TValue selectedValue, object htmlAttributes = null)
        {
            return SelectList(renderer, name, options, o => o.Value.Equals(selectedValue), false, htmlAttributes);
        }

        public static string SelectList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options,
            Func<ListOption<TValue>, bool> selectedOptions, object htmlAttributes = null)
        {
            return SelectList(renderer, name, options, selectedOptions, false, htmlAttributes);
        }
        public static string SelectList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options, Func<ListOption<TValue>, bool> selectedOptions, bool allowMultiple = false, object htmlAttributes = null)
        {
            var optionsBuilder = new StringBuilder();

            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "form-control"
            });

            if (allowMultiple)
            {
                defaultAttributes["multiple"] = "true";
            }

            foreach (var option in options)
            {
                optionsBuilder.Append(renderer.Templates.SelectListOption.FormatFromDictionary(new Dictionary<string, string>
                {
                    { "value", option.Value.ToString() },
                    { "label", option.Label },
                    { "selected", selectedOptions(option) ? " selected" : string.Empty }
                }));
            }

            return renderer.Templates.SelectList.FormatFromDictionary(new Dictionary<string, string>
            {
                {"name", name},
                {"attributes", defaultAttributes.Merge(new HtmlAttributes(htmlAttributes)).ToString()},
                {"options", optionsBuilder.ToString()}
            });
        }

        public static string MultipleSelectList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options, object htmlAttributes = null)
        {
            return SelectList(renderer, name, options, o => false, true, htmlAttributes);
        }

        public static string MultipleSelectList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options,
            IEnumerable<TValue> selectedValues, object htmlAttributes = null)
        {
            return SelectList(renderer, name, options, o => selectedValues.Any(sv => sv.Equals(o.Value)), true, htmlAttributes);
        }

        public static string MultipleSelectList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options,
            Func<ListOption<TValue>, bool> selectedOptions, object htmlAttributes = null)
        {
            return SelectList(renderer, name, options, selectedOptions, true, htmlAttributes);
        }
    }
}