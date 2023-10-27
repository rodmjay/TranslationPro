using System;
using System.Diagnostics.Contracts;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Testing.Extensions;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing.Tests
{
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
                var result = await CreateApplication();
                var deleteApplicationMethod = await DeleteApplication(Guid.Parse(result.Id.ToString()));
                Assert.IsTrue(deleteApplicationMethod.Succeeded);
            }
        }

        [TestFixture]
        public class TheUpdateApplicationAsyncMethod : ApplicationsControllerTest
        {
            [Test]
            public async Task CanUpdateApplication()
            {
                var input = new ApplicationInput()
                {
                    Name = "Updated"
                };
                var result = await CreateApplication();
                var updateResult = await UpdateApplication(Guid.Parse(result.Id.ToString()), input);
                Assert.IsTrue(updateResult.Succeeded);
            }
        }

        [TestFixture]
        public class TheGetApplicationsAsyncMethod : ApplicationsControllerTest
        {

        }

        [TestFixture]
        public class TheGetApplicationAsyncMethod : ApplicationsControllerTest
        {

        }
    }
}
