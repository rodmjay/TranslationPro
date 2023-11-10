#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Proxies;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class LanguagesControllerTest : BaseApiTest
{
    protected ILanguagesController LanguageProxy => new LanguagesProxy(ApiClient);

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