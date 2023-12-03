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

    protected override void BuildBreadcrumbs()
    {
        base.BuildBreadcrumbs();
        this.NavigationItems.Add(new NavigationItem()
        {
            Title = ApplicationPhrase.Id.ToString(),
            Url = $"/applications/{Application.Id}/phrases/{ApplicationPhrase.Id}"
        });
    }

    protected override async Task LoadData()
    {
        await base.LoadData();
        ApplicationPhrase = await ApplicationPhraseService.GetPhraseAsync(ApplicationId, PhraseId);
        
        
    }
}