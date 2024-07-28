#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Bases;

public class PhraseDetailsBase : ApplicationDetailsBase
{

    [Inject]
    public IApplicationPhrasesController ApplicationPhraseService { get; set; }

    [Parameter]
    public int PhraseId { get; set; }

    protected ApplicationPhraseDetails ApplicationPhrase { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await LoadData();
    }

    protected override void BuildBreadcrumbs()
    {
        Console.WriteLine("PhraseDetailsBase.BuildBreadcrumbs");

        base.BuildBreadcrumbs();
        this.NavigationItems.Add(new NavigationItem()
        {
            Title = ApplicationPhrase.Id.ToString(),
            Url = $"/applications/{Application.Id}/phrases/{ApplicationPhrase.Id}"
        });
    }

    protected virtual async Task LoadData()
    {
        Console.WriteLine("PhraseDetailsBase.LoadData");
        
        ApplicationPhrase = await ApplicationPhraseService.GetPhraseAsync(ApplicationId, PhraseId);
        
        
    }
}