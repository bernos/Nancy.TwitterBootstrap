using System.Collections.Generic;
using System.Text;
using Nancy.TwitterBootstrap.Models;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class TableExtensions
    {
        public static string Table(this BootstrapRenderer renderer, IEnumerable<string> headerRow, IEnumerable<IEnumerable<string>> dataRows, object htmlAttributes = null)
        {
            var defaultAttributes = new HtmlAttributes(new
            {
                @class = "table"
            });

            var headerContent = headerRow == null ? string.Empty : TableRow(renderer, headerRow, renderer.Templates.TableHeaderCell);

            var bodyContent = new StringBuilder();

            if (dataRows != null)
            {
                foreach (var dataRow in dataRows)
                {
                    bodyContent.Append(TableRow(renderer, dataRow, renderer.Templates.TableCell));
                }
            }

            var header = headerRow == null ? string.Empty : renderer.Templates.TableHeader.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", headerContent}
            });

            var body = dataRows == null ? string.Empty : renderer.Templates.TableBody.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", bodyContent.ToString()}
            });

            return renderer.Templates.Table.FormatFromDictionary(new Dictionary<string, string>
            {
                {"attributes", defaultAttributes.Merge(new HtmlAttributes(htmlAttributes)).ToString() },
                {"content", header + body}
            });
        }

        public static string TableRow(this BootstrapRenderer renderer, IEnumerable<string> row, string template)
        {
            var rowContent = new StringBuilder();

            foreach (var cell in row)
            {
                rowContent.Append(template.FormatFromDictionary(new Dictionary<string, string>
                {
                    {"content", cell}
                }));
            }

            return renderer.Templates.TableRow.FormatFromDictionary(new Dictionary<string, string>
            {
                {"content", rowContent.ToString()}
            });
        }
    }
}