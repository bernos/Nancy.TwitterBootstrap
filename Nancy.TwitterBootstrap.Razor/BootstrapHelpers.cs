using System;
using System.Linq.Expressions;
using Nancy.ModelBinding;
using Nancy.TwitterBootstrap.Models;
using Nancy.TwitterBootstrap.Razor.Forms;
using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;

namespace Nancy.TwitterBootstrap.Razor
{
    public class BootstrapHelpers<TModel>
    {
        private readonly NancyRazorViewBase<TModel> _view;
        private readonly BootstrapRenderer _renderer;
        private readonly IRenderContext _renderContext;

        public NancyRazorViewBase<TModel> View
        {
            get { return _view; }
        }

        public BootstrapRenderer Renderer
        {
            get { return _renderer; }
        }

        public IRenderContext RenderContext
        {
            get { return _renderContext; }
        }

        public BootstrapHelpers(BootstrapRenderer renderer, RazorViewEngine engine, IRenderContext renderContext, TModel model, NancyRazorViewBase<TModel> view)
        {
            _view = view;
            _renderer = renderer;
            _renderContext = renderContext;
        }

        public FormGroup<TModel> BeginFormGroup()
        {
            return BeginFormGroup(null);
        } 

        public FormGroup<TModel> BeginFormGroup(object htmlAttributes)
        {
            return new FormGroup<TModel>(_view, _renderer, htmlAttributes);
        }

        public FormGroup<TModel> BeginFormGroupFor(Expression<Func<TModel, object>> expression)
        {
            return BeginFormGroupFor(expression, null);
        } 

        public FormGroup<TModel> BeginFormGroupFor(Expression<Func<TModel, object>> expression, object htmlAttributes)
        {
            return BeginFormGroupFor(_view.Model, expression, htmlAttributes);
        }
        
        public FormGroup<TModel> BeginFormGroupFor(TModel model, Expression<Func<TModel, object>> expression, object htmlAttributes)
        {
            var info = expression.GetTargetMemberInfo();
            var attributes = new HtmlAttributes(htmlAttributes);

            if (_renderContext.Context.ModelValidationResult.Errors.ContainsKey(info.Name))
            {
                attributes = attributes.Merge(new HtmlAttributes(new
                {
                    @class = "has-error"
                }));;
            }

            return BeginFormGroup(attributes);
        }
    }
}