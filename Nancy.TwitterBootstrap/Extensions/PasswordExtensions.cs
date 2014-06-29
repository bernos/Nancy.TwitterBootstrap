namespace Nancy.TwitterBootstrap.Extensions
{
    public static class PasswordExtensions
    {
        public static string Password(this BootstrapRenderer renderer, string name, object value, object htmlAttributes = null)
        {
            return renderer.Input(name, value, "password", htmlAttributes);
        }
    }
}