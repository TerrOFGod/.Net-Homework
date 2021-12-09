using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW7.Extentions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
        {
            var properties = helper.ViewData
                .ModelMetadata
                .ModelType
                .GetProperties();
            var contents = properties.Select(p => 
                CreateEditor(p, helper.ViewData.Model));
            IHtmlContentBuilder result = new HtmlContentBuilder();
            return contents.Aggregate(result, (current, content) => 
                current.AppendHtml(content));
        }

        private static IHtmlContent CreateEditor(PropertyInfo propertyInfo, object model)
        {
            var div = new TagBuilder("div")
            {
                Attributes =
                {
                    {"class", "row mb-2"}
                }
            };
            div.InnerHtml.AppendHtml(propertyInfo.CreateLabel());
            div.InnerHtml.AppendHtml(propertyInfo.CreateDiv(model));
            div.InnerHtml.AppendHtml(propertyInfo.CreateMessageBlock(model));
            return div;
        }
    }
}