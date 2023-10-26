#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationPro.Base.Users.Managers;

namespace TranslationPro.IdentityServer.Pages;

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