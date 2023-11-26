#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Bases;

public class LanguageDetailsBase : ApplicationDetailsBase
{
    [Parameter]
    public string LanguageId { get; set; }

    protected LanguageOutput Language { get; set; }

    [Inject]
    public IApplicationLanguagesController ApplicationLanguagesProxy { get; set; }

    [Inject]
    public ILanguagesController LanguageProxy { get; set; }

    public PagedList<ApplicationTranslationOutputWithOriginalPhrase> Translations { get; set; }

    private readonly PagingQuery _paging = new();

    protected override async Task LoadData()
    {
        await base.LoadData();
        Translations =
            await ApplicationLanguagesProxy.GetTranslationsForLanguage(ApplicationId, LanguageId,
                _paging);

        Language = await LanguageProxy.GetLanguageAsync(LanguageId);

        StateHasChanged();

        NavigationItems.Add(new NavigationItem()
        {
            Title = $"Language: {LanguageId}",
            Url = $"/applications/{ApplicationId}/languages/{LanguageId}"
        });
    }

    public async Task Callback(int page)
    {
        _paging.Page = page;
        await LoadData();
    }
}