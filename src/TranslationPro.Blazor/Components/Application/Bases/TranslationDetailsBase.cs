#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Bases;

public class TranslationDetailsBase : PhraseDetailsBase
{

    [Parameter]
    public string LanguageId { get; set; }
    
    [Inject]
    public ILanguagesController LanguageService { get; set; }

    public LanguageOutput Language { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }


    protected override async Task LoadData()
    {
        await base.LoadData();
        
        Language = await LanguageService.GetLanguageAsync(LanguageId);

        this.NavigationItems.Add(new NavigationItem()
        {
            Title = Language.Name,
            Url = $"/applications/{ApplicationId}/phrases/{PhraseId}/languages/{LanguageId}"
        });
    }
}