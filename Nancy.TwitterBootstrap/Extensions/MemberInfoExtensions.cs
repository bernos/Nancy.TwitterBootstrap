using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Nancy.TwitterBootstrap.Extensions
{
    public static class MemberInfoExtensions
    {
        public static string GetLabel(this MemberInfo memberInfo)
        {
            var displayAttribute = memberInfo.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }

            return memberInfo.Name;
        }
    }
}