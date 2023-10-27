#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using NUnit.Framework;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class LanguagesControllerTest : BaseApiTest
{
    [TestFixture]
    public class TheGetLanguagesMethod : BaseApiTest
    {
        [Test]
        public async Task CanGetLanguages()
        {
            var languages = await GetLanguagesAsync();

            Assert.AreEqual(26, languages.Count);
        }
    }
}