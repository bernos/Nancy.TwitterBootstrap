using System;
using System.Collections.Generic;
using System.Text;
using Nancy.TwitterBootstrap.Models;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class RadioButtonExtensions
    {
        public static string RadioButton(this BootstrapRenderer renderer, string name, object value, string label, bool selected = false, object htmlAttributes = null)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "radio"
            });

            var ctx = new Dictionary<string, string>
            {
                {"attributes", new HtmlAttributes(htmlAttributes).Merge(defaultAttributes).ToString() },
                {"name", name},
                {"value", value == null ? string.Empty : value.ToString()},
                {"selected", selected ? " checked" : ""},
                {"label", label}
            };

            return renderer.Templates.RadioButton.FormatFromDictionary(ctx);
        }

        // TODO: allow passing html attributes
        public static string RadioButtonGroup<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options)
        {
            return RadioButtonGroup(renderer, name, options, o => false);
        }

        public static string RadioButtonGroup<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options, TValue selectedOption)
        {
            return RadioButtonGroup(renderer, name, options, o => o.Value.Equals(selectedOption));
        }

        // TODO: allow passing html attributes
        public static string RadioButtonGroup<TValue>(this BootstrapRenderer renderer, string name, IEnumerable<ListOption<TValue>> options,
            Func<ListOption<TValue>, bool> selectedOption)
        {
            var optionsBuilder = new StringBuilder();

            foreach (var radioGroupOption in options)
            {
                optionsBuilder.Append(RadioButton(renderer, name, radioGroupOption.Value, radioGroupOption.Label,
                    selectedOption(radioGroupOption)));
            }

            return optionsBuilder.ToString();
        }
    }
}