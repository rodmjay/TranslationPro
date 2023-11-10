using System.Threading.Tasks;
using NUnit.Framework;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class EnginesControllerTest : BaseApiTest
{
    [TestFixture]
    public class TheGetEnginesMethod : EnginesControllerTest
    {
        [Test]
        public async Task CanGetEngines()
        {
            var engines = await EnginesProxy.GetEnginesAsync();
            Assert.AreEqual(4, engines.Count);
        }
    }
}