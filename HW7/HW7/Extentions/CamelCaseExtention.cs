using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HW7.Extentions
{
    public static class CamelCaseExtention
    {
        internal static string GetDisplayName(this MemberInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<DisplayAttribute>()?.Name ??
                   SpliteCamelCase(propertyInfo.Name);
        }
        
        private static string SpliteCamelCase(string propertyInfoName)
        {
            const string pattern = @"[A-Z][a-z\d]*";
            var words = Regex.Matches(propertyInfoName, pattern);
            return string.Join(' ',words.Select(a => a.Value));
        }
    }
}