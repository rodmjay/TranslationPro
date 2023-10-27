using System.Net;
using TranslationPro.Base.Applications.Models;

namespace TranslationPro.Testing.TestCases
{
    public static class ApplicationTestCases
    {
        public static object[] CreateModels => new object[]
        {
            new object[]
            {
                CreateApplication,
                HttpStatusCode.OK
            }
        };

        public static CreateApplicationInput CreateApplication =>
            new()
            {
                Name = "Test",
                Languages = new []{"en","es"}
            };
    }
}
