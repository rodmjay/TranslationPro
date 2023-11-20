#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Bases;

public class PhraseDetailsBase : ApplicationDetailsBase
{

    [Inject]
    public IApplicationPhrasesController ApplicationPhrasesController { get; set; }

    [Parameter]
    public int PhraseId { get; set; }

    protected ApplicationPhraseDetails ApplicationPhrase { get; set; }


    
    protected override async Task LoadData()
    {
        await base.LoadData();
        ApplicationPhrase = await ApplicationPhrasesController.GetPhraseAsync(ApplicationId, PhraseId);

        this.NavigationItems.Add(new NavigationItem()
        {
            Title = ApplicationPhrase.Id.ToString(),
            Url = $"/applications/{Application.Id}/phrases/{ApplicationPhrase.Id}"
        });
    }
}