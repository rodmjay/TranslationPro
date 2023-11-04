#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages.Bases;

public class PhraseDetailsBase : ApplicationDetailsBase
{
    [Inject]
    public IPhrasesController PhrasesController { get; set; }

    [Parameter]
    public int PhraseId { get; set; }

    public PhraseDto Phrase { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected override async Task LoadData()
    {
        await base.LoadData();
        Phrase = await PhrasesController.GetPhraseAsync(ApplicationId, PhraseId);


    }
}