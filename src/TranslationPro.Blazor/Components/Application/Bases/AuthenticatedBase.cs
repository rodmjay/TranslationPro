#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Blazor.Services;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Blazor.Components.Application.Bases;

public class AuthenticatedBase : ComponentBase
{
    [Inject] 
    private TokenExpirationService tokenExpirationService { get; set; }


    [CascadingParameter]
    Task<AuthenticationState> authenticationStateTask { get; set; }
    
    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    protected List<NavigationItem> NavigationItems { get; set; } = new();

    [CascadingParameter]
    protected IApplicationsController ApplicationService { get; set; }
    private Timer _timer;

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected virtual Task LoadData()
    {
        tokenExpirationService.StartTokenExpirationTimer();
        this.NavigationItems.Clear();
        this.NavigationItems.Add(new NavigationItem()
        {
            Title = "Applications",
            Url = "/applications"
        });

        return Task.CompletedTask;
    }


    //public void StartTokenExpirationTimer()
    //{
    //    // Set the timer interval to check for token expiration
    //    _timer = new Timer(CheckExpiration, null, 0, 1000);
    //}

    //private async void CheckExpiration(object state)
    //{
    //    var user = authenticationStateTask.Result.User;

    //    if (user.Identity.IsAuthenticated)
    //    {
    //        var expirationClaim = user.FindFirst(c => c.Type == "exp");

    //        if (expirationClaim != null && long.TryParse(expirationClaim.Value, out var expirationTime))
    //        {
    //            // Check if the token is about to expire (e.g., within 5 minutes)
    //            var currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    //            var timeUntilExpiration = expirationTime - currentTime;

    //            if (timeUntilExpiration <= 300)
    //            {
    //                NavigationManager.NavigateTo("/authentication/logout");
    //            }
    //        }
    //    }
    //}
}