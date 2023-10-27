using System;
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
        public class TheCreateApplicationMethod : ApplicationsControllerTest
        {
            [Test]
            public async Task RunTestCases()
            {
                Assert.IsTrue(ApplicationResult.Succeeded);
            }
        }

    }
}
