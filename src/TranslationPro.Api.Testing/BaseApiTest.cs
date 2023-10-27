#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityModel.Client;
using NUnit.Framework;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Languages.Models;
using TranslationPro.Testing.Bases;
using TranslationPro.Testing.Extensions;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing;

public abstract class BaseApiTest : IntegrationTest<BaseApiTest, Startup>
{
    protected Result ApplicationResult;


    [OneTimeSetUp]
    public virtual async Task SetupFixture()
    {
        await ResetDatabase();
        var accessToken = await GetAccessToken("admin@admin.com", "ASDFasdf!");
        ApiClient.SetBearerToken(accessToken);
        ApplicationResult = await CreateApplication();
        Assert.IsTrue(ApplicationResult.Succeeded);
    }

    [OneTimeTearDown]
    public virtual async Task TeardownFixture()
    {
        await DeleteDatabase();
    }

    #region Languages

    protected string LanguageUrl = "/v1.0/languages";

    protected async Task<List<LanguageDto>> GetLanguages()
    {
        var response = await ApiClient.GetAsync(LanguageUrl);

        return response.Content.DeserializeObject<List<LanguageDto>>();
    }

    #endregion

    #region Applications

    protected string ApplicationUrl = "/v1.0/applications";

    protected async Task<Result> CreateApplication()
    {
        var content = ApplicationTestCases.CreateApplication.SerializeToUTF8Json();
        var response = await ApiClient.PostAsync(ApplicationUrl, content);
        Assert.True(response.IsSuccessStatusCode);

        var result = response.Content.DeserializeObject<Result>();
        return result;
    }

    protected async Task<Result> DeleteApplication(Guid applicationId)
    {
        var updateResponse = await ApiClient.DeleteAsync($"{ApplicationUrl}/{applicationId}");
        return updateResponse.Content.DeserializeObject<Result>();
    }

    protected async Task<Result> UpdateApplication(Guid applicationId, ApplicationInput input)
    {
        var inputContent = input.SerializeToUTF8Json();
        var updateResponse = await ApiClient.PutAsync($"{ApplicationUrl}/{applicationId}", inputContent);
        return updateResponse.Content.DeserializeObject<Result>();
    }

    protected async Task<List<ApplicationDto>> GetApplications()
    {
        var response = await ApiClient.GetAsync(ApplicationUrl);

        return response.Content.DeserializeObject<List<ApplicationDto>>();
    }

    protected async Task<ApplicationDto> GetApplication(Guid applicationId)
    {
        var response = await ApiClient.GetAsync($"{ApplicationUrl}/{applicationId}");

        return response.Content.DeserializeObject<ApplicationDto>();
    }

    #endregion
}