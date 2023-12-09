﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using TranslationPro.Base.Settings;
using TranslationPro.Base.Users.Managers;

namespace TranslationPro.IdentityServer.Pages.Account;

[AllowAnonymous]
public class ConfirmEmailModel : PageModel
{
    private readonly UserManager _userManager;
    private readonly IOptions<AppSettings> _appSettings;

    public ConfirmEmailModel(UserManager userManager, IOptions<AppSettings> appSettings)
    {
        _userManager = userManager;
        _appSettings = appSettings;
    }

    [TempData] public string StatusMessage { get; set; }

    public async Task<IActionResult> OnGetAsync(string userId, string code)
    {
        if (userId == null || code == null) return RedirectToPage("/Index");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound($"Unable to load user with ID '{userId}'.");

        ViewData["LoginUrl"] = _appSettings.Value.AppUrl + "/authentication/login";

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);
        StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
        return Page();
    }
}