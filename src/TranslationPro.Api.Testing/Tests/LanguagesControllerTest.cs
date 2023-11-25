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
    public class TheGetLanguagesMethod : LanguagesControllerTest
    {
        [Test]
        public async Task CanGetLanguages()
        {
            var languages = await LanguageProxy.GetLanguagesAsync();

            Assert.AreEqual(123, languages.Count);
        }
    }
    
}