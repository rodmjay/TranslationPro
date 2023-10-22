#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TranslationPro.IdentityServer.TagHelpers
{
    [HtmlTargetElement("shadow-area", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class ShadowAreaHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddClass("d-flex", HtmlEncoder.Default);
            output.AddClass("flex-column", HtmlEncoder.Default);
            output.AddClass("align-content-center", HtmlEncoder.Default);
            output.AddClass("ss-main-shadow", HtmlEncoder.Default);
            output.AddClass("shadow", HtmlEncoder.Default);
            output.AddClass("ss-rounded", HtmlEncoder.Default);
        }
    }
}