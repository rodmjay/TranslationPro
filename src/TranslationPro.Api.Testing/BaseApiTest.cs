#region Header

// /*
// Copyright (c) 2022 Rational Alliance. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using System;
using System.Threading.Tasks;
using IdentityModel.Client;
using NUnit.Framework;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Common.Models;
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

    #endregion
}