#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Shared.Models;
using TranslationPro.Testing.Helpers;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class ApplicationsControllerTest : BaseApiTest
{
    [TestFixture]
    public class TheCreateApplicationAsyncMethod : ApplicationsControllerTest
    {
        [TestCaseSource(typeof(ApplicationTestCases), nameof(ApplicationTestCases.CreateModels))]
        public async Task RunTestCases(ApplicationCreateOptions input)
        {
            var response = await ApplicationsProxy.CreateApplicationAsync(input);

            Assert.IsTrue(response.Succeeded);
        }

        [TestCaseSource(typeof(LanguageTestCases), nameof(LanguageTestCases.Languages))]
        public async Task CanCreateApplicationWithLanguage(string language)
        {

            var randomCompanyName = RandomValueHelper.GenerateRandomCompanyName();

            var input = new ApplicationCreateOptions()
            {
                Name = randomCompanyName,
                Languages = new[] { language }
            };

            var response = await ApplicationsProxy.CreateApplicationAsync(input);
            Assert.IsTrue(response.Succeeded);

            var application = await ApplicationsProxy.GetApplicationAsync(Guid.Parse(response.Id.ToString()));

            Assert.IsNotNull(application);

            Assert.AreEqual(randomCompanyName, application.Name);
        }
    }

    [TestFixture]
    public class TheDeleteApplicationAsyncMethod : ApplicationsControllerTest
    {
        [Test]
        public async Task CanDeleteApplication()
        {
            var applications = await ApplicationsProxy.GetApplicationsAsync();

            Assert.AreEqual(1, applications.Count);

            var createPhraseResult = await ApplicationPhrasesProxy.CreatePhrasesAsync(ApplicationId, new PhraseOptions()
            {
                Texts = new []{ "hello world" }
            });

            var application = await ApplicationsProxy.GetApplicationAsync(ApplicationId);

            Assert.AreEqual(1, application.PhraseCount);

            var deleteResult = await ApplicationsProxy.DeleteApplicationAsync(Guid.Parse(ApplicationResult.Id.ToString()));
            Assert.IsTrue(deleteResult.Succeeded);

            applications = await ApplicationsProxy.GetApplicationsAsync();

            Assert.AreEqual(0, applications.Count);
        }
    }

    [TestFixture]
    public class TheUpdateApplicationAsyncMethod : ApplicationsControllerTest
    {
        [TestCaseSource(typeof(ApplicationTestCases), nameof(ApplicationTestCases.UpdateModels))]
        public async Task CanUpdateApplication(ApplicationOptions input)
        {
            var result = await CreateDefaultApplication();
            var updateResult = await ApplicationsProxy.UpdateApplicationAsync(Guid.Parse(result.Id.ToString()), input);
            Assert.IsTrue(updateResult.Succeeded);

            var application = await ApplicationsProxy.GetApplicationAsync(Guid.Parse(updateResult.Id.ToString()));

            Assert.IsNotNull(application);

            Assert.AreEqual(input.Name, application.Name);
        }
    }

    [TestFixture]
    public class TheGetApplicationsAsyncMethod : ApplicationsControllerTest
    {
        [Test]
        public async Task CanGetApplications()
        {
            var result = await ApplicationsProxy.GetApplicationsAsync();

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.Count);
        }
    }

    [TestFixture]
    public class TheGetApplicationAsyncMethod : ApplicationsControllerTest
    {
        [Test]
        public async Task CanGetApplication()
        {
            var id = Guid.Parse(ApplicationResult.Id.ToString());
            var result = await ApplicationsProxy.GetApplicationAsync(id);

            Assert.IsNotNull(result);

            Assert.AreEqual("Test", result.Name);
            Assert.AreEqual(1, result.Users.Count);
        }
    }
}