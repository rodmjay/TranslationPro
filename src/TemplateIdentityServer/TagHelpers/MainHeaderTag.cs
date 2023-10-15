#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TemplateIdentityServer.TagHelpers
{
    [HtmlTargetElement("main-header", Attributes = "name", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class MainHeaderTag : TagHelper
    {
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h2";
            output.AddClass("d-inline-flex", HtmlEncoder.Default);
            output.AddClass("text-center", HtmlEncoder.Default);
            output.AddClass("ml-auto", HtmlEncoder.Default);
            output.AddClass("mr-auto", HtmlEncoder.Default);

            output.Content.SetContent(Name);
        }
    }
}