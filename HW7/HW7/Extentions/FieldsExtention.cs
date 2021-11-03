using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW7.Extentions
{
    public static class FieldsExtention
    {
        internal static IHtmlContent CreateLabel(this PropertyInfo propertyInfo)
        {
            var label = new TagBuilder("label")
            {
                Attributes =
                {
                    {"class", "col-sm-2 col-form-label-lg"},
                    {"for", propertyInfo.Name}
                }
            };
            label.InnerHtml.AppendHtmlLine(propertyInfo.GetDisplayName());
            return label;
        }

        internal static IHtmlContent CreateDiv(this PropertyInfo propertyInfo, object model)
        {
            var div = new TagBuilder("div");

            div.InnerHtml.AppendHtml(propertyInfo.PropertyType.IsEnum
                ? CreateSelect(propertyInfo, model)
                : CreateInput(propertyInfo, model));
            return div;
        }

        internal static IHtmlContent CreateMessageBlock(this PropertyInfo propertyInfo, object model)
        {
            var span = new TagBuilder("span")
            {
                Attributes =
                {
                    {"class", "text-danger col-sm-4 col-form-label"}
                }
            };

            if (model is null) return span;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(model)
            {
                MemberName = propertyInfo.Name,
                DisplayName = propertyInfo.GetDisplayName()
            };
            if (!Validator.TryValidateProperty(propertyInfo.GetValue(model), context, results))
                span.InnerHtml.AppendHtmlLine(results[0].ErrorMessage!);
            
            return span;
        }

        private static IHtmlContent CreateInput(PropertyInfo propertyInfo, object model)
        {
            var input = new TagBuilder("input")
            {
                Attributes =
                {
                    {"class", "form-control"},
                    {"name", propertyInfo.Name},
                    {"type", propertyInfo.PropertyType.IsIntegerType() ? "number" : "text"},
                    {"value", model is not null ? propertyInfo.GetValue(model)?.ToString() ?? "" : ""}
                }
            };

            return input;
        }

        private static IHtmlContent CreateSelect(PropertyInfo propertyInfo, object model)
        {
            var select = new TagBuilder("select")
            {
                Attributes =
                {
                    {"class", "custom-select"},
                    {"name", propertyInfo.Name}
                }
            };

            var modelValue = model is not null ? propertyInfo.GetValue(model) : 0;
            var memberInfos = propertyInfo.PropertyType
                                          .GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var memberInfo in memberInfos)
            {
                var option = memberInfo.CreateOption(modelValue);
                select.InnerHtml.AppendHtml(option);
            }

            return select;
        }

        private static IHtmlContent CreateOption(this FieldInfo memberInfo, object modelValue)
        {
            var enumType = memberInfo.DeclaringType;
            var option = new TagBuilder("option")
            {
                Attributes =
                {
                    {"value", memberInfo.Name}
                }
            };
            if (memberInfo.GetValue(enumType)?.Equals(modelValue) ?? false)
                option.MergeAttribute("selected", "true");

            option.InnerHtml.AppendHtmlLine(memberInfo.GetDisplayName());
            return option;
        }
    }
}