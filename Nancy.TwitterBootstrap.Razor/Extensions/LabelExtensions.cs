using System;
using System.Linq;
using System.Linq.Expressions;
using Nancy.ModelBinding;
using Nancy.TwitterBootstrap.Extensions;
using Nancy.ViewEngines.Razor;

namespace Nancy.TwitterBootstrap.Razor.Extensions
{
    public static class LabelExtensions
    {
        // Label //

        public static IHtmlString Label<T>(this BootstrapHelpers<T> helpers, string label, object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Label(label, htmlAttributes));
        }

        public static IHtmlString Label<T>(this BootstrapHelpers<T> helpers, string label, string @for, object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Label(label, @for, htmlAttributes));
        }

        public static IHtmlString LabelFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, object>> expression, object htmlAttributes = null)
        {
            return LabelFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString LabelFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, object>> expression, object htmlAttributes = null)
        {
            var info = expression.GetTargetMemberInfo();
            var label = info.GetLabel();

            return Label(helpers, label, info.Name, htmlAttributes);
        }
    }
}