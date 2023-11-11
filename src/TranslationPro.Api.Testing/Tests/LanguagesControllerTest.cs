#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class LanguagesControllerTest : BaseApiTest
{
    
    [TestFixture]
    public class TheGetLanguageMethod : LanguagesControllerTest
    {
        [TestCaseSource(typeof(LanguageTestCases), nameof(LanguageTestCases.LanguagesWithEngineCount))]
        public async Task CanGetLanguage(string languageId, int engineCount)
        {
            var language = await LanguageProxy.GetLanguageAsync(languageId);

            Assert.AreEqual(engineCount, language.Engines.Count);
        }
    }

    [TestFixture]
    public class TheGetLanguagesMethod : LanguagesControllerTest
    {
        [Test]
        public async Task CanGetLanguages()
        {
            var languages = await LanguageProxy.GetLanguagesAsync();

            Assert.AreEqual(26, languages.Count);
        }
    }

    [TestFixture]
    public class TheGetAllLanguagesMethod : LanguagesControllerTest
    {
        [Test]
        public async Task CanGetAllLanguages()
        {
            var languages = await LanguageProxy.GetAllLanguagesAsync();

            Assert.AreEqual(132, languages.Count);
        }
    }
}