namespace Nancy.TwitterBootstrap.Extensions
{
    public static class TextBoxExtensions
    {
        public static string TextBox(this BootstrapRenderer renderer, string name, object value, object htmlAttributes = null)
        {
            return renderer.Input(name, value, "text", htmlAttributes);
        }
    }
}