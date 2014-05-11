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
        public static string MergeCssClasses(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return b;
            }

            if (string.IsNullOrEmpty(b))
            {
                return a;
            }

            return a + " " + b;
        }

        private readonly BootstrapTemplates _templates;

        public BootstrapRenderer(BootstrapTemplates templates)
        {
            _templates = templates;
        }

        public string BeginFormGroup(object attributes = null)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "form-group"
            });


            return _templates.BeginFormGroup.FormatFromDictionary(new Dictionary<string, string>
            {
                { "attributes", defaultAttributes.Merge(new HtmlAttributes(attributes)).ToString() }
            });
        }

        public string EndFormGroup()
        {
            return _templates.EndFormGroup;
        }

        public string Checkbox(string name, object value, string label, bool selected = false, object attributes = null)
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

            return _templates.Checkbox.FormatFromDictionary(ctx);
        }

        // TODO: allow passing html attributes
        public string CheckboxList<TValue>(string name, IEnumerable<ListOption<TValue>> options)
        {
            return CheckboxList(name, options, o => false);
        }

        // TODO: allow passing html attributes
        public string CheckboxList<TValue>(string name, IEnumerable<ListOption<TValue>> options,
            IEnumerable<TValue> selectedOptions)
        {
            return CheckboxList(name, options, o => selectedOptions.Any(so => o.Value.Equals(so)));
        }

        public string CheckboxList<TValue>(string name, IEnumerable<ListOption<TValue>> options,
            Func<ListOption<TValue>, bool> selectedOptions)
        {
            var optionsBuilder = new StringBuilder();

            foreach (var checkboxListOption in options)
            {
                optionsBuilder.Append(Checkbox(name, checkboxListOption.Value, checkboxListOption.Label,
                    selectedOptions(checkboxListOption)));
            }

            return optionsBuilder.ToString();
        }

        public string Email(string name, string value, object htmlAttributes = null)
        {
            return Input(name, value, "email", new HtmlAttributes(htmlAttributes));
        }

        public string Label(string label, string @for = "", object htmlAttributes = null)
        {
            var attributes = new HtmlAttributes(htmlAttributes);

            if (!string.IsNullOrEmpty(@for))
            {
                attributes["for"] = @for;
            }

            return _templates.Label.FormatFromDictionary(new Dictionary<string, string>
            {
                { "attributes", attributes.ToString() },
                { "label", label }
            });
        }

        public string Password(string name, object value, object htmlAttributes = null)
        {
            return Input(name, value, "password", new HtmlAttributes(htmlAttributes));
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

            return _templates.RadioButton.FormatFromDictionary(ctx);
        }

        // TODO: add method for no selected option
        // TODO: allow passing html attributes
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
                optionsBuilder.Append(_templates.SelectListOption.FormatFromDictionary(new Dictionary<string, string>
                {
                    { "value", option.Value.ToString() },
                    { "label", option.Label },
                    { "selected", selectedOptions(option) ? " selected" : string.Empty }
                }));
            }

            return _templates.SelectList.FormatFromDictionary(new Dictionary<string, string>
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

            var headerContent = headerRow == null ? string.Empty : TableRow(headerRow, _templates.TableHeaderCell);

            var bodyContent = new StringBuilder();

            if (dataRows != null)
            {
                foreach (var dataRow in dataRows)
                {
                    bodyContent.Append(TableRow(dataRow, _templates.TableCell));
                }
            }
            
            var header = headerRow == null ? string.Empty : _templates.TableHeader.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", headerContent}
            });

            var body = dataRows == null ? string.Empty : _templates.TableBody.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", bodyContent.ToString()}
            });

            return _templates.Table.FormatFromDictionary(new Dictionary<string, string>
            {
                {"attributes", defaultAttributes.Merge(new HtmlAttributes(htmlAttributes)).ToString() },
                {"content", header + body}
            });
        }
        
        public string TextBox(string name, object value, object htmlAttributes = null)
        {
            return Input(name, value, "text", new HtmlAttributes(htmlAttributes));
        }

        public string ValidationMessage(string message, object htmlAttributes = null)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "help-block"
            });

            return _templates.ValidationMessage.FormatFromDictionary(new Dictionary<string, string>
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

            return _templates.TableRow.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", rowContent.ToString()}
            });
        }

        protected virtual string Input(string name, object value, string type, HtmlAttributes attributes = null)
        {
            if (attributes == null)
            {
                attributes = new HtmlAttributes(null);
            }

            return _templates.Input.FormatFromDictionary(new Dictionary<string, string>
            {
                { "name", name },
                { "attributes", attributes.ToString() },
                { "type", type },
                { "value", value == null ? string.Empty : value.ToString() }
            });
        }
    }
}