using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsPro.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "[class = nav-link]")]
    public class ActiveNavbarTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCtx { get; set; } = null!;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string action = ViewCtx.RouteData.Values["action"]?.ToString()!;
            string ctlr = ViewCtx.RouteData.Values["controller"]?.ToString()!;

            string aspAction = context.AllAttributes["asp-action"]?.Value?.ToString()!;
            string aspCtlr = context.AllAttributes["asp-controller"]?.Value?.ToString()!;

            if (action == aspAction && ctlr == aspCtlr)
                output.Attributes.Add("class", "active");
        }
    }
}
