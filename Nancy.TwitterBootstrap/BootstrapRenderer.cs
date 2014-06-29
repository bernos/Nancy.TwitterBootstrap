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