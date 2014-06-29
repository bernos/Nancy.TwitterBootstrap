namespace Nancy.TwitterBootstrap.Extensions
{
    public static class EmailExtensions
    {
        public static string Email(this BootstrapRenderer renderer, string name, string value, object htmlAttributes = null)
        {
            return renderer.Input(name, value, "email", htmlAttributes);
        }
    }
}