#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Bases;

public abstract class AuthenticatedBase : ComponentBase
{
    [CascadingParameter]
    protected IEventAggregator EventAggregator { get; set; }
    
    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [CascadingParameter]
    protected List<NavigationItem> NavigationItems { get; set; }

    [CascadingParameter]
    protected IApplicationsController ApplicationService { get; set; }

    [CascadingParameter]
    public UserOutput CurrentUser { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine("AuthenticatedBase.OnParametersSetAsync");
        BuildBreadcrumbs();
    }
    
    protected abstract void BuildBreadcrumbs();
    
}