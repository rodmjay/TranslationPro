#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationPro.Base.Users.Managers;

namespace TemplateIdentityServer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager _signinManager;

        public IndexModel(SignInManager signinManager)
        {
            _signinManager = signinManager;
        }

        public IActionResult OnGet()
        {
            if (_signinManager.IsSignedIn(User)) return LocalRedirect("/Account/Manage");

            return LocalRedirect("/Account/Login");
        }
    }
}