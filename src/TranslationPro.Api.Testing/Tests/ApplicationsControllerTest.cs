#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Testing.Extensions;
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
            var content = input.SerializeToUTF8Json();

            var response = await ApiClient.PostAsync(ApplicationUrl, content);

            Assert.AreEqual(response.StatusCode, code);
        }
    }

    [TestFixture]
    public class TheDeleteApplicationAsyncMethod : ApplicationsControllerTest
    {
        [Test]
        public async Task CanDeleteApplication()
        {
            var applications = await GetApplications();

            Assert.AreEqual(1, applications.Count);
            var deleteApplicationMethod = await DeleteApplication(Guid.Parse(ApplicationResult.Id.ToString()));
            Assert.IsTrue(deleteApplicationMethod.Succeeded);

            applications = await GetApplications();

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
            var result = await CreateApplication();
            var updateResult = await UpdateApplication(Guid.Parse(result.Id.ToString()), input);
            Assert.IsTrue(updateResult.Succeeded);

            var application = await GetApplication(Guid.Parse(updateResult.Id.ToString()));

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
            var result = await GetApplications();

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
            var result = await GetApplication(id);

            Assert.IsNotNull(result);

            Assert.AreEqual("Test", result.Name);
            Assert.AreEqual(1, result.Users.Count);
        }
    }
}