#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Services;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Bases;

public class AuthenticatedBase : ComponentBase
{
    [Inject] 
    private TokenExpirationService tokenExpirationService { get; set; }

    [CascadingParameter]
    protected IEventAggregator EventAggregator { get; set; }
    
    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    protected List<NavigationItem> NavigationItems { get; set; } = new();

    [CascadingParameter]
    protected IApplicationsController ApplicationService { get; set; }

    [CascadingParameter]
    public UserOutput CurrentUser { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await LoadData();   
        BuildBreadcrumbs();
    }


    protected virtual void BuildBreadcrumbs()
    {
        this.NavigationItems.Clear();
        this.NavigationItems.Add(new NavigationItem()
        {
            Title = "Applications",
            Url = "/applications"
        });
    }

    protected virtual Task LoadData()
    {
        tokenExpirationService.StartTokenExpirationTimer();
      
        return Task.CompletedTask;
    }
}