using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.TwitterBootstrap.Extensions;
using Nancy.TwitterBootstrap.Models;

namespace Nancy.TwitterBootstrap
{
    public class BootstrapRenderer
    {
        public BootstrapTemplates Templates { get; private set; }

        public BootstrapRenderer(BootstrapTemplates templates)
        {
            Templates = templates;
        }

        
        

        public string Email(string name, string value, object htmlAttributes = null)
        {
            return Input(name, value, "email", htmlAttributes);
        }

        public string Label(string label, string @for = "", object htmlAttributes = null)
        {
            var attributes = new HtmlAttributes(htmlAttributes);

            if (!string.IsNullOrEmpty(@for))
            {
                attributes["for"] = @for;
            }

            return Templates.Label.FormatFromDictionary(new Dictionary<string, string>
            {
                { "attributes", attributes.ToString() },
                { "label", label }
            });
        }

        public string Password(string name, object value, object htmlAttributes = null)
        {
            return Input(name, value, "password", htmlAttributes);
        }

        public string RadioButton(string name, object value, string label, bool selected = false, object htmlAttributes = null)
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

            return Templates.RadioButton.FormatFromDictionary(ctx);
        }

        // TODO: allow passing html attributes
        public string RadioButtonGroup<TValue>(string name, IEnumerable<ListOption<TValue>> options)
        {
            return RadioButtonGroup(name, options, o => false);
        }

        public string RadioButtonGroup<TValue>(string name, IEnumerable<ListOption<TValue>> options, TValue selectedOption)
        {
            return RadioButtonGroup(name, options, o => o.Value.Equals(selectedOption));
        }

        // TODO: allow passing html attributes
        public string RadioButtonGroup<TValue>(string name, IEnumerable<ListOption<TValue>> options,
            Func<ListOption<TValue>, bool> selectedOption)
        {
            var optionsBuilder = new StringBuilder();

            foreach (var radioGroupOption in options)
            {
                optionsBuilder.Append(RadioButton(name, radioGroupOption.Value, radioGroupOption.Label,
                    selectedOption(radioGroupOption)));
            }

            return optionsBuilder.ToString();
        }

        public string SelectList<TValue>(string name, IEnumerable<ListOption<TValue>> options, object htmlAttributes = null)
        {
            return SelectList(name, options, o => false, false, htmlAttributes);
        }

        public string SelectList<TValue>(string name, IEnumerable<ListOption<TValue>> options,
            TValue selectedValue, object htmlAttributes = null)
        {
            return SelectList(name, options, o => o.Value.Equals(selectedValue), false, htmlAttributes);
        }

        public string MultipleSelectList<TValue>(string name, IEnumerable<ListOption<TValue>> options, object htmlAttributes = null)
        {
            return SelectList(name, options, o => false, true, htmlAttributes);
        }

        public string MultipleSelectList<TValue>(string name, IEnumerable<ListOption<TValue>> options,
            IEnumerable<TValue> selectedValues, object htmlAttributes = null)
        {
            return SelectList(name, options, o => selectedValues.Any(sv => sv.Equals(o.Value)), true, htmlAttributes);
        }

        public string MultipleSelectList<TValue>(string name, IEnumerable<ListOption<TValue>> options,
            Func<ListOption<TValue>, bool> selectedOptions, object htmlAttributes = null)
        {
            return SelectList(name, options, selectedOptions, true, htmlAttributes);
        }

        public string SelectList<TValue>(string name, IEnumerable<ListOption<TValue>> options,
            Func<ListOption<TValue>, bool> selectedOptions, object htmlAttributes = null)
        {
            return SelectList(name, options, selectedOptions, false, htmlAttributes);
        }

        public string SelectList<TValue>(string name, IEnumerable<ListOption<TValue>> options, Func<ListOption<TValue>, bool> selectedOptions, bool allowMultiple = false,  object htmlAttributes = null)
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
                optionsBuilder.Append(Templates.SelectListOption.FormatFromDictionary(new Dictionary<string, string>
                {
                    { "value", option.Value.ToString() },
                    { "label", option.Label },
                    { "selected", selectedOptions(option) ? " selected" : string.Empty }
                }));
            }

            return Templates.SelectList.FormatFromDictionary(new Dictionary<string, string>
            {
                {"name", name},
                {"attributes", defaultAttributes.Merge(new HtmlAttributes(htmlAttributes)).ToString()},
                {"options", optionsBuilder.ToString()}
            });
        }

        public string Table(IEnumerable<string> headerRow, IEnumerable<IEnumerable<string>> dataRows, object htmlAttributes = null)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "table"
            });

            var headerContent = headerRow == null ? string.Empty : TableRow(headerRow, Templates.TableHeaderCell);

            var bodyContent = new StringBuilder();

            if (dataRows != null)
            {
                foreach (var dataRow in dataRows)
                {
                    bodyContent.Append(TableRow(dataRow, Templates.TableCell));
                }
            }
            
            var header = headerRow == null ? string.Empty : Templates.TableHeader.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", headerContent}
            });

            var body = dataRows == null ? string.Empty : Templates.TableBody.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", bodyContent.ToString()}
            });

            return Templates.Table.FormatFromDictionary(new Dictionary<string, string>
            {
                {"attributes", defaultAttributes.Merge(new HtmlAttributes(htmlAttributes)).ToString() },
                {"content", header + body}
            });
        }
        
        public string TextBox(string name, object value, object htmlAttributes = null)
        {
            return Input(name, value, "text", htmlAttributes);
        }

        public string ValidationMessage(string message, object htmlAttributes = null)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "help-block"
            });

            return Templates.ValidationMessage.FormatFromDictionary(new Dictionary<string, string>
            {
                {"message", message},
                {"attributes", defaultAttributes.Merge(new HtmlAttributes(htmlAttributes)).ToString()}
            });
        }

        protected virtual string TableRow(IEnumerable<string> row, string template)
        {
            var rowContent = new StringBuilder();

            foreach (var cell in row)
            {
                rowContent.Append(template.FormatFromDictionary(new Dictionary<string, string>
                {
                    {"content", cell}
                }));
            }

            return Templates.TableRow.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", rowContent.ToString()}
            });
        }

        protected virtual string Input(string name, object value, string type, object htmlAttributes = null)
        {
            var attributes = new HtmlAttributes(htmlAttributes);
            

            return Templates.Input.FormatFromDictionary(new Dictionary<string, string>
            {
                { "name", name },
                { "attributes", attributes.ToString() },
                { "type", type },
                { "value", value == null ? string.Empty : value.ToString() }
            });
        }
    }
}