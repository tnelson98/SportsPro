using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SportsPro.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "filter")]
    public class ButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("filter")]
        public string Filter { get; set; } = string.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Tried simply using output.Content.GetContent(), but that always returned an empty string
            // Instead using solution found on https://stackoverflow.com/questions/48770880/get-tag-content-in-taghelper
            var childContext = output.GetChildContentAsync().Result;
            var content = childContext.GetContent();

            if ((Filter == "all" && content == "All Incidents") ||
                (Filter == "unassigned" && content == "Unassigned Incidents") ||
                (Filter == "open" && content == "Open Incidents"))
            {
                output.Attributes.Add("class", "nav-link active");
            }
            else
                output.Attributes.Add("class", "nav-link");
        }
    }
}
