#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Bases;

public class PhraseDetailsBase : ComponentBase
{
    [Parameter]
    public Guid ApplicationId { get; set; }

    [CascadingParameter]
    public IApplicationsController ApplicationService { get; set; }

    protected ApplicationOutput Application;

    [Inject]
    public IPhrasesController PhrasesController { get; set; }

    [Parameter]
    public int PhraseId { get; set; }

    public ApplicationPhraseDetails ApplicationPhrase { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected virtual async Task LoadData()
    {
        Application = await ApplicationService.GetApplicationAsync(ApplicationId);
        ApplicationPhrase = await PhrasesController.GetPhraseAsync(ApplicationId, PhraseId);
    }
}