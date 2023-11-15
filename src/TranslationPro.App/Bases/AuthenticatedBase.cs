#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.App.Bases;

public class AuthenticatedBase : ComponentBase
{
    [CascadingParameter]
    Task<AuthenticationState> authenticationStateTask { get; set; }


    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    protected List<NavigationItem> NavigationItems { get; set; } = new();

    [CascadingParameter]
    protected IApplicationsController ApplicationService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected virtual Task LoadData()
    {
        this.NavigationItems.Clear();
        this.NavigationItems.Add(new NavigationItem()
        {
            Title = "Applications",
            Url = "/applications"
        });

        return Task.CompletedTask;
    }
}