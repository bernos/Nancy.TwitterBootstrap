using System;
using Nancy.TwitterBootstrap.Models;
using System.Collections.Generic;

namespace Nancy.TwitterBootstrap.Extensions
{
    // datetime, datetime-local, date, month, time, week, tel, 
    public static class InputExtensions
    {
        public static string Input(this BootstrapRenderer renderer, string name, object value, string type, object htmlAttributes = null)
        {
            var attributes = new HtmlAttributes(htmlAttributes);
            
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

        public static string Email(this BootstrapRenderer renderer, string name, string value, object htmlAttributes = null)
        {
            return Input(renderer, name, value, "email", htmlAttributes);
        }

        public static string Number(this BootstrapRenderer renderer, string name, string value,
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