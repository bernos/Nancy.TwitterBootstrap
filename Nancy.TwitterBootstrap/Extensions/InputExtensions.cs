using System;
using Nancy.TwitterBootstrap.Models;
using System.Collections.Generic;

namespace Nancy.TwitterBootstrap.Extensions
{
    // month, time, week 
    public static class InputExtensions
    {
        public static string Input(this BootstrapRenderer renderer, string name, object value, string type, object htmlAttributes = null)
        {
            var attributes = new HtmlAttributes(htmlAttributes);

            attributes.Merge(new HtmlAttributes(new
            {
                @class = "form-control"
            }));

            return renderer.Templates.Input.FormatFromDictionary(new Dictionary<string, string>
            {
                { "name", name },
                { "attributes", attributes.ToString() },
                { "type", type },
                { "value", value == null ? String.Empty : value.ToString() }
            });
        }

        public static string Color(this BootstrapRenderer renderer, string name, string value,
            object htmlAttributes = null)
        {
            return Input(renderer, name, value, "color", htmlAttributes);
        }

        public static string Date(this BootstrapRenderer renderer, string name, DateTime value, object htmlAttributes = null)
        {
            return Input(renderer, name, value.ToString("yyyy-MM-dd"), "date", htmlAttributes);
        }

        public static string DateTime(this BootstrapRenderer renderer, string name, DateTime value, object htmlAttributes = null)
        {
            return Input(renderer, name, string.Format("{0:s}{0:zzz}", value), "datetime", htmlAttributes);
        }

        public static string DateTimeLocal(this BootstrapRenderer renderer, string name, DateTime value, object htmlAttributes = null)
        {
            return Input(renderer, name, string.Format("{0:s}", value), "datetime-local", htmlAttributes);
        }

        public static string Email(this BootstrapRenderer renderer, string name, string value, object htmlAttributes = null)
        {
            return Input(renderer, name, value, "email", htmlAttributes);
        }

        public static string Number(this BootstrapRenderer renderer, string name, object value,
            object htmlAttributes = null)
        {
            return Input(renderer, name, value, "number", htmlAttributes);
        }

        public static string Password(this BootstrapRenderer renderer, string name, string value, object htmlAttributes = null)
        {
            return Input(renderer, name, value, "password", htmlAttributes);
        }

        public static string Search(this BootstrapRenderer renderer, string name, object value,
            object htmlAttributes = null)
        {
            return Input(renderer, name, value, "search", htmlAttributes);
        }

        public static string TelephoneNumber(this BootstrapRenderer renderer, string name, object value,
            object htmlAttributes = null)
        {
            return Input(renderer, name, value, "tel", htmlAttributes);
        }

        public static string TextArea(this BootstrapRenderer renderer, string name, object value,
            object htmlAttributes = null)
        {
            var attributes = new HtmlAttributes(htmlAttributes);

            attributes.Merge(new HtmlAttributes(new
            {
                @class = "form-control"
            }));

            return renderer.Templates.TextArea.FormatFromDictionary(new Dictionary<string, string>
            {
                { "name", name },
                { "attributes", attributes.ToString() },
                { "value", value == null ? String.Empty : value.ToString() }
            });
        }

        public static string TextBox(this BootstrapRenderer renderer, string name, object value, object htmlAttributes = null)
        {
            return Input(renderer, name, value, "text", htmlAttributes);
        }

        public static string Url(this BootstrapRenderer renderer, string name, string value,
            object htmlAttributes = null)
        {
            return Input(renderer, name, value, "url", htmlAttributes);
        }
    }
}