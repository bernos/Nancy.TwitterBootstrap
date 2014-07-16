using System;
using System.Linq.Expressions;
using Nancy.ModelBinding;
using Nancy.TwitterBootstrap.Extensions;
using Nancy.ViewEngines.Razor;

namespace Nancy.TwitterBootstrap.Razor.Extensions
{
    public static class InputExtensions
    {
        public static IHtmlString Input<T>(this BootstrapHelpers<T> helpers, string name, object value, string type,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Input(name, value, type, htmlAttributes));
        }

        // Color //

        public static IHtmlString Color<T>(this BootstrapHelpers<T> helpers, string name, string value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Color(name, value, htmlAttributes));
        }

        public static IHtmlString ColorFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, string>> expression,
            object htmlAttributes = null)
        {
            return ColorFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString ColorFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, string>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return Color(helpers, name, value, htmlAttributes);
        }

        // Date //

        public static IHtmlString Date<T>(this BootstrapHelpers<T> helpers, string name, DateTime value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Date(name, value, htmlAttributes));
        }

        public static IHtmlString DateFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, DateTime>> expression,
            object htmlAttributes = null)
        {
            return DateFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString DateFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, DateTime>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return Date(helpers, name, value, htmlAttributes);
        }
        
        // DateTime //

        public static IHtmlString DateTime<T>(this BootstrapHelpers<T> helpers, string name, DateTime value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.DateTime(name, value, htmlAttributes));
        }

        public static IHtmlString DateTimeFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, DateTime>> expression,
            object htmlAttributes = null)
        {
            return DateTimeFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString DateTimeFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, DateTime>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return DateTime(helpers, name, value, htmlAttributes);
        }

        // DateTimeLocal //

        public static IHtmlString DateTimeLocal<T>(this BootstrapHelpers<T> helpers, string name, DateTime value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.DateTimeLocal(name, value, htmlAttributes));
        }

        public static IHtmlString DateTimeLocalFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, DateTime>> expression,
            object htmlAttributes = null)
        {
            return DateTimeLocalFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString DateTimeLocalFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, DateTime>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return DateTimeLocal(helpers, name, value, htmlAttributes);
        }

        // Email //

        public static IHtmlString Email<T>(this BootstrapHelpers<T> helpers, string name, string value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Email(name, value, htmlAttributes));
        }

        public static IHtmlString EmailFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, string>> expression,
            object htmlAttributes = null)
        {
            return EmailFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString EmailFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, string>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return Email(helpers, name, value, htmlAttributes);
        }

        // Number //

        public static IHtmlString Number<T>(this BootstrapHelpers<T> helpers, string name, object value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Number(name, value, htmlAttributes));
        }

        public static IHtmlString NumberFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            return NumberFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString NumberFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return Number(helpers, name, value, htmlAttributes);
        }

        // Password //

        public static IHtmlString Password<T>(this BootstrapHelpers<T> helpers, string name, string value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Password(name, value, htmlAttributes));
        }

        public static IHtmlString PasswordFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, string>> expression,
            object htmlAttributes = null)
        {
            return PasswordFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString PasswordFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, string>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return Password(helpers, name, value, htmlAttributes);
        }

        // Search //

        public static IHtmlString Search<T>(this BootstrapHelpers<T> helpers, string name, object value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Search(name, value, htmlAttributes));
        }

        public static IHtmlString SearchFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            return SearchFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString SearchFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return Search(helpers, name, value, htmlAttributes);
        }

        // TelephoneNumber //

        public static IHtmlString TelephoneNumber<T>(this BootstrapHelpers<T> helpers, string name, object value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.TelephoneNumber(name, value, htmlAttributes));
        }

        public static IHtmlString TelephoneNumberFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            return TelephoneNumberFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString TelephoneNumberFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return TelephoneNumber(helpers, name, value, htmlAttributes);
        }

        // TextArea //

        public static IHtmlString TextArea<T>(this BootstrapHelpers<T> helpers, string name, object value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.TextArea(name, value, htmlAttributes));
        }

        public static IHtmlString TextAreaFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            return TextAreaFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString TextAreaFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return TextArea(helpers, name, value, htmlAttributes);
        }

        // TextBox //

        public static IHtmlString TextBox<T>(this BootstrapHelpers<T> helpers, string name, object value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.TextBox(name, value, htmlAttributes));
        }

        public static IHtmlString TextBoxFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            return TextBoxFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString TextBoxFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, object>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return TextBox(helpers, name, value, htmlAttributes);
        }

        // Url //

        public static IHtmlString Url<T>(this BootstrapHelpers<T> helpers, string name, string value,
            object htmlAttributes = null)
        {
            return new NonEncodedHtmlString(helpers.Renderer.Url(name, value, htmlAttributes));
        }

        public static IHtmlString UrlFor<T>(this BootstrapHelpers<T> helpers, Expression<Func<T, string>> expression,
            object htmlAttributes = null)
        {
            return UrlFor(helpers, helpers.View.Model, expression, htmlAttributes);
        }

        public static IHtmlString UrlFor<T>(this BootstrapHelpers<T> helpers, T model, Expression<Func<T, string>> expression,
            object htmlAttributes = null)
        {
            var name = expression.GetTargetMemberInfo().Name;
            var value = expression.Compile()(model);

            return Url(helpers, name, value, htmlAttributes);
        }
    }
}