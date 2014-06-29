using System;
using Nancy.TwitterBootstrap.Extensions;
using Nancy.ViewEngines.Razor;

namespace Nancy.TwitterBootstrap.Razor.Forms
{
    public class FormGroup<TModel> : IDisposable
    {
        private readonly NancyRazorViewBase<TModel> _view;
        private readonly BootstrapRenderer _renderer;

        public int LabelWidth = 0;
        public int ControlWidth = 0;

        public FormGroup(NancyRazorViewBase<TModel> view, BootstrapRenderer renderer, object htmlAttributes = null)
        {
            _view = view;
            _renderer = renderer;

            _view.WriteLiteral(_renderer.BeginFormGroup(htmlAttributes));
        }

        public void Dispose()
        {
            _view.WriteLiteral(_renderer.EndFormGroup());
        }
    }
}