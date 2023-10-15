#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Threading.Tasks;
using IdentityModel.Client;
using NUnit.Framework;
using TemplateBase.IntegrationTests.Bases;

namespace TemplateApi.Testing.Tests
{
    [TestFixture]
    public class IdentityControllerTests : IntegrationTest<IdentityControllerTests, Startup>
    {
        [OneTimeSetUp]
        public async Task SetupFixture()
        {
            await ResetDatabase();
            var accessToken = await GetAccessToken("admin", "ASDFasdf!");
            ApiClient.SetBearerToken(accessToken);
        }

        [OneTimeTearDown]
        public async Task TeardownFixture()
        {
            await DeleteDatabase();
        }

        protected string IdentityUrl = "/v1.0/identity";

        [TestFixture]
        public class TheGetJourneyMethod : IdentityControllerTests
        {
            [Test]
            public async Task HappyPath()
            {
                var getJourneyResponse = await ApiClient.GetAsync(IdentityUrl);

                var getJourneyResult = await getJourneyResponse.Content.ReadAsStringAsync();

                Assert.IsNotNull(getJourneyResult);
            }
        }
    }
}