#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityModel.Client;
using NUnit.Framework;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Extensions;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using TranslationPro.Testing.Bases;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing;

public abstract class BaseApiTest : IntegrationTest<BaseApiTest, Startup>, 
    IApplicationsController, 
    IApplicationLanguagesController, 
    ILanguagesController,
    IApplicationUsersController,
    IPhrasesController,
    ITranslationsController
{
    protected Result ApplicationResult;

    protected Guid ApplicationId => Guid.Parse(ApplicationResult.Id.ToString());

    [OneTimeSetUp]
    public virtual async Task SetupFixture()
    {
        await ResetDatabase();
        var accessToken = await GetAccessToken("admin@admin.com", "ASDFasdf!");
        ApiClient.SetBearerToken(accessToken);
        ApplicationResult = await CreateDefaultApplication();
        Assert.IsTrue(ApplicationResult.Succeeded);
    }

    [OneTimeTearDown]
    public virtual async Task TeardownFixture()
    {
        await DeleteDatabase();
    }

    #region Languages

    protected string LanguageUrl = "/v1.0/languages";

    public async Task<List<LanguageOutput>> GetLanguagesAsync()
    {
        var response = await ApiClient.GetAsync(LanguageUrl);

        return response.Content.DeserializeObject<List<LanguageOutput>>();
    }

    public async Task<List<LanguagesWithEnginesOutput>> GetAllLanguagesAsync()
    {
        var response = await ApiClient.GetAsync(LanguageUrl + "/all");

        return response.Content.DeserializeObject<List<LanguagesWithEnginesOutput>>();
    }

    #endregion

    #region Applications

    protected string ApplicationUrl = "/v1.0/applications";

    protected Task<Result> CreateDefaultApplication()
    {
        return CreateApplicationAsync(ApplicationTestCases.CreateApplication);
    }

    public Task<ApplicationOutput> GetApplicationAsync(Guid applicationId)
    {
        return DoGet<ApplicationOutput>($"{ApplicationUrl}/{applicationId}");
    }

    public Task<List<ApplicationOutput>> GetApplicationsAsync()
    {
        return DoGet<List<ApplicationOutput>>(ApplicationUrl);
    }

    public Task<Result> CreateApplicationAsync(ApplicationCreateOptions input)
    {
        return DoPost<ApplicationCreateOptions, Result>(ApplicationUrl, input);
    }

    public Task<Result> DeleteApplicationAsync(Guid applicationId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}");
    }

    public Task<Result> UpdateApplicationAsync(Guid applicationId, ApplicationOptions input)
    {
        return DoPut<ApplicationOptions, Result>($"{ApplicationUrl}/{applicationId}", input);
    }

    #endregion

    #region Application Languages
    public Task<Result> AddLanguageToApplicationAsync(Guid applicationId, ApplicationLanguageInput input)
    {
        return DoPost<ApplicationLanguageInput, Result>($"{ApplicationUrl}/{applicationId}/languages", input);
    }

    public Task<Result> RemoveLanguageFromApplicationAsync(Guid applicationId, string languageId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}/languages/{languageId}");
    }

    #endregion

    #region Application Users
    public Task<Result> InviteUserAsync(Guid applicationId, ApplicationUserCreateOptions input)
    {
        return DoPost<ApplicationUserCreateOptions, Result>($"{ApplicationUrl}/{applicationId}/users", input);
    }

    #endregion

    #region Phrases

    public Task<PhraseOutput> GetPhraseAsync(Guid applicationId, int phraseId)
    {
        return DoGet<PhraseOutput>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}");
    }

    public Task<Result> BulkUploadAsync(Guid applicationId, List<string> input)
    {
        return DoPost<List<string>, Result>($"{ApplicationUrl}/{applicationId}/phrases/bulk", input);
    }

    public Task<Result> CreatePhraseAsync(Guid applicationId, PhraseOptions input)
    {
        return DoPost<PhraseOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases", input);
    }

    public Task<Result> UpdatePhraseAsync(Guid applicationId, int phraseId, PhraseOptions input)
    {
        return DoPut<PhraseOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);
    }

    public Task<PagedList<PhraseOutput>> GetPhrasesAsync(Guid applicationId, PagingQuery paging, PhraseFilters filters)
    {
        return DoGet<PagedList<PhraseOutput>>($"{ApplicationUrl}/{applicationId}/phrases");
    }

    public Task<Dictionary<int, string>> GetPhrasesForApplicationAndLanguageAsync(Guid applicationId, string language)
    {
        return DoGet<Dictionary<int, string>>($"{ApplicationUrl}/{applicationId}/phrases/{language}");

    }

    public Task<Result> DeletePhraseAsync(Guid applicationId, int phraseId)
    {
        return DoDelete<Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}");
    }

    #endregion

    #region Translations
    public Task<Result> SaveTranslation(Guid applicationId, int phraseId, TranslationOptions input)
    {
        return DoPut<TranslationOptions, Result>($"{ApplicationUrl}/{applicationId}/phrases/{phraseId}", input);

    }

    #endregion


}