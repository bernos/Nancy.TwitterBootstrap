using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.TwitterBootstrap.Models;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class CheckboxExtensions
    {
        public static string Checkbox(this BootstrapRenderer renderer, string name, object value, string label, bool selected = false, object attributes = null)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "checkbox"
            });

            var ctx = new Dictionary<string, string>
            {
                {"attributes", defaultAttributes.Merge(new HtmlAttributes(attributes)).ToString() },
                {"name", name},
                {"value", value == null ? string.Empty : value.ToString()},
                {"selected", selected ? " checked" : ""},
                {"label", label}
            };

            return renderer.Templates.Checkbox.FormatFromDictionary(ctx);
        }

        // TODO: allow passing html attributes
        public static string CheckboxList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options)
        {
            return CheckboxList(renderer, name, options, o => false);
        }

        // TODO: allow passing html attributes
        public static string CheckboxList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options,
            IEnumerable<TValue> selectedOptions)
        {
            return CheckboxList(renderer, name, options, o => selectedOptions.Any(so => o.Value.Equals(so)));
        }

        public static string CheckboxList<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options,
            Func<ListOption<TValue>, bool> selectedOptions)
        {
            var optionsBuilder = new StringBuilder();

            foreach (var checkboxListOption in options)
            {
                optionsBuilder.Append(Checkbox(renderer, name, checkboxListOption.Value, checkboxListOption.Label,
                    selectedOptions(checkboxListOption)));
            }

            return optionsBuilder.ToString();
        }
    }
}