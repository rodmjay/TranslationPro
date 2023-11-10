#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using IdentityModel.Client;
using NUnit.Framework;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Proxies;
using TranslationPro.Testing.Bases;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing;

public abstract class BaseApiTest : IntegrationTest<BaseApiTest, Startup>
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

    protected async Task<Result> CreateDefaultApplication()
    {
        return await ApplicationsProxy.CreateApplicationAsync(ApplicationTestCases.CreateApplication);
    }

    [OneTimeTearDown]
    public virtual async Task TeardownFixture()
    {
        await DeleteDatabase();
    }

    protected IApplicationsController ApplicationsProxy => new ApplicationsProxy(ApiClient);
    protected IApplicationLanguagesController ApplicationLanguageProxy => new ApplicationLanguagesProxy(ApiClient);
    protected IPhrasesController PhrasesProxy => new PhrasesProxy(ApiClient);
    protected IApplicationUsersController ApplicationUsersProxy => new ApplicationUsersProxy(ApiClient);
    protected ITranslationsController TranslationsProxy => new TranslationsProxy(ApiClient);
    protected IEnginesController EnginesProxy => new EnginesProxy(ApiClient);


}