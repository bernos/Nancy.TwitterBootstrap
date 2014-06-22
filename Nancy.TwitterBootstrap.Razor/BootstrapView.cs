using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;

namespace Nancy.TwitterBootstrap.Razor
{
    public abstract class BootstrapView<TModel> : NancyRazorViewBase<TModel>
    {
        public BootstrapHelpers<TModel> Bootstrap { get; private set; }

        protected virtual BootstrapRenderer GetBootstrapRenderer()
        {
            return new BootstrapRenderer(new BootstrapTemplates());
        }

        public override void Initialize(RazorViewEngine engine, IRenderContext renderContext, object model)
        {
            base.Initialize(engine, renderContext, model);

            Bootstrap = new BootstrapHelpers<TModel>(GetBootstrapRenderer(), engine, renderContext, (TModel)model, this);
        }
    }
}