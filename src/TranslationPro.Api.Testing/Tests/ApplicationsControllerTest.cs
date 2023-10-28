#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Phrases.Models;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class ApplicationsControllerTest : BaseApiTest
{
    [TestFixture]
    public class TheCreateApplicationAsyncMethod : ApplicationsControllerTest
    {
        [TestCaseSource(typeof(ApplicationTestCases), nameof(ApplicationTestCases.CreateModels))]
        public async Task RunTestCases(CreateApplicationInput input, HttpStatusCode code)
        {
            var response = await CreateApplicationAsync(input);

            Assert.IsTrue(response.Succeeded);
        }
    }

    [TestFixture]
    public class TheDeleteApplicationAsyncMethod : ApplicationsControllerTest
    {
        [Test]
        public async Task CanDeleteApplication()
        {
            var applications = await GetApplicationsAsync();

            Assert.AreEqual(1, applications.Count);

            var createPhraseResult = await CreatePhraseAsync(ApplicationId, new PhraseInput()
            {
                Text = "hello world"
            });

            var application = await GetApplicationAsync(ApplicationId);

            Assert.AreEqual(1, application.PhraseCount);

            var deleteResult = await DeleteApplicationAsync(Guid.Parse(ApplicationResult.Id.ToString()));
            Assert.IsTrue(deleteResult.Succeeded);

           

            applications = await GetApplicationsAsync();
            
            Assert.AreEqual(0, applications.Count);
        }
    }

    [TestFixture]
    public class TheUpdateApplicationAsyncMethod : ApplicationsControllerTest
    {
        [Test]
        public async Task CanUpdateApplication()
        {
            var input = new ApplicationInput
            {
                Name = "Updated"
            };
            var result = await CreateDefaultApplication();
            var updateResult = await UpdateApplicationAsync(Guid.Parse(result.Id.ToString()), input);
            Assert.IsTrue(updateResult.Succeeded);

            var application = await GetApplicationAsync(Guid.Parse(updateResult.Id.ToString()));

            Assert.IsNotNull(application);

            Assert.AreEqual("Updated", application.Name);
        }
    }

    [TestFixture]
    public class TheGetApplicationsAsyncMethod : ApplicationsControllerTest
    {
        [Test]
        public async Task CanGetApplications()
        {
            var result = await GetApplicationsAsync();

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
            var result = await GetApplicationAsync(id);

            Assert.IsNotNull(result);

            Assert.AreEqual("Test", result.Name);
            Assert.AreEqual(1, result.Users.Count);
        }
    }
}